using JobCandidate.Aplication;
using JobCandidate.Application.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SigmaSoftware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Data Members
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;
        #endregion
        public AuthController(
            IAuthService authService,
            ILogger<AuthController> logger
            )
        {
            this._authService = authService;
            this._logger = logger;
        }
        [AllowAnonymous]
        [Route("user-login")]
        [HttpPost]
        public IActionResult LoginInternal(LoginViewModel model)
        {

            _logger.LogInformation($"{model.UserName} logging to the system");

            UserLoggedInViewModel user = this._authService.Login(model);
            if (user != null)
            {

                return Ok(user);
            }
            else
            {
                return BadRequest("0001");
            }
        }
    }
}
