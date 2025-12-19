using ShoppingCart.Domain.Clients;
using ShoppingCart.Domain.Pricing;
using ShoppingCart.Domain.Products;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace ShoppingCart.Tests
{

    public class PricingTests
    {
        public class PriceCalculatorTests
        {
            [Fact]
            public void IndividualClient_Has_Correct_Prices()
            {
                var client = new IndividualClient(Guid.NewGuid(), "John", "Doe");

                var price = PriceCalculator.GetUnitPrice(client, ProductType.HighEndPhone);

                Assert.Equal(1500, price);
            }

            [Fact]
            public void Professional_With_High_Revenue_Gets_Discount()
            {
                var client = new ProfessionalClient(Guid.NewGuid(), "Corp", 15_000_000);

                var price = PriceCalculator.GetUnitPrice(client, ProductType.Laptop);

                Assert.Equal(900, price);
            }
        }
    }
}
