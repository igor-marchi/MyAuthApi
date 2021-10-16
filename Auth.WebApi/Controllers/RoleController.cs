using Auth.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Auth.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RoleController : MainController
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }
    }
}