using System;
using System.Collections.Concurrent;
using System.Linq;
using JetBrains.Annotations;
using Lamar;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Maybes;
using Mmu.CleanDddSimple.DataAccess.DbContexts.Contexts;
using Mmu.CleanDddSimple.DataAccess.Repositories.Implementation.Base;
using Mmu.CleanDddSimple.Domain.Data.Repositories;

namespace Mmu.CleanDddSimple.DataAccess.UnitOfWorks.Servants.Implementation
{
    [UsedImplicitly]
    public class RepositoryCache : IRepositoryCache
    {
        private readonly IContainer _container;
        private readonly ConcurrentDictionary<Type, IRepository> _repos;

        public RepositoryCache(IContainer container)
        {
            _container = container;
            _repos = new ConcurrentDictionary<Type, IRepository>();
        }

        public TRepo GetRepository<TRepo>(IAppDbContext dbContext)
            where TRepo : IRepository
        {
            var getRepoResult = TryGettingRepository<TRepo>();
            var repo = getRepoResult.Reduce(() => InitializeRepository<TRepo>(dbContext));

            return repo;
        }

        private TRepo InitializeRepository<TRepo>(IAppDbContext dbContext)
            where TRepo : IRepository
        {
            var repository = _container.GetInstance<TRepo>();

            if (!(repository is IRepositoryBase repoBase))
            {
                throw new ArgumentException($"{nameof(TRepo)} does not implement RepositoryBase");
            }

            repoBase.Initialize(dbContext);
            _repos.AddOrUpdate(repository.GetType(), repository, (_, repo) => repo);

            return repository;
        }

        private Maybe<TRepo> TryGettingRepository<TRepo>()
            where TRepo : IRepository
        {
            var repoType = typeof(TRepo);

            // For some reason, TryGetValue doesn't work here
            var cachedRepo = _repos.SingleOrDefault(f => repoType.IsAssignableFrom(f.Key));
            var castedRepo = (TRepo)cachedRepo.Value;

            return Maybe.CreateFromNullable(castedRepo);
        }
    }
}