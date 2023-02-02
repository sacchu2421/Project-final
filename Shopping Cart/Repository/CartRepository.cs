using Shopping_Cart.DataAccessLayer;
using Shopping_Cart.Models;

namespace Shopping_Cart.Repository
{
    public class CartRepository:ICartRepository
    {
        public ShoppingCartContext shoppingContext;

        public CartRepository(ShoppingCartContext shoppingContext)
        {
            this.shoppingContext = shoppingContext;
        }

        public Cart AddCart(Cart cart)
        {
             shoppingContext.Add(cart);
            shoppingContext.SaveChanges();
            return cart;
        }
        public bool DeleteCart(int id)
        {
            Cart cart = shoppingContext.Carts.Find(id);
            shoppingContext.Carts.Remove(cart);
            shoppingContext.SaveChanges();
            return true;
        }
        public IEnumerable<Cart> GetCartsByUserId(int id)
        {
            var query = (from cart in shoppingContext.Carts
                        where cart.UserId == id select cart).ToList();

            return query;
        }


        public IEnumerable<Cart> GetAll()
        {
            return shoppingContext.Carts;
        }

        public Cart GetCart(int id)
        {
            Cart cart = shoppingContext.Carts.Find(id);
            return cart;
        }


    }
}
