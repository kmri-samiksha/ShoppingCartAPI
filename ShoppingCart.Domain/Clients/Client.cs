using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Clients
{
    public abstract class Client
    {
        public Guid ClientId { get; }

        protected Client(Guid clientId)
        {
            ClientId = clientId;
        }
    }
}
