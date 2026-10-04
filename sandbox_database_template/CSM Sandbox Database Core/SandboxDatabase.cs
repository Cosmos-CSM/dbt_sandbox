using CSM_Database_Core;
using CSM_Database_Core.Core.Models;

using Microsoft.EntityFrameworkCore;

using Sandbox.Database.Template.Entities;

namespace Sandbox.Database.Template;

/// <summary>
///     Represents the database context for [CSM Sandbox].
/// </summary>
public class SandboxDatabase : DatabaseBase<SandboxDatabase> {

    /// <inheritdoc/>
    public override string Sign => "CSMSB";

    /// <summary>
    ///     Categories set.
    /// </summary>
    public DbSet<Category> Categories { get; set; } = default!;

    /// <summary>
    ///     Customers set.
    /// </summary>
    public DbSet<Customer> Customers { get; set; } = default!;

    /// <summary>
    ///     Orders set.
    /// </summary>
    public DbSet<Order> Orders { get; set; } = default!;

    /// <summary>
    ///     Orders items set.
    /// </summary>
    public DbSet<OrderItem> OrdersItems { get; set; } = default!;

    /// <summary>
    ///     Products set.
    /// </summary>
    public DbSet<Product> Products { get; set; } = default!;

    /// <summary>
    ///    Suppliers set.
    /// </summary>
    public DbSet<Supplier> Suppliers { get; set; } = default!;

    /// <inheritdoc/>
    public SandboxDatabase()
        : base() {
    }

    /// <inheritdoc/>
    public SandboxDatabase(DatabaseOptions<SandboxDatabase> options)
        : base(options) {

    }
}
