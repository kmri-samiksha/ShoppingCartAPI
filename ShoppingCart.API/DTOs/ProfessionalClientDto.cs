using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.API.DTOs
{
    public record ProfessionalClientDto(
         [Required(ErrorMessage = "ClientId is required")]
        Guid ClientId,
        [Required(ErrorMessage = "CompanyName is required")]
        string CompanyName,

         [Range(0.01, double.MaxValue, ErrorMessage = "AnnualRevenue is required")]
        decimal AnnualRevenue);
}
