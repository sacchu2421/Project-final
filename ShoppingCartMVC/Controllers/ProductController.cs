using Microsoft.AspNetCore.Mvc;
using ShoppingCartMVC.Models;
using ShoppingCartMVC.ViewModel;

namespace ShoppingCartMVC.Controllers
{
    public class ProductController : Controller
    {
        HttpClient client;
        HttpResponseMessage response;
        ProductViewModel pvm = new ProductViewModel();
        List<Product> products1 = new List<Product>();

        public IActionResult Index()
            {
                return View();
            }

            public IActionResult GetAllProducts()
            {
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

        public IActionResult SortByIncreasingPrice()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5113/");
            response = client.GetAsync("api/Product/SortByIncreasingPrice").Result;
            var products = response.Content.ReadFromJsonAsync<IEnumerable<Product>>().Result;
            foreach(Product p in products)
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

        public IActionResult SearchByCategory(string ProductCategory)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5113/");
            response = client.GetAsync("api/Product/SortByCategory?ProductCategory" + ProductCategory).Result;
            var products = response.Content.ReadFromJsonAsync<IEnumerable<Product>>().Result;
            foreach (Product p in products)
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
        }
}
