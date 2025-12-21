using Microsoft.Extensions.Options;
using Moq;
//using ShoppingCart.Application.Services;
using ShoppingCart.Domain.Clients;
//using ShoppingCart.Domain.Interface;
//using ShoppingCart.Domain.Pricing;
using ShoppingCart.Domain.Products;
using ShoppingCart.Infrastructure.Service;

namespace ShoppingCart.Tests
{

    public class PricingTests
    {
        public class PriceCalculatorTests
        {
            [Fact]
            public void GetUnitPrice_IndividualClient_ReturnsCorrectPrice()
            {
                // Arrange: create test options with all needed product types
                var options = Options.Create(new ProductPricingOptions
                {
                    Individual = new Dictionary<ProductType, decimal>
            {
                { ProductType.HighEndPhone, 2000 },
                { ProductType.MidRangePhone, 550 }
            },
                    Professional = new ProfessionalPricing
                    {
                        Above10M = new Dictionary<ProductType, decimal>
                {
                    { ProductType.HighEndPhone, 1900 },
                    { ProductType.MidRangePhone, 500 }
                },
                        Below10M = new Dictionary<ProductType, decimal>
                {
                    { ProductType.HighEndPhone, 2100 },
                    { ProductType.MidRangePhone, 600 }
                }
                    }
                });

                var pricingPolicy = new ConfigProductPricingPolicy(options);

                var client = new IndividualClient(Guid.NewGuid(), "John", "Doe");

                // Act
                var highEndPrice = pricingPolicy.GetUnitPrice(client, ProductType.HighEndPhone);
                var midRangePrice = pricingPolicy.GetUnitPrice(client, ProductType.MidRangePhone);

                // Assert
                Assert.Equal(2000, highEndPrice);
                Assert.Equal(550, midRangePrice);
            }

            [Fact]
            public void GetUnitPrice_ProfessionalClient_ReturnsCorrectPrice()
            {
                var options = Options.Create(new ProductPricingOptions
                {
                    Individual = new Dictionary<ProductType, decimal>
            {
                { ProductType.HighEndPhone, 2000 },
                { ProductType.MidRangePhone, 550 }
            },
                    Professional = new ProfessionalPricing
                    {
                        Above10M = new Dictionary<ProductType, decimal>
                {
                    { ProductType.HighEndPhone, 1900 },
                    { ProductType.MidRangePhone, 500 }
                },
                        Below10M = new Dictionary<ProductType, decimal>
                {
                    { ProductType.HighEndPhone, 2100 },
                    { ProductType.MidRangePhone, 600 }
                }
                    }
                });

                var pricingPolicy = new ConfigProductPricingPolicy(options);

                var client = new ProfessionalClient(Guid.NewGuid(), "Acme Corp", 15_000_000);

                var highEndPrice = pricingPolicy.GetUnitPrice(client, ProductType.HighEndPhone);
                var midRangePrice = pricingPolicy.GetUnitPrice(client, ProductType.MidRangePhone);

                Assert.Equal(1900, highEndPrice); // Above10M tier
                Assert.Equal(500, midRangePrice);
            }
        }
    }
}
