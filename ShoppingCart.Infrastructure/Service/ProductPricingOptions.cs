using ShoppingCart.Domain.Products;


namespace ShoppingCart.Infrastructure.Service
{
    public class ProductPricingOptions
    {
        public Dictionary<ProductType, decimal> Individual { get; set; } = new();
        public ProfessionalPricing Professional { get; set; } = new();
        
        
    }
}
