using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping_Cart.Models;
using Shopping_Cart.Repository;

namespace Shopping_Cart.Controllers
{ 
        [Route("api/[controller]/[action]")]
        [ApiController]
        public class ProductController : ControllerBase
        {
            public IProductRepository repo;
            public ProductController(IProductRepository repository)
            {
                repo = repository;
            }
            [HttpGet]
            public  IActionResult GetAll()
            {
                return Ok(repo.GetAllProducts());
            }
            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                return Ok(repo.GetProductById(id));
            }


            [HttpPost]
            public IActionResult CreateProduct(Product product)
            {
                return Ok(repo.AddProduct(product));
            }

            [HttpPut("{id}")]
            public IActionResult UpdateProductById(int id, Product product)
            {
                return Ok(repo.UpdateProduct(id, product));
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteProductById(int id)
            {
                return Ok(repo.DeleteProduct(id));
            }
            [HttpGet]
            public IActionResult SortByIncreasingPrice()
            {
                return Ok(repo.SortingByPrice());
            }
            [HttpGet]
            public IActionResult SortByCategory(string ProductCategory)
            {
                return Ok(repo.SortingByCategory(ProductCategory));
            }

        }
    }

