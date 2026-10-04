using CSM_Database_Core.Entities.Abstractions.Interfaces;

using CSM_Foundation_Core.Abstractions.Interfaces;

using Sandbox.Database.Template.Depots.Abstractions.Bases;
using Sandbox.Database.Template.Depots.Abstractions.Interfaces;
using Sandbox.Database.Template.Entities;

namespace Sandbox.Database.Template.Depots;

/// <inheritdoc cref="IProductsDepot"/>
public class ProductsDepot
    : SandboxDepotBase<Product>, IProductsDepot {

    /// <inheritdoc/>
    public ProductsDepot(SandboxDatabase Database, IDisposer<IEntity>? Disposer)
        : base(Database, Disposer) {
    }
}
