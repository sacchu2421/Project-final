using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping_Cart.Models;
using Shopping_Cart.Repository;

namespace Shopping_Cart.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        public readonly IOrderRepository repository;

        public OrderController(IOrderRepository repo)
        {
            repository = repo;
        }
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            return Ok(repository.GetAllOrders());
        }
        [HttpDelete]
        public IActionResult DeleteOrderById(int id)
        {
            return Ok(repository.DeleteOrder(id));
        }
        [HttpPut]
        public IActionResult UpdateOrderById(int id, Order order)
        {
            return Ok(repository.UpdateOrder(id, order));
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(repository.GetOrderById(id));
        }
        [HttpPost]
        public IActionResult CreateOrders(Order order)
        {
            return Ok(repository.CreateOrder(order));
        }
    }
}
