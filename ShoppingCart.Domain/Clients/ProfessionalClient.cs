//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace ShoppingCart.Domain.Clients
{
    public sealed class ProfessionalClient : Client
    {
        public string CompanyName { get; }
        public decimal AnnualRevenue { get; }

        public ProfessionalClient(Guid id, string companyName, decimal annualRevenue)
            : base(id)
        {
            CompanyName = companyName;
            AnnualRevenue = annualRevenue;
        }
    }
}
