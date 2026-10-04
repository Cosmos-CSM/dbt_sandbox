using CSM_Database_Core.Core.Attributes;
using CSM_Database_Core.Core.Extensions;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Sandbox.Database.Template.Entities.Abstractions.Bases;

namespace Sandbox.Database.Template.Entities;

/// <summary>
///     Represents a customer purchase order.
/// </summary>
public class Order : SandboxEntityBase {

    /// <summary>
    ///    Total at order time.
    /// </summary>
    public double Total { get; set; } = 0.0;

    /// <summary>
    ///     Order customer.
    /// </summary>
    [EntityRelation]
    public Customer Customer { get; set; } = default!;

    /// <summary>
    ///     Order items.
    /// </summary>
    [EntityRelation]
    public ICollection<OrderItem> Items { get; set; } = [];

    /// <inheritdoc/>
    protected override void DesignEntity(EntityTypeBuilder etBuilder) {
        etBuilder.Property(nameof(Total));

        etBuilder.Link<Order, Customer>(
                nameof(Customer),
                nameof(Customer.Orders),
                isRequired: true,
                isAutoLoaded: true
            );
    }
}
