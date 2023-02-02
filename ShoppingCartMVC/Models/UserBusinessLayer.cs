namespace ShoppingCartMVC.Models
{
    public class UserBusinessLayer
    {
            static int id;
            public void User(int userId)
            {
                id = userId;
            }
            public int ReturnUserId()
            {
                return id;
            }
        }
    }

