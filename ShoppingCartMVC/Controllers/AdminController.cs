using Microsoft.AspNetCore.Mvc;
using ShoppingCartMVC.Models;
using ShoppingCartMVC.ViewModel;

namespace ShoppingCartMVC.Controllers
{
  public class AdminController : Controller
    {
        UserViewModel uvm = new UserViewModel();
        ProductViewModel pvm = new ProductViewModel();
        List<Product> products1 = new List<Product>();
        List<User> users1 =new List<User>();
        public IActionResult Admin()
        {
            return View();
        }
       public IActionResult Admins(Admin admn)
       {
           
              HttpClient client;
              HttpResponseMessage response;
              //  List<Customer> customer1 = new List<Customer>();
              AdminBusinessLayer abl = new AdminBusinessLayer();
              client = new HttpClient();
              client.BaseAddress = new Uri("http://localhost:5113/");
              response = client.GetAsync("api/Admin/GetAdmins").Result;
              var cust = response.Content.ReadFromJsonAsync<IEnumerable<Admin>>().Result;
              foreach (Admin admin in cust)
              {
                if ((admin.Email == admn.Email) && (admin.Password == admn.Password))
                {
                    return RedirectToAction("AdminPage", new { id = 1 }); ;

                }
            }
          

              ModelState.AddModelError("Credentails Error", "Invalid UserName or Password");

             return View("Admin");
 
       }
     
      
        public IActionResult AdminPage(int id)
        {
            HttpClient client;
            HttpResponseMessage response;
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5113/");
            AdminBusinessLayer abl = new AdminBusinessLayer();
           
            response = client.GetAsync("api/Admin/GetAdminById/"+ id).Result;
            Admin admin = response.Content.ReadAsAsync<Admin>().Result;
            return View(admin);
        }


        public IActionResult UpdateProduct()
        {
            return View();
        }

        public IActionResult UpdateProductById(int ProductId ,Product product)
        {
            HttpClient client;
            HttpResponseMessage response;
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5113/");
            response = client.GetAsync("api/Product/GetById/"+ProductId).Result;
            Product prod = response.Content.ReadAsAsync<Product>().Result;
            prod.ProductCategory = product.ProductCategory;
            prod.Productprice = product.Productprice;
            prod.ProductName = product.ProductName;
            prod.ProductImage = product.ProductImage;
            prod.ProductDescription = product.ProductDescription;
            response = client.PutAsJsonAsync("api/Product/UpdateProductById/"+ProductId,prod).Result;
            return RedirectToAction("GetProducts");

        }

        public IActionResult GetAllUserDetails()
        {
            HttpClient client;
            HttpResponseMessage response;
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5113/");
            response = client.GetAsync("api/User/GetAllUserss/").Result;
            var users = response.Content.ReadFromJsonAsync<IEnumerable<User>>().Result;
            foreach (var u in users)
            {
               // User usr = new User();
                
                users1.Add(u);
            }
            uvm.users = users1;
            return View(uvm);


        }
        public IActionResult CreateProduct()
        {
            return View();
        }
        public IActionResult CreateProducts(Product pro)
        {
            HttpClient client;
            HttpResponseMessage response;
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5113/");
            Product product = new Product();
            product.ProductId = pro.ProductId;
            product.ProductName = pro.ProductName;
            product.Productprice = pro.Productprice;
            product.ProductImage = pro.ProductImage;
            product.ProductDescription = pro.ProductDescription;
            product.ProductCategory = pro.ProductCategory;
            response = client.PostAsJsonAsync("api/Product/CreateProduct/", product).Result;
           // var prod = response.Content.ReadFromJsonAsync<Product>().Result;
            return RedirectToAction("GetProducts");

        }
        public IActionResult GetProducts()
        {
            HttpClient client;
            HttpResponseMessage response;
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5113/");
            response = client.GetAsync("api/Product/GetAll/").Result;
            var products = response.Content.ReadFromJsonAsync<IEnumerable<Product>>().Result;
            foreach (var p in products)
            {
                Product prod = new Product();
                prod.ProductId = p.ProductId;
                prod.ProductName = p.ProductName;
                prod.Productprice = p.Productprice;
                prod.ProductImage = p.ProductImage;
                prod.ProductDescription = p.ProductDescription;
                prod.ProductCategory = p.ProductCategory;
                products1.Add(prod);
            }
            pvm.products = products1;
            return View(pvm);


        }
        public IActionResult DeleteProduct()
        {
            return View();
        }
        
        public IActionResult DeleteProducts(int ProductId)
        {
            HttpClient client;
            HttpResponseMessage response;
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5113/");
            response = client.DeleteAsync("api/Product/DeleteProductById/" + ProductId).Result;
            return RedirectToAction("GetProducts");

        }
    }
}
