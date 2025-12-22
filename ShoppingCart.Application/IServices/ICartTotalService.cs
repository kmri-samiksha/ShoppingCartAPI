using ShoppingCart.Domain.Clients;
using ShoppingCart.Domain.ShoppingCart;

namespace ShoppingCart.Application.IServices
{
    public interface ICartTotalService
    {
        Task<decimal> CalculateTotalAsync(Client client, IEnumerable<CartItem> items);
    }
}
