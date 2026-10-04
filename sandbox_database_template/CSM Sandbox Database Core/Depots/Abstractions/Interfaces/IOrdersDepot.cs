using CSM_Database_Core.Depots.Abstractions.Interfaces;

using Sandbox.Database.Template.Entities;

namespace Sandbox.Database.Template.Depots.Abstractions.Interfaces;

/// <summary>
///     Represents an <see cref="Order"/> business entity depot.
/// </summary>
public interface IOrdersDepot
    : IDepot<Order> {
}
