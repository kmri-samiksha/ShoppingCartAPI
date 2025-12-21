using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.API.DTOs
{
    public record IndividualClientDto(Guid ClientId,
        [Required(ErrorMessage = "FirstName is required")]
        string FirstName,
        [Required(ErrorMessage = "LastName is required")]
        string LastName);
}
