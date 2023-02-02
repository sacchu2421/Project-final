using Microsoft.AspNetCore.Mvc;
using ShoppingCartMVC.Models;
using ShoppingCartMVC.ViewModel;

namespace ShoppingCartMVC.Controllers
{
    public class CartController : Controller
    {
        UserBusinessLayer userBusinessLayer = new UserBusinessLayer();
       // ProductViewModel pvm = new ProductViewModel();
        List<Product> product = new List<Product>();
        List<Product> product1 = new List<Product>();
        List<Cart> cart = new List<Cart>();
        List<Order> orders = new List<Order>();
        public IActionResult Index()
        {
            return View();
        }
       
      
        public IActionResult AddToCart(int id)
        {
            HttpClient client;
            HttpResponseMessage response;
            client = new HttpClient();
            Order order1 = new Order();
            order1.ProductId = id;
            client.BaseAddress = new Uri("http://localhost:5113/");
            response = client.PostAsJsonAsync("api/Order/CreateOrders/", order1).Result;
            var order = response.Content.ReadFromJsonAsync<Order>().Result;
            Cart cart = new Cart();
      
            cart.OrderId = order.OrderId;
            cart.UserId = userBusinessLayer.ReturnUserId();
            response = client.PostAsJsonAsync("api/Cart/CreateCart/", cart).Result;
            return RedirectToAction("GetAllProducts","Product");

        }

        public IActionResult MyCart()
        {
            UserBusinessLayer ubl = new UserBusinessLayer();
           
            HttpClient client;
            HttpResponseMessage response;
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5113/");
            response = client.GetAsync("api/Cart/GetCartsById/"+ubl.ReturnUserId()).Result;
            var carts = response.Content.ReadAsAsync<IEnumerable<Cart>>().Result;

            foreach (Cart c in carts)
            {
                Order o = new Order();
                o.OrderId = c.OrderId;
             //   int id = o.ProductId;
                orders.Add(o);     
            }
            //orderss = orders;
            foreach (Order order in orders)
            {
                response = client.GetAsync("api/Order/GetById/" + order.OrderId).Result;
                var orderss = response.Content.ReadFromJsonAsync<Order>().Result;
                if (orderss != null)
                {
                    Product p = new Product();
                    p.ProductId = orderss.ProductId;
                    product.Add(p);
                }
            }
                foreach(Product p in product)
                {
                    response = client.GetAsync("api/Product/GetById/" + p.ProductId).Result;
                    var pro = response.Content.ReadFromJsonAsync<Product>().Result;
                    if (pro != null)
                    {
                        Product p2 = new Product();
                        p2.ProductId = pro.ProductId;
                        p2.ProductName = pro.ProductName;
                        p2.Productprice = pro.Productprice;
                        p2.ProductImage = pro.ProductImage;
                        p2.ProductDescription = pro.ProductDescription;
                        p2.ProductCategory = pro.ProductCategory;
                        product1.Add(p2);
                    }
                }
                
               // pvm.products = product;

            
            return View(product1);
        }

        public IActionResult BuyNow()
        {
            return View();
        }

    }
}
