using CSM_Database_Core.Core.Attributes;
using CSM_Database_Core.Core.Extensions;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Sandbox.Database.Template.Entities.Abstractions.Bases;

namespace Sandbox.Database.Template.Entities;

/// <summary>
///     Represents an <see cref="Order"/> item.
/// </summary>
public class OrderItem : SandboxEntityBase {

    /// <summary>
    ///     Item order.
    /// </summary>
    [EntityRelation]
    public Order Order { get; set; } = default!;

    /// <summary>
    ///     Item product.
    /// </summary>
    [EntityRelation]
    public Product Product { get; set; } = default!;

    /// <summary>
    ///     Item requeested quantity.
    /// </summary>
    public double Quantity { get; set; } = 0.0;

    /// <summary>
    ///     Product unitary price at order time.
    /// </summary>
    public double Price { get; set; } = 0.0;

    /// <summary>
    ///     Item total price at order time.
    /// </summary>
    public double Total { get; set; } = 0.0;

    /// <inheritdoc/>
    protected override void DesignEntity(EntityTypeBuilder etBuilder) {
        etBuilder.Link<OrderItem, Order>(
                nameof(Order),
                nameof(Order.Items)
            );

        etBuilder.Link<OrderItem, Product>(
                nameof(Product),
                nameof(Product.Orders)
            );
    }
}
