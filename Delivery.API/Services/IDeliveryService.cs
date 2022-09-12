namespace Delivery.API.Services
{
    public interface IDeliveryService
    {
        void PrepareOrder(Order order);

        void CancelOrder(Order order);

        void DeliverOrder(Order order);
    }

    public class DeliveryService : IDeliveryService
    {
        public void CancelOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void DeliverOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void PrepareOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
