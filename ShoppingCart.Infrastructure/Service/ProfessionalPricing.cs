using ShoppingCart.Domain.Products;

namespace ShoppingCart.Infrastructure.Service
{
    public class ProfessionalPricing
    {
        public Dictionary<ProductType, decimal> Above10M { get; set; } = new();
        public Dictionary<ProductType, decimal> Below10M { get; set; } = new();
        public decimal ProfessionalRevenueThreshold { get; set; }
    }
}
