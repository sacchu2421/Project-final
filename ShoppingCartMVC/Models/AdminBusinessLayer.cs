namespace ShoppingCartMVC.Models
{
    public class AdminBusinessLayer
    {
            static int id;
            public void Admin(int adminid)
            {
                id = adminid;

            }
            public int ReturnAdminId()
            {
                return id;
            }
        }
    }

