using CSM_Database_Core.Depots.Models;

using Sandbox.Database.Template.Depots;
using Sandbox.Database.Template.Entities;
using Sandbox.Database.Template.Testing.Abstractions.Bases;
using Sandbox.Database.Template.Testing.Utils;

using Xunit;

namespace Integration_Tests.Tests.DepotTests;

/// <summary>
///    Depot integration tests for <see cref="ProductsDepot"/>.
/// </summary>
public class ProductsDepotTests
    : SandboxDepotIntegrationTestsBase<Product, ProductsDepot> {

    protected override Product EntityFactory(string Entropy) {
        Category category = _storeManager.Category().GetAwaiter().GetResult();

        return DraftUtils.Product(
                new Product {
                    Category = category,
                }
            );
    }

    /// Expectation:
    ///     The [Product] gets updated correcly, and the previous [Product] has the expected
    ///     previous value.
    ///     
    /// Scenario: 
    ///     We store a [Product] into database, then change its value and sends update operation.
    ///    
    public override async Task Update_Single_Success() {
        /// Setup
        string exDescription = "new updated description";

        Product product = await _storeManager.Product();

        /// Act
        string? prevDescirption = product.Description;
        product.Description = exDescription;

        UpdateOutput<Product> output = await _depot.Update(
                new QueryInput<Product, UpdateInput<Product>> {
                    Parameters = new UpdateInput<Product> {
                        Entity = product
                    }
                }
            );

        /// Assert
        Assert.NotNull(output.Original);
        Assert.Equal(prevDescirption, output.Original.Description);

        Assert.Equal(exDescription, output.Updated.Description);
    }
}
