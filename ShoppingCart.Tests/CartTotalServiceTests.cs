using ShoppingCart.Application.Services;
using ShoppingCart.Domain.Clients;
using ShoppingCart.Domain.Products;
using ShoppingCart.Domain.ShoppingCart;
using Xunit;

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


namespace ShoppingCart.Tests
{
    public class CartTotalServiceTests
    {
        [Fact]
        public void Calculates_Total_Correctly()
        {
            var client = new IndividualClient(Guid.NewGuid(), "Jane", "Doe");

            var items = new List<CartItem>
        {
            new(ProductType.HighEndPhone, 1),
            new(ProductType.MidRangePhone, 2)
        };

            var service = new CartTotalService();

            var total = service.CalculateTotal(client, items);

            Assert.Equal(3100, total);

            // Assert.Equal(4600, total);
        }

        //[Fact]
        //public void Calculates_Total_Correctly()
        //{
        //    var client = new IndividualClient(Guid.NewGuid(), "Jane", "Doe");

        //    var items = new List<CartItem>
        //{
        //    new(ProductType.HighEndPhone, 1),
        //    new(ProductType.MidRangePhone, 2)
        //};

        //    var service = new CartTotalService();
        //    var total = service.CalculateTotal(client, items);

        //    Assert.Equal(4600, total);
        //}
    }
}
