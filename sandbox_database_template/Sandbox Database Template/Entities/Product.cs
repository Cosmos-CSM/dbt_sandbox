using CSM_Database_Core.Core.Attributes;
using CSM_Database_Core.Core.Extensions;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Sandbox.Database.Template.Entities.Abstractions.Bases;

namespace Sandbox.Database.Template.Entities;

/// <summary>
///     Represents a business offered product.
/// </summary>
public class Product : SandboxEntityBase {

    /// <summary>
    ///     Product category.
    /// </summary>
    [EntityRelation]
    public Category Category { get; set; } = default!;

    /// <summary>
    ///    Orders requesting this product.
    /// </summary>
    [EntityRelation]
    public ICollection<OrderItem> Orders { get; set; } = [];

    /// <inheritdoc/>
    protected override void DesignEntity(EntityTypeBuilder etBuilder) {
        etBuilder.Link<Product, Category>(
                nameof(Category),
                nameof(Category.Products),
                isRequired: true,
                isAutoLoaded: true
            );
    }
}
