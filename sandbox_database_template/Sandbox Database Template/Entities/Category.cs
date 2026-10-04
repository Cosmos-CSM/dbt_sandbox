using CSM_Database_Core.Core.Attributes;

using Sandbox.Database.Template.Entities.Abstractions.Bases;

namespace Sandbox.Database.Template.Entities;

/// <summary>
///     Represents a business category to identify data.
/// </summary>
public class Category : SandboxEntityBase {

    /// <summary>
    ///     Category products.
    /// </summary>
    [EntityRelation]
    public ICollection<Product> Products { get; set; } = []; 
}
