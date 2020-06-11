using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipesAPI.Services;
using RecipesAPI.Models;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using RecipesAPI.ViewModels;
using Microsoft.AspNetCore.Http;

namespace RecipesAPI.Controllers
{
    [Route("auth")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class AuthController : Controller
    {
        private readonly AuthService authService;
        private readonly UserManager<User> userManager;
        private readonly UrlHelper urlHelper;
        private readonly RoleManager<Role> roleManager;

        public AuthController(AuthService authService,
            IActionContextAccessor actionContextAccessor,
            UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            this.authService = authService;
            this.userManager = userManager;
            this.urlHelper = new UrlHelper(actionContextAccessor.ActionContext);
            this.roleManager = roleManager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            LoginResult result = await authService.Login(loginViewModel);
            if (!result.IsSuccessful)
            {
                return Unauthorized();
            }
            return Ok(result.Token);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Register registerViewModel)
        {
            if(!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            try
            {
                await authService.Register(registerViewModel, urlHelper);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var isSuccessful = await authService.ConfirmEmail(userId, token);
            return Ok(isSuccessful);
        }

        [AllowAnonymous]
        [HttpGet("forgot-password/{email}")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            await authService.ForgotPassword(email, urlHelper);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPassword resetPasswordViewModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            bool result = await authService.ResetPassword(resetPasswordViewModel);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Failed to reset password");
            }
        }
    }
}

