using Moq;
using Xunit;
using ShoppingCart.Application.Services;
using ShoppingCart.Domain.Clients;
using ShoppingCart.Domain.Interface;
using ShoppingCart.Domain.Products;
using Microsoft.Extensions.Options;
using ShoppingCart.Infrastructure.Service;
using ShoppingCart.Domain.ShoppingCart;
using Xunit.Abstractions;

public class CartTotalServiceTests
{
   [Fact]
    public async Task GetUnitPrice_ReturnsExpectedPrice_ForIndividualClient()
    {

        var pricingPolicyMock = new Mock<IProductPricingPolicy>();

        var client = new IndividualClient(Guid.NewGuid(), "John", "Doe");

        pricingPolicyMock
            .Setup(p => p.GetUnitPrice(client, ProductType.HighEndPhone))
            .Returns(1500);

        pricingPolicyMock
            .Setup(p => p.GetUnitPrice(client, ProductType.MidRangePhone))
            .Returns(800);
        pricingPolicyMock
           .Setup(p => p.GetUnitPrice(client, ProductType.Laptop))
           .Returns(1200);

        var cartItems = new List<CartItem>
            {
                new CartItem(ProductType.HighEndPhone, quantity: 2),
                new CartItem(ProductType.MidRangePhone, quantity: 3),
                new CartItem(ProductType.Laptop, quantity: 1)
            };

        var service = new CartTotalService(pricingPolicyMock.Object);

        var total = await service.CalculateTotalAsync(client, cartItems);

        Assert.Equal(6600, total);

        pricingPolicyMock.Verify(
            p => p.GetUnitPrice(client, ProductType.HighEndPhone),
            Times.Once);

        pricingPolicyMock.Verify(
            p => p.GetUnitPrice(client, ProductType.MidRangePhone),
            Times.Once);

    }

    [Fact]
    public async Task GetUnitPrice_ReturnsExpectedPrice_ForProfessionalClient_Above10M()
    {
       
            var pricingPolicyMock = new Mock<IProductPricingPolicy>();

        var client = new ProfessionalClient(Guid.NewGuid(), "Acme Corp", 15_000_000);

        pricingPolicyMock
                .Setup(p => p.GetUnitPrice(client, ProductType.HighEndPhone))
                .Returns(1000);

            pricingPolicyMock
                .Setup(p => p.GetUnitPrice(client, ProductType.MidRangePhone))
                .Returns(550);

        pricingPolicyMock
                .Setup(p => p.GetUnitPrice(client, ProductType.Laptop))
                .Returns(900);

        var cartItems = new List<CartItem>
            {
                new CartItem(ProductType.HighEndPhone, quantity: 2),
                new CartItem(ProductType.MidRangePhone, quantity: 3),
                new CartItem(ProductType.Laptop, quantity: 1)
            };

            var service = new CartTotalService(pricingPolicyMock.Object);

            var total = await service.CalculateTotalAsync(client, cartItems);

            Assert.Equal(4550, total);

            pricingPolicyMock.Verify(
                p => p.GetUnitPrice(client, ProductType.HighEndPhone),
                Times.Once);

            pricingPolicyMock.Verify(
                p => p.GetUnitPrice(client, ProductType.MidRangePhone),
                Times.Once);
        
    }

    [Fact]
    public async Task GetUnitPrice_ReturnsExpectedPrice_ForProfessionalClient_Below10M()
    {

        var pricingPolicyMock = new Mock<IProductPricingPolicy>();

        var client = new ProfessionalClient(Guid.NewGuid(), "Acme Corp", 9_000_000);

        pricingPolicyMock
                .Setup(p => p.GetUnitPrice(client, ProductType.HighEndPhone))
                .Returns(1150);

        pricingPolicyMock
            .Setup(p => p.GetUnitPrice(client, ProductType.MidRangePhone))
            .Returns(600);

        pricingPolicyMock
                .Setup(p => p.GetUnitPrice(client, ProductType.Laptop))
                .Returns(1000);

        var cartItems = new List<CartItem>
            {
                new CartItem(ProductType.HighEndPhone, quantity: 2),
                new CartItem(ProductType.MidRangePhone, quantity: 3),
                new CartItem(ProductType.Laptop, quantity: 1)
            };

        var service = new CartTotalService(pricingPolicyMock.Object);

        var total = await service.CalculateTotalAsync(client, cartItems);
        Assert.Equal(5100, total);

        pricingPolicyMock.Verify(
            p => p.GetUnitPrice(client, ProductType.HighEndPhone),
            Times.Once);

        pricingPolicyMock.Verify(
            p => p.GetUnitPrice(client, ProductType.MidRangePhone),
            Times.Once);

    }

}
