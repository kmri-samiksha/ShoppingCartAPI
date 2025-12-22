using ShoppingCart.Domain.Products;

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
