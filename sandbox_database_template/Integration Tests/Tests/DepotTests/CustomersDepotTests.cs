using CSM_Database_Core.Depots.Models;

using Sandbox.Database.Template.Depots;
using Sandbox.Database.Template.Entities;
using Sandbox.Database.Template.Testing.Abstractions.Bases;
using Sandbox.Database.Template.Testing.Utils;

using Xunit;

namespace Integration_Tests.Tests.DepotTests;

/// <summary>
///     Depot integration tests for <see cref="CustomersDepot"/>
/// </summary>
public class CustomersDepotTests
    : SandboxDepotIntegrationTestsBase<Customer, CustomersDepot> {

    protected override Customer EntityFactory(string Entropy) {
        Supplier supplier = _storeManager.Supplier().GetAwaiter().GetResult();

        return DraftUtils.Customer(
                new Customer {
                    Supplier = supplier,
                }
            );
    }

    /// Expectation:
    ///     The [Customer] description gets updated correcly, and the previous [Customer] has the expected
    ///     previous description value.
    ///     
    /// Scenario: 
    ///     We store a [Customer] into database, then change its description value and sends update operation.
    ///    
    public override async Task Update_Single_Success() {
        /// Setup
        string exDescription = "new updated description";

        Customer customer = await _storeManager.Customer();

        /// Act
        string? prevDescirption = customer.Description;
        customer.Description = exDescription;

        UpdateOutput<Customer> output = await _depot.Update(
                new QueryInput<Customer, UpdateInput<Customer>> {
                    Parameters = new UpdateInput<Customer> {
                        Entity = customer
                    }
                }
            );

        /// Assert
        Assert.NotNull(output.Original);
        Assert.Equal(prevDescirption, output.Original.Description);

        Assert.Equal(exDescription, output.Updated.Description);
    }
}
