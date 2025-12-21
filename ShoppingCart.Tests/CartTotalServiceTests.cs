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
using ShoppingCart.Tests.Fixture;

public class CartTotalServiceTests : IClassFixture<PricingCalculator_TestCase_Fixture>
{
    private readonly PricingCalculator_TestCase_Fixture _fixture;

    public CartTotalServiceTests(PricingCalculator_TestCase_Fixture fixture)
    {
        _fixture = fixture;
    }

    //[Fact]
    //public async Task GetUnitPrice_ReturnsExpectedPrice_ForIndividualClient()
    //{

    //    var pricingPolicyMock = new Mock<IProductPricingPolicy>();

    //    var client = new IndividualClient(Guid.NewGuid(), "John", "Doe");

    //    pricingPolicyMock
    //        .Setup(p => p.GetUnitPrice(client, ProductType.HighEndPhone))
    //        .Returns(1500);

    //    pricingPolicyMock
    //        .Setup(p => p.GetUnitPrice(client, ProductType.MidRangePhone))
    //        .Returns(800);
    //    pricingPolicyMock
    //       .Setup(p => p.GetUnitPrice(client, ProductType.Laptop))
    //       .Returns(1200);

    //    var cartItems = new List<CartItem>
    //        {
    //            new CartItem(ProductType.HighEndPhone, quantity: 2),
    //            new CartItem(ProductType.MidRangePhone, quantity: 3),
    //            new CartItem(ProductType.Laptop, quantity: 1)
    //        };

    //    var service = new CartTotalService(pricingPolicyMock.Object);

    //    var total = await service.CalculateTotalAsync(client, cartItems);

    //    Assert.Equal(6600, total);

    //    pricingPolicyMock.Verify(
    //        p => p.GetUnitPrice(client, ProductType.HighEndPhone),
    //        Times.Once);

    //    pricingPolicyMock.Verify(
    //        p => p.GetUnitPrice(client, ProductType.MidRangePhone),
    //        Times.Once);

    //}

    //[Fact]
    //public async Task GetUnitPrice_ReturnsExpectedPrice_ForProfessionalClient_Above10M()
    //{
       
    //        var pricingPolicyMock = new Mock<IProductPricingPolicy>();

    //    var client = new ProfessionalClient(Guid.NewGuid(), "Acme Corp", 15_000_000);

    //    pricingPolicyMock
    //            .Setup(p => p.GetUnitPrice(client, ProductType.HighEndPhone))
    //            .Returns(1000);

    //        pricingPolicyMock
    //            .Setup(p => p.GetUnitPrice(client, ProductType.MidRangePhone))
    //            .Returns(550);

    //    pricingPolicyMock
    //            .Setup(p => p.GetUnitPrice(client, ProductType.Laptop))
    //            .Returns(900);

    //    var cartItems = new List<CartItem>
    //        {
    //            new CartItem(ProductType.HighEndPhone, quantity: 2),
    //            new CartItem(ProductType.MidRangePhone, quantity: 3),
    //            new CartItem(ProductType.Laptop, quantity: 1)
    //        };

    //        var service = new CartTotalService(pricingPolicyMock.Object);

    //        var total = await service.CalculateTotalAsync(client, cartItems);

    //        Assert.Equal(4550, total);

    //        pricingPolicyMock.Verify(
    //            p => p.GetUnitPrice(client, ProductType.HighEndPhone),
    //            Times.Once);

    //        pricingPolicyMock.Verify(
    //            p => p.GetUnitPrice(client, ProductType.MidRangePhone),
    //            Times.Once);
        
    //}

    //[Fact]
    //public async Task GetUnitPrice_ReturnsExpectedPrice_ForProfessionalClient_Below10M()
    //{

    //    var pricingPolicyMock = new Mock<IProductPricingPolicy>();

    //    var client = new ProfessionalClient(Guid.NewGuid(), "Acme Corp", 9_000_000);

    //    pricingPolicyMock
    //            .Setup(p => p.GetUnitPrice(client, ProductType.HighEndPhone))
    //            .Returns(1150);

    //    pricingPolicyMock
    //        .Setup(p => p.GetUnitPrice(client, ProductType.MidRangePhone))
    //        .Returns(600);

    //    pricingPolicyMock
    //            .Setup(p => p.GetUnitPrice(client, ProductType.Laptop))
    //            .Returns(1000);

    //    var cartItems = new List<CartItem>
    //        {
    //            new CartItem(ProductType.HighEndPhone, quantity: 2),
    //            new CartItem(ProductType.MidRangePhone, quantity: 3),
    //            new CartItem(ProductType.Laptop, quantity: 1)
    //        };

    //    var service = new CartTotalService(pricingPolicyMock.Object);

    //    var total = await service.CalculateTotalAsync(client, cartItems);
    //    Assert.Equal(5100, total);

    //    pricingPolicyMock.Verify(
    //        p => p.GetUnitPrice(client, ProductType.HighEndPhone),
    //        Times.Once);

    //    pricingPolicyMock.Verify(
    //        p => p.GetUnitPrice(client, ProductType.MidRangePhone),
    //        Times.Once);

    //}




    [Theory]
    [MemberData(nameof(PricingCalculator_TestCase_Fixture.ProfessionalClientCartTotalTestData), MemberType = typeof(PricingCalculator_TestCase_Fixture))]

    //GetTotal_ProfessionalClient_ReturnsCorrectPrice
    public async Task GetTotal_ProfessionalClient_ReturnsCorrectPrice(
        ProfessionalClient client,
        List<CartItem> cartItems,
        decimal expectedTotal)
    {
        var pricingPolicy = _fixture.PricingPolicyProfessional;
        var service = new CartTotalService(pricingPolicy);

        var total = await service.CalculateTotalAsync(client, cartItems);

        Assert.Equal(expectedTotal, total);
    }


    [Theory]
    [MemberData(nameof(PricingCalculator_TestCase_Fixture.IndividualClientCartTotalTestData), MemberType = typeof(PricingCalculator_TestCase_Fixture))]
    public async Task GetTotal_IndividualClient_ReturnsCorrectPrice(
        IndividualClient client,
        List<CartItem> cartItems,
        decimal expectedTotal)
    {
        var pricingPolicy = _fixture.PricingPolicyIndividual;
        var service = new CartTotalService(pricingPolicy);

        var total = await service.CalculateTotalAsync(client, cartItems);

        Assert.Equal(expectedTotal, total);
    }

}
