using Shopping_Cart.Models;

namespace Shopping_Cart.Repository
{
    public interface ICartRepository
    {
        public Cart AddCart(Cart cart);
        public bool DeleteCart(int id);
        public Cart GetCart(int id);
        public IEnumerable<Cart> GetCartsByUserId(int id);
        public IEnumerable<Cart> GetAll();
    }
}
