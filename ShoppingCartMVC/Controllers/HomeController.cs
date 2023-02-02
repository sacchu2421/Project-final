using Microsoft.AspNetCore.Mvc;
using ShoppingCartMVC.Models;
using System.Diagnostics;

namespace ShoppingCartMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

      
        public IActionResult Logins()
        {
            return View();
        }
        public IActionResult Login(User user)
        {
                HttpClient client;
                HttpResponseMessage response;
                UserBusinessLayer ubl = new UserBusinessLayer();
                client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5113/");
                response = client.GetAsync("api/User/GetAllUserss").Result;
                var userRead = response.Content.ReadFromJsonAsync<IEnumerable<User>>().Result;
                foreach (User c in userRead)
                {
                    if ((c.UserName == user.UserName) && (c.Password == user.Password))
                    {
                          ubl.User(c.UserId);
                    return RedirectToAction("GetAllProducts", "Product");
                     }
                }



            ModelState.AddModelError("Credentails Error", "Invalid UserName or Password");

            return View("Logins");
        }



            
        
        public IActionResult Register()
        {
            return View();

        }

        public IActionResult Registeration(User user)
        {
            HttpClient client;
            HttpResponseMessage response;
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5113/");
            User usr = new User();
            usr.UserName = user.UserName;
            usr.Address = user.Address;
            usr.Password = user.Password;
            usr.Phone = user.Phone;
            response = client.PostAsJsonAsync("api/User/CreateUser",usr).Result;

            return RedirectToAction("Logins");
        }

       
         
public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}