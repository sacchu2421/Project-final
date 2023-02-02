using Shopping_Cart.Models;

namespace Shopping_Cart.Repository
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAllUsers();
        public User GetUserById(int id);
        public bool DeleteUser(int id);
        public bool UpdateUser(int id,  User user);
        public bool AddUser(User user);
    }
}
