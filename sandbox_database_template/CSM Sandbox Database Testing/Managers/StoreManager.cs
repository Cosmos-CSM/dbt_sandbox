using CSM_Database_Testing.Managers;

using Sandbox.Database.Template.Entities;
using Sandbox.Database.Template.Testing.Utils;

using SandboxEntities = CSM_Sandbox_Database_Core.Entities;

namespace Sandbox.Database.Template.Testing.Managers;

/// <summary>
///     Represents a test data storing handler for <see cref="Template.SandboxDatabase"/> entities.
/// </summary>
public class StoreManager {

    /// <summary>
    ///     Base store manager,
    /// </summary>
    readonly TestingStoreManager _testingStoreManager;

    /// <summary>
    ///     Creates a new instance
    /// </summary>
    /// <param name="storeManager">
    ///     Testing data store manager.
    /// </param>
    public StoreManager(TestingStoreManager storeManager) {
        _testingStoreManager = storeManager;
    }

    /// <summary>
    ///     Stores a <see cref="Entities.Category"/>
    /// </summary>
    /// <returns>
    ///     A datasource stored <see cref="Entities.Category"/>.
    /// </returns>
    public async Task<Category> Category(Category? @ref = null) {
        @ref = DraftUtils.Category(@ref);

        return await _testingStoreManager.Store(@ref);
    }

    /// <summary>
    ///     Stores a <see cref="Entities.Customer"/>
    /// </summary>
    /// <returns>
    ///     A datasource stored <see cref="Entities.Customer"/>.
    /// </returns>
    public async Task<Customer> Customer(Customer? @ref = null) {
        @ref = DraftUtils.Customer(@ref);

        if (@ref.Supplier.Id <= 0)
            await Supplier(@ref.Supplier);

        return await _testingStoreManager.Store(@ref);
    }

    /// <summary>
    ///     Stores a <see cref="Entities.Order"/>
    /// </summary>
    /// <returns>
    ///     A datasource stored <see cref="Entities.Order"/>.
    /// </returns>
    public async Task<Order> Order(Order? @ref = null) {
        @ref = DraftUtils.Order(@ref);

        if (@ref.Customer.Id <= 0)
            await Customer(@ref.Customer);


        return await _testingStoreManager.Store(@ref);
    }

    /// <summary>
    ///     Stores a <see cref="Entities.OrderItem"/>
    /// </summary>
    /// <returns>
    ///     A datasource stored <see cref="Entities.OrderItem"/>.
    /// </returns>
    public async Task<OrderItem> OrderItem(OrderItem? @ref = null) {
        @ref = DraftUtils.OrderItem(@ref);

        return await _testingStoreManager.Store(@ref);
    }

    /// <summary>
    ///     Stores a <see cref="Entities.Product"/>
    /// </summary>
    /// <returns>
    ///     A datasource stored <see cref="Entities.Product"/>.
    /// </returns>
    public async Task<Product> Product(Product? @ref = null) {
        @ref = DraftUtils.Product(@ref);

        if (@ref.Category.Id <= 0)
            await Category(@ref.Category);

        return await _testingStoreManager.Store(@ref);
    }

    /// <summary>
    ///     Stores a <see cref="Entities.Supplier"/>
    /// </summary>
    /// <returns>
    ///     A datasource stored <see cref="Entities.Supplier"/>.
    /// </returns>
    public async Task<Supplier> Supplier(Supplier? @ref = null) {
        @ref = DraftUtils.Supplier(@ref);

        return await _testingStoreManager.Store(@ref);
    }
}
