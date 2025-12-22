
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
