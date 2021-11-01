using Auth.Core.Shared.InputModels.User;
using Auth.Core.Shared.RabbitMq;
using Auth.Core.Shared.ViewModels.User;
using Auth.Infra.Interface.Manager;
using Auth.Infra.Interface.Services;
using Auth.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly IPublishService publishService;

        public UserController(IUserManager userManager, IPublishService publishService)
        {
            this.userManager = userManager;
            this.publishService = publishService;
        }

        /// <summary>
        /// Busca todos os clientes cadastrados
        /// </summary>
        /// <returns>Retorna uma lista dos clientes cadastrados</returns>
        //[Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(UserView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
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

            var emailData = new EmailData
            {
                EmailAddress = user.Email,
                Content = "Seu usuário foi criado"
            };
            
            _ = publishService.PublishEmailService(emailData);

            return Ok(user);
        }
    }
}