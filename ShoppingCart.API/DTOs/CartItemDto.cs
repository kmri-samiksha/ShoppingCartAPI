using ShoppingCart.Domain.Products;

namespace ShoppingCart.API.DTOs
{
    public record CartItemDto(ProductType ProductType, int Quantity);
}
