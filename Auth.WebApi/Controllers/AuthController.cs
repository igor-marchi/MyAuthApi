using Auth.Core.Shared.InputModels.User;
using Auth.Infra.Interface.Manager;
using Auth.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Auth.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : MainController
    {
        private readonly IUserManager userManager;

        public AuthController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult<string>> AuthAsync([FromBody] AuthUser authUser)
        {
            var token = await userManager.GenerateTokenAsync(authUser);
            if (token == null)
                return NotFound("Usuário ou senha inválidos");

            return Ok(token);
        }
    }
}