using ShoppingCart.Domain.Clients;
using ShoppingCart.Domain.Interface;
using ShoppingCart.Domain.ShoppingCart;


namespace ShoppingCart.Application.Services
{
    public sealed class CartTotalService
    {

        private readonly IProductPricingPolicy _pricingPolicy;

        public CartTotalService(IProductPricingPolicy pricingPolicy)
        {
            _pricingPolicy = pricingPolicy;
        }

        public decimal CalculateTotal(Client client, IEnumerable<CartItem> items)
        {
            decimal total = 0;

            foreach (var item in items)
            {
                var unitPrice =_pricingPolicy.GetUnitPrice(client, item.ProductType);
                total += unitPrice * item.Quantity;
            }
            return total;
        }
    }
}
