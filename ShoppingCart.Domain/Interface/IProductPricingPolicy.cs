using ShoppingCart.Domain.Clients;
using ShoppingCart.Domain.Products;


namespace ShoppingCart.Domain.Interface
{
    public interface IProductPricingPolicy
    {
        decimal GetUnitPrice(Client client, ProductType productType);
    }
}
