using Microsoft.Extensions.Options;
using ShoppingCart.Domain.Clients;
using ShoppingCart.Domain.Interface;
using ShoppingCart.Domain.Products;


namespace ShoppingCart.Infrastructure.Service
{
    public class ConfigProductPricingPolicy : IProductPricingPolicy
    {
        private readonly ProductPricingOptions _options;

        public ConfigProductPricingPolicy(IOptions<ProductPricingOptions> options)
        {
            _options = options.Value;
        }

        public decimal GetUnitPrice(Client client, ProductType productType)
        {
            return client switch
            {
                IndividualClient _ => _options.Individual[productType],

                ProfessionalClient p => p.AnnualRevenue > 10_000_000
                    ? _options.Professional.Above10M[productType]
                    : _options.Professional.Below10M[productType],

                _ => throw new InvalidOperationException("Unknown client type")
            };
        }
    }

}
