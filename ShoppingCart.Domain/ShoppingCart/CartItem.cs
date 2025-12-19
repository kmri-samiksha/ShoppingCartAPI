using ShoppingCart.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.ShoppingCart
{
    public sealed class CartItem
    {
        public ProductType ProductType { get; }
        public int Quantity { get; }

        public CartItem(ProductType productType, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            ProductType = productType;
            Quantity = quantity;
        }
    }
}
