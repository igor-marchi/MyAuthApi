using Auth.Core.Shared.ViewModels.User;
using Auth.Infra.Interface.Manager;
using Auth.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Auth.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : MainController
    {
        private readonly IUserManager userManager;

        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<UserView>> GetAll()
        {
            var users = await userManager.GetAllUsersAsync();

            if (users == null)
                return BadRequest();

            return Ok(users);
        }
    }
}