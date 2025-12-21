using ShoppingCart.Domain.Clients;
using ShoppingCart.Domain.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.IServices
{
    public interface ICartTotalService
    {
        Task<decimal> CalculateTotalAsync(Client client, IEnumerable<CartItem> items);
    }
}
