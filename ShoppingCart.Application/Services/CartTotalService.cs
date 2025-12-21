using ShoppingCart.Application.IServices;
using ShoppingCart.Domain.Clients;
using ShoppingCart.Domain.Interface;
using ShoppingCart.Domain.ShoppingCart;


namespace ShoppingCart.Application.Services
{
    public sealed class CartTotalService: ICartTotalService
    {

        private readonly IProductPricingPolicy _pricingPolicy;

        public CartTotalService(IProductPricingPolicy pricingPolicy)
        {
            _pricingPolicy = pricingPolicy;
        }

        public async Task<decimal> CalculateTotalAsync(Client client, IEnumerable<CartItem> items)
        {
            decimal total = 0;

            foreach (var item in items)
            {
                var unitPrice =_pricingPolicy.GetUnitPrice(client, item.ProductType);
                total += unitPrice * item.Quantity;
            }
            return await Task.FromResult(total);            
        }
    }
}
