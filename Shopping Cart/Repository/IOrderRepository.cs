using Shopping_Cart.Models;

namespace Shopping_Cart.Repository
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> GetAllOrders();
        public Order GetOrderById(int id);
        public bool UpdateOrder(int id, Order order);
        public bool DeleteOrder(int id);
        public Order CreateOrder(Order order);
    }
}
