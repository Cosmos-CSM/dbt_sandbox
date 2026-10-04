using CSM_Database_Core.Depots.Models;

using Sandbox.Database.Template.Depots;
using Sandbox.Database.Template.Entities;
using Sandbox.Database.Template.Testing.Abstractions.Bases;
using Sandbox.Database.Template.Testing.Utils;

using Xunit;

namespace Integration_Tests.Tests.DepotTests;

/// <summary>
///     Depot integration tests for <see cref="CustomersDepot"/>.
/// </summary>
public class OrdersDepotTests
    : SandboxDepotIntegrationTestsBase<Order, OrdersDepot> {

    protected override Order EntityFactory(string Entropy) {
        Customer customer = _storeManager.Customer().GetAwaiter().GetResult();

        return DraftUtils.Order(
                new Order {
                    Customer = customer,
                }
            );
    }

    /// </summary>/// Expectation:
    ///     The [Order] gets updated correcly, and the previous [Order] has the expected
    ///     previous value.
    ///     
    /// Scenario: 
    ///     We store a [Order] into database, then change its value and sends update operation.
    ///    
    public override async Task Update_Single_Success() {
        /// Setup
        string exDescription = "new updated description";

        Order order = await _storeManager.Order();

        /// Act
        string? prevDescirption = order.Description;
        order.Description = exDescription;

        UpdateOutput<Order> output = await _depot.Update(
                new QueryInput<Order, UpdateInput<Order>> {
                    Parameters = new UpdateInput<Order> {
                        Entity = order
                    }
                }
            );

        /// Assert
        Assert.NotNull(output.Original);
        Assert.Equal(prevDescirption, output.Original.Description);

        Assert.Equal(exDescription, output.Updated.Description);
    }
}
