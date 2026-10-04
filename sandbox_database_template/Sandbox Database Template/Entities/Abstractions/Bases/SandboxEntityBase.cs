using CSM_Database_Core.Entities.Abstractions.Bases;

using Sandbox.Database.Template;

namespace Sandbox.Database.Template.Entities.Abstractions.Bases;

/// <summary>
///     Represents a <see cref="SandboxDatabase"/> entity.
/// </summary>
public abstract class SandboxEntityBase : NamedEntityBase {

    /// <inheritdoc/>
    public override Type Database { get; init; } = typeof(SandboxDatabase);
}
