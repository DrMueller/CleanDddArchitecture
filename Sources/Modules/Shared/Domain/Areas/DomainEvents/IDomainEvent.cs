﻿using System;
using MediatR;

namespace Mmu.CleanDdd.Shared.Domain.Areas.DomainEvents
{
    public interface IDomainEvent : INotification
    {
        Guid Id { get; }

        DateTime OccurredOn { get; }
    }
}
