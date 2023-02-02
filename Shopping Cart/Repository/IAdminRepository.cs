using Shopping_Cart.Models;

namespace Shopping_Cart.Repository
{
    public interface IAdminRepository
    {
        public IEnumerable<Admin> GetAdmin();
        public Admin GetById(int id);
    }
}
