using CSM_Database_Core.Depots.Abstractions.Bases;
using CSM_Database_Core.Entities.Abstractions.Interfaces;

using CSM_Foundation_Core.Abstractions.Interfaces;

namespace Sandbox.Database.Template.Depots.Abstractions.Bases;

/// <summary>
///     Represents a <see cref="SandboxDatabase"/> depot base.
/// </summary>
/// <typeparam name="TEntity">
///     Type of the <see cref="SandboxDatabase"/> entity.
/// </typeparam>
public class SandboxDepotBase<TEntity>
    : DepotBase<SandboxDatabase, TEntity>
    where TEntity : class, IEntity, new() {

    /// <inheritdoc/>
    public SandboxDepotBase(SandboxDatabase Database, IDisposer<IEntity>? Disposer)
        : base(Database, Disposer) {
    }
}
