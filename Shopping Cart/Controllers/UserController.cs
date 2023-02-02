using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping_Cart.Models;
using Shopping_Cart.Repository;

namespace Shopping_Cart.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository repository;

        public UserController(IUserRepository repo)
        {
            repository = repo;
        }
        [HttpGet]
        public IActionResult GetAllUserss()
        {
            return Ok(repository.GetAllUsers());
        }
        [HttpDelete]
        public IActionResult DeleteCustomerById(int id)
        {
            return Ok(repository.DeleteUser(id));
        }
        [HttpPut]
        public IActionResult UpdateCustomerById(int id, User user)
        {
            return Ok(repository.UpdateUser(id, user));
        }
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(repository.GetUserById(id));
        }
        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            return Ok(repository.AddUser(user));
        }
    }
}
