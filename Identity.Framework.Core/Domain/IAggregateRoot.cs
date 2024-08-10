


using Identity.Framework.Core.Bus;
using System.Collections.Generic;

namespace Identity.Framework.Core.Domain;

public interface IAggregateRoot
{
    IReadOnlyList<IDomainEvent> GetChangesDomainEvents();
    void ClearDomainEvents();
}