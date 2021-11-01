using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.DbContexts.Contexts;
using Mmu.CleanDdd.Shared.Domain.Shell.Areas.DomainEvents.Services.Servants;

namespace Mmu.CleanDdd.Shared.Domain.Shell.Areas.DomainEvents.Services.Implementation
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IDomainEventAccessor _domainEventAccessor;
        private readonly IMediator _mediator;

        public DomainEventDispatcher(
            IDomainEventAccessor domainEventAccessor,
            IMediator mediator)
        {
            _domainEventAccessor = domainEventAccessor;
            _mediator = mediator;
        }

        public async Task DispatchEventsAsync(IAppDbContext dbContext)
        {
            var events = _domainEventAccessor.GetDomainEvents(dbContext);

            foreach(var ev in events)
            {
                await _mediator.Publish(ev);
            }

            _domainEventAccessor.ClearAllDomainEvents(dbContext);
        }
    }
}
