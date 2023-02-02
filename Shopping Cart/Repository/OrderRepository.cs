using Shopping_Cart.DataAccessLayer;
using Shopping_Cart.Models;

namespace Shopping_Cart.Repository
{
    public class OrderRepository:IOrderRepository
    {
        public readonly ShoppingCartContext shoppingContext;

        public OrderRepository(ShoppingCartContext _shoppingContext)
        {
            shoppingContext = _shoppingContext;
        }
        public bool DeleteOrder(int id)
        {
            Order order = shoppingContext.Orders.Find(id);
            shoppingContext.Orders.Remove(order);
            shoppingContext.SaveChanges();
            return true;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return shoppingContext.Orders;

        }

        public Order GetOrderById(int id)
        {
            Order order = shoppingContext.Orders.Find(id);
            return order;
        }
        public bool UpdateOrder(int id, Order order)
        {
            Order order1 = shoppingContext.Orders.Find(id);
           order1.ProductId = order.ProductId;
            shoppingContext.Orders.Update(order1);
            shoppingContext.SaveChanges();
            return true;

        }
    public Order CreateOrder(Order order)
    {
      //  Order order1 = new Order();
       // order1.ProductId = order.ProductId;
       // order1.ProductId = order.ProductId;
        shoppingContext.Add(order);
        shoppingContext.SaveChanges();
        return order;    
}

        }
}
