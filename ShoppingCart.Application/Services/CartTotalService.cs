using ShoppingCart.Domain.Clients;
using ShoppingCart.Domain.Pricing;
using ShoppingCart.Domain.ShoppingCart;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace ShoppingCart.Application.Services
{
    public sealed class CartTotalService
    {
        public decimal CalculateTotal(Client client, IEnumerable<CartItem> items)
        {
            decimal total = 0;

            foreach (var item in items)
            {
                var unitPrice = PriceCalculator.GetUnitPrice(client, item.ProductType);
                total += unitPrice * item.Quantity;
            }

            return total;
        }
    }
}
