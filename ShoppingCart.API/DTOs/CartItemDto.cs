using ShoppingCart.Domain.Products;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.API.DTOs
{
    public record CartItemDto(
        ProductType ProductType,

         [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        int Quantity);
}
