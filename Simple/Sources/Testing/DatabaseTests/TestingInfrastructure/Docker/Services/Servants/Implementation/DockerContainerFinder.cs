using System.Linq;
using System.Threading.Tasks;
using Docker.DotNet.Models;
using JetBrains.Annotations;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.LanguageExtensions.Types.Maybes;

namespace Mmu.CleanDddSimple.DatabaseTests.TestingInfrastructure.Docker.Services.Servants.Implementation
{
    [UsedImplicitly]
    public class DockerContainerFinder : IDockerContainerFinder
    {
        private readonly IDockerClientFactory _clientFactory;

        public DockerContainerFinder(IDockerClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<Maybe<string>> TryFindingIdByNameAsync(string namepart)
        {
            using var client = _clientFactory.Create();

            var containers = await client.Containers.ListContainersAsync(new ContainersListParameters { All = true });
            var existingContainer = containers.SingleOrDefault(f => f.Names.Contains("/" + namepart));

            return Maybe.CreateFromNullable(existingContainer?.ID);
        }
    }
}