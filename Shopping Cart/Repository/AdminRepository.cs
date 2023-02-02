using Shopping_Cart.DataAccessLayer;
using Shopping_Cart.Models;

namespace Shopping_Cart.Repository
{
    public class AdminRepository:IAdminRepository

    {
        public ShoppingCartContext shoppingContext;

        public AdminRepository(ShoppingCartContext shoppingContext)
        {
            this.shoppingContext = shoppingContext;
        }

        public IEnumerable<Admin> GetAdmin()
        {
            return shoppingContext.Admins.ToList();
        }
        public Admin GetById(int id)
        {
            return shoppingContext.Admins.Find(id);
        }
    }
}
