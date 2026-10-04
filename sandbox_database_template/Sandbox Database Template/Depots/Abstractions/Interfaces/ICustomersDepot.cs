using CSM_Database_Core.Depots.Abstractions.Interfaces;

using Sandbox.Database.Template.Entities;

namespace Sandbox.Database.Template.Depots.Abstractions.Interfaces;

/// <summary>
///     Represents a <see cref="Customer"/> business entity depot.
/// </summary>
public interface ICustomersDepot
    : IDepot<Customer> {
}
