namespace ShoppingCart.API.DTOs
{
    public record IndividualCartRequestDto(
    IndividualClientDto Client,
    List<CartItemDto> Items
);
}
