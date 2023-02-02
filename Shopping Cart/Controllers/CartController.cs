using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping_Cart.Models;
using Shopping_Cart.Repository;

namespace Shopping_Cart.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        public readonly ICartRepository repository;

        public CartController(ICartRepository repo)
        {
            repository = repo;
        }
        [HttpGet]
        public IActionResult GetAllCarts()
        {
            return Ok(repository.GetAll());
        }
        [HttpPost]
        public IActionResult CreateCart(Cart cart)
        {
           return Ok(repository.AddCart(cart));
        }
        [HttpGet("{id}")]
        public IActionResult GetCartsById(int id)
        {
            return Ok(repository.GetCartsByUserId(id));
        }
        [HttpDelete]
        public IActionResult DeleteCartById(int id)
        {
            return Ok(repository.DeleteCart(id));
        }
        [HttpGet("{id}")]
        public IActionResult GetCartById(int id)
        {
            return Ok(repository.GetCart(id));
        }
    }
}
