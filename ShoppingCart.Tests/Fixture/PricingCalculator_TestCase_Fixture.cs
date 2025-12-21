using Microsoft.Extensions.Options;
using ShoppingCart.Domain.Clients;
using ShoppingCart.Domain.Products;
using ShoppingCart.Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Tests.Fixture
{
    public class PricingCalculator_TestCase_Fixture
    {      
        public ConfigProductPricingPolicy PricingPolicyIndividual { get; }
        public ConfigProductPricingPolicy PricingPolicyProfessional { get; }
   

    public PricingCalculator_TestCase_Fixture()
    {       
        var individualOptions = Options.Create(new ProductPricingOptions
        {
            Individual = new Dictionary<ProductType, decimal>
                {
                    { ProductType.HighEndPhone, 1500 },
                    { ProductType.MidRangePhone, 800 },
                    { ProductType.Laptop, 1200 }
                }
        });

        PricingPolicyIndividual = new ConfigProductPricingPolicy(individualOptions);

        // Professional client pricing options
        var professionalOptions = Options.Create(new ProductPricingOptions
        {
            Professional = new ProfessionalPricing
            {
                Above10M = new Dictionary<ProductType, decimal>
                    {
                        { ProductType.HighEndPhone, 1000 },
                        { ProductType.MidRangePhone, 550 },
                        { ProductType.Laptop, 900 }
                    },
                Below10M = new Dictionary<ProductType, decimal>
                    {
                        { ProductType.HighEndPhone, 1150 },
                        { ProductType.MidRangePhone, 600 },
                        { ProductType.Laptop, 1000 }
                    },
                ProfessionalRevenueThreshold = 10_000_000
            }
            
        });

        PricingPolicyProfessional = new ConfigProductPricingPolicy(professionalOptions);
    }


        public static IEnumerable<object[]> IndividualClientTestData =>
             new List<object[]>
             {
                new object[] { new IndividualClient(Guid.NewGuid(), "John", "Doe"), ProductType.HighEndPhone, 1500m },
                new object[] { new IndividualClient(Guid.NewGuid(), "John", "Doe"), ProductType.MidRangePhone, 800m },
                new object[] { new IndividualClient(Guid.NewGuid(), "John", "Doe"), ProductType.Laptop, 1200m }
             };

        public static IEnumerable<object[]> ProfessionalClientTestData =>
           
           new List<object[]>
           {
                new object[] { new ProfessionalClient(Guid.NewGuid(), "Acme Corp", 15_000_000), ProductType.HighEndPhone, 1000m },
                new object[] { new ProfessionalClient(Guid.NewGuid(), "Acme Corp", 15_000_000), ProductType.MidRangePhone, 550m },
                new object[] { new ProfessionalClient(Guid.NewGuid(), "Acme Corp", 15_000_000), ProductType.Laptop, 900m },
                new object[] { new ProfessionalClient(Guid.NewGuid(), "Acme Corp", 9_000_000), ProductType.HighEndPhone, 1150m },
                new object[] { new ProfessionalClient(Guid.NewGuid(), "Acme Corp", 9_000_000), ProductType.MidRangePhone, 600m },
                new object[] { new ProfessionalClient(Guid.NewGuid(), "Acme Corp", 9_000_000), ProductType.Laptop, 1000m }
           };
    }
}

