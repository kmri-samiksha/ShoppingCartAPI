using ShoppingCart.Domain.Clients;
using ShoppingCart.Domain.Products;


namespace ShoppingCart.Domain.Interface
{
    // Implementation of this interface resides in the Infrastructure layer, 
    // as the pricing policy data will be retrieved from the database later during Development.
    public interface IProductPricingPolicy
    {
        decimal GetUnitPrice(Client client, ProductType productType);
    }
}
