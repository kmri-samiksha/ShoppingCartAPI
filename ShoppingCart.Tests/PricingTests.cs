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

                Assert.Equal(2000, price);
            }

            [Fact]
            public void Professional_With_High_Revenue_Gets_Discount()
            {
                var client = new ProfessionalClient(Guid.NewGuid(), "Corp", 20_000_000);

                var price = PriceCalculator.GetUnitPrice(client, ProductType.Laptop);

                Assert.Equal(1400, price);
            }
        }




        //[Fact]
        //public void IndividualClient_Pricing_Is_Correct()
        //{
        //    var client = new IndividualClient(Guid.NewGuid(), "John", "Doe");

        //    Assert.Equal(2000, PriceCalculator.GetUnitPrice(client, ProductType.HighEndPhone));
        //    Assert.Equal(1300, PriceCalculator.GetUnitPrice(client, ProductType.MidRangePhone));
        //    Assert.Equal(1700, PriceCalculator.GetUnitPrice(client, ProductType.Laptop));
        //}

        //[Fact]
        //public void Professional_HighRevenue_Pricing_Is_Correct()
        //{
        //    var client = new ProfessionalClient(Guid.NewGuid(), "Corp", 20_000_000);

        //    Assert.Equal(1500, PriceCalculator.GetUnitPrice(client, ProductType.HighEndPhone));
        //    Assert.Equal(1050, PriceCalculator.GetUnitPrice(client, ProductType.MidRangePhone));
        //    Assert.Equal(1400, PriceCalculator.GetUnitPrice(client, ProductType.Laptop));
        //}
    }
}
