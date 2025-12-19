namespace ShoppingCart.API.DTOs
{
    public record ProfessionalCartRequestDto(
    ProfessionalClientDto Client,
    List<CartItemDto> Items
);
}
