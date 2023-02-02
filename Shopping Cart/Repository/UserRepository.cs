using Shopping_Cart.DataAccessLayer;
using Shopping_Cart.Models;

namespace Shopping_Cart.Repository
{
    public class UserRepository:IUserRepository
    {
        public readonly ShoppingCartContext shopping;

        public UserRepository(ShoppingCartContext shoppingContext)
        {
            this.shopping = shoppingContext;
        }
        public IEnumerable<User> GetAllUsers()
        {
            var query = (from user in shopping.Users
                         select user).ToList();
            return query;

        }
        public User GetUserById(int id)
        {
            User customer = shopping.Users.Find(id);
            return customer;
        }

        public bool AddUser(User users)
        {
            User user = new User();
            user.UserName = users.UserName;
            user.Address = users.Address;
            user.Phone = users.Phone;
            user.Password = users.Password;
            shopping.Users.Add(users);
            shopping.SaveChanges();
            return true;
        }
        public bool DeleteUser(int id)
        {
            User user = shopping.Users.Find(id);
            shopping.Users.Remove(user);
            shopping.SaveChanges();
            return true;
        }
        public bool UpdateUser(int id, User user)
        {
            User custom = shopping.Users.Find(id);
            custom.Phone = user.Phone;
            custom.UserName = user.UserName;
            custom.Address = user.Address;
            custom.Password = user.Password;
            shopping.Update(custom);
            return true;
        }

    }
}
