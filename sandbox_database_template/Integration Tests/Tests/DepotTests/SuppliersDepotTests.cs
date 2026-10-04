using CSM_Database_Core.Depots.Models;

using Sandbox.Database.Template.Depots;
using Sandbox.Database.Template.Entities;
using Sandbox.Database.Template.Testing.Abstractions.Bases;
using Sandbox.Database.Template.Testing.Utils;

using Xunit;

namespace Integration_Tests.Tests.DepotTests;

/// <summary>
///     Integration tests for <see cref="SuppliersDepot"/>
/// </summary>
public class SuppliersDepotTests
    : SandboxDepotIntegrationTestsBase<Supplier, SuppliersDepot> {

    protected override Supplier EntityFactory(string Entropy) {
        return DraftUtils.Supplier();
    }


    /// Expectation:
    ///     The [Supplier] description gets updated correcly, and the previous [Supplier] has the expected
    ///     previous description value.
    ///     
    /// Scenario: 
    ///     We store a [Supplier] into database, then change its description value and sends update operation.
    ///    
    public override async Task Update_Single_Success() {
        /// Setup
        string exDescription = "new updated description";

        Supplier supplier = await _storeManager.Supplier();

        /// Act
        string? prevDescirption = supplier.Description;
        supplier.Description = exDescription;

        UpdateOutput<Supplier> output = await _depot.Update(
                new QueryInput<Supplier, UpdateInput<Supplier>> {
                    Parameters = new UpdateInput<Supplier> {
                        Entity = supplier
                    }
                }
            );

        /// Assert
        Assert.NotNull(output.Original);
        Assert.Equal(prevDescirption, output.Original.Description);

        Assert.Equal(exDescription, output.Updated.Description);
    }
}
