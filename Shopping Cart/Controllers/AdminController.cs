using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping_Cart.Repository;

namespace Shopping_Cart.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public readonly IAdminRepository repo;
        public AdminController(IAdminRepository repository)
        {
            repo = repository;
        }

        [HttpGet]
        public IActionResult GetAdmins()
        {
            return Ok(repo.GetAdmin());
        }
        [HttpGet("{id}")]
        public IActionResult GetAdminById(int id)
        {
            return Ok(repo.GetById(id));
        }
    }
}
