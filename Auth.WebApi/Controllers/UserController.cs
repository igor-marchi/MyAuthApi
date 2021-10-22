using Auth.Core.Shared.InputModels.User;
using Auth.Core.Shared.ViewModels.User;
using Auth.Infra.Interface.Manager;
using Auth.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserView>> GetAllAsync()
        {
            var users = await userManager.GetAllUsersAsync();

            if (!users.Any())
                return BadRequest("Nenhum usuário encontrado");

            return Ok(users);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserView>> GetUsersByIdAsync(int id)
        {
            var user = await userManager.GetUsersByIdAsync(id);

            if (user == null)
                return BadRequest("Usuário informado não existe");

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserView>> InsertUserAsync(NewUserInput newUserInput)
        {
            var user = await userManager.InsertUserAsync(newUserInput);

            if (user == null)
                return BadRequest("Email já cadastrado!");

            return Ok(user);
        }
    }
}