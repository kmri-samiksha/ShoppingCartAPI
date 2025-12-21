using Microsoft.Extensions.Options;
using Moq;
using ShoppingCart.Domain.Clients;
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
                { ProductType.HighEndPhone, 1500 },
                { ProductType.MidRangePhone, 800 },
                { ProductType.Laptop, 1200 }
            }
                });


                var pricingPolicy = new ConfigProductPricingPolicy(options);

                var client = new IndividualClient(Guid.NewGuid(), "John", "Doe");

                // Act
                var highEndPrice = pricingPolicy.GetUnitPrice(client, ProductType.HighEndPhone);
                var midRangePrice = pricingPolicy.GetUnitPrice(client, ProductType.MidRangePhone);
                var laptop = pricingPolicy.GetUnitPrice(client, ProductType.Laptop);

                // Assert
                Assert.Equal(1500, highEndPrice);
                Assert.Equal(800, midRangePrice);
                Assert.Equal(1200, laptop);
            }

            [Fact]
            public void GetUnitPrice_ProfessionalClient_ReturnsCorrectPrice()
            {
                var options = Options.Create(new ProductPricingOptions
                {        
                    Professional = new ProfessionalPricing
                    {
                        Above10M = new Dictionary<ProductType, decimal>
                {
                     { ProductType.HighEndPhone, 1000 },
                    { ProductType.MidRangePhone, 550 },
                    { ProductType.Laptop, 900 },
                },
                        Below10M = new Dictionary<ProductType, decimal>
                {
                    { ProductType.HighEndPhone, 1150 },
                    { ProductType.MidRangePhone, 600 },
                    { ProductType.Laptop, 1000 }
                }
                    }
                });

                var pricingPolicy = new ConfigProductPricingPolicy(options);

                var client = new ProfessionalClient(Guid.NewGuid(), "Acme Corp", 15_000_000);

                var highEndPrice = pricingPolicy.GetUnitPrice(client, ProductType.HighEndPhone);
                var midRangePrice = pricingPolicy.GetUnitPrice(client, ProductType.MidRangePhone);
                var laptop = pricingPolicy.GetUnitPrice(client, ProductType.Laptop);

                Assert.Equal(1000, highEndPrice); // Above10M tier
                Assert.Equal(550, midRangePrice);
                Assert.Equal(900, laptop);


                var clientBelow10M = new ProfessionalClient(Guid.NewGuid(), "Acme Corp", 9_000_000);

                var highEndPriceBelow10M = pricingPolicy.GetUnitPrice(clientBelow10M, ProductType.HighEndPhone);
                var midRangePriceBelow10M = pricingPolicy.GetUnitPrice(clientBelow10M, ProductType.MidRangePhone);
                var laptopBelow10M = pricingPolicy.GetUnitPrice(clientBelow10M, ProductType.Laptop);

                Assert.Equal(1150, highEndPriceBelow10M); // Below10M tier
                Assert.Equal(600, midRangePriceBelow10M);
                Assert.Equal(1000, laptopBelow10M);
            }
        }
    }
}
