using CSM_Database_Core.Entities.Abstractions.Interfaces;

using CSM_Foundation_Core.Abstractions.Interfaces;

using Sandbox.Database.Template.Depots.Abstractions.Bases;
using Sandbox.Database.Template.Depots.Abstractions.Interfaces;
using Sandbox.Database.Template.Entities;

namespace Sandbox.Database.Template.Depots;

/// <summary>
///     Represents a <see cref="Category"/> business entity depot.
/// </summary>
public class CategoriesDepot
    : SandboxDepotBase<Category>, ICategoriesDepot {

    /// <inheritdoc/>
    public CategoriesDepot(SandboxDatabase Database, IDisposer<IEntity>? Disposer)
        : base(Database, Disposer) {
    }
}
