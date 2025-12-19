using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Clients
{
    public sealed class IndividualClient : Client
    {
        public string FirstName { get; }
        public string LastName { get; }

        public IndividualClient(Guid id, string firstName, string lastName)
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
