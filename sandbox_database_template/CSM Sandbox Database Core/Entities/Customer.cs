using CSM_Database_Core.Core.Attributes;
using CSM_Database_Core.Core.Extensions;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Sandbox.Database.Template.Entities.Abstractions.Bases;

namespace Sandbox.Database.Template.Entities;

/// <summary>
///     Represents a business customer.
/// </summary>
public class Customer : SandboxEntityBase {

    /// <summary>
    ///    Customer assigned supplier.
    /// </summary>
    [EntityRelation]
    public Supplier Supplier { get; set; } = default!;

    /// <summary>
    ///     Customer orders.
    /// </summary>
    [EntityRelation]
    public ICollection<Order> Orders { get; set; } = [];

    /// <inheritdoc/>
    protected override void DesignEntity(EntityTypeBuilder etBuilder) {
        etBuilder.Link<Customer, Supplier>(
                nameof(Supplier),
                nameof(Supplier.Customers),
                isRequired: true,
                isAutoLoaded: true
            );
    }
}
