using CSM_Database_Core.Depots.Models;

using Sandbox.Database.Template.Depots;
using Sandbox.Database.Template.Entities;
using Sandbox.Database.Template.Testing.Abstractions.Bases;
using Sandbox.Database.Template.Testing.Utils;

using Xunit;

namespace Integration_Tests.Tests.DepotTests;

public class CategoriesDepotTests
    : SandboxDepotIntegrationTestsBase<Category, CategoriesDepot> {

    protected override Category EntityFactory(string Entropy) {
        return DraftUtils.Category();
    }

    /// Expectation:
    ///     The [<see cref="Category"/>] description gets updated correcly, and the previous [<see cref="Category"/>] has the expected
    ///     previous description value.
    ///     
    /// Scenario: 
    ///     We store a [<see cref="Category"/>] into database, then change its description value and sends update operation.
    ///    
    public override async Task Update_Single_Success() {
        /// Setup
        string exDescription = "new updated description";

        Category category = await _storeManager.Category();

        /// Act
        string? prevDescirption = category.Description;
        category.Description = exDescription;

        UpdateOutput<Category> output = await _depot.Update(
                new QueryInput<Category, UpdateInput<Category>> {
                    Parameters = new UpdateInput<Category> {
                        Entity = category
                    }
                }
            );

        /// Assert
        Assert.NotNull(output.Original);
        Assert.Equal(prevDescirption, output.Original.Description);

        Assert.Equal(exDescription, output.Updated.Description);
    }
}
