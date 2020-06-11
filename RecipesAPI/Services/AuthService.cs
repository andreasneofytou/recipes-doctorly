using System;
using System.Text;
using System.Threading.Tasks;
using RecipesAPI.Models;
using RecipesAPI.TokenProviders;
using RecipesAPI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;


namespace RecipesAPI.Services
{
    public class AuthService
    {
        private readonly UserManager<User> userManager;
        private readonly EmailService emailService;
        private readonly ITokenProvider tokenProvider;
        private readonly RoleManager<Role> roleManager;

        public AuthService(UserManager<User> userManager, EmailService emailService, ITokenProvider tokenProvider,
            RoleManager<Role> roleManager)
        {
            this.userManager = userManager;
            this.emailService = emailService;
            this.tokenProvider = tokenProvider;
            this.roleManager = roleManager;
        }

        public async Task<bool> Register(Register registerViewModel, UrlHelper urlHelper)
        {
            IdentityResult result =
                await userManager.CreateAsync(registerViewModel.ToUser(), registerViewModel.Password);

            if (result.Succeeded)
            {
                User user = await userManager.FindByEmailAsync(registerViewModel.Email);
                await userManager.AddToRoleAsync(user, "AppUser");
                string confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(user);
                string confirmUrl = urlHelper.Action("ConfirmEmail", "Accounts",
                    new { userId = user.Id, token = confirmationToken }, "http");
                await emailService.SendEmailAsync("andreas3115@gmail.com", "Confirm account", confirmUrl);
                //Send Email

                return true;
            }
            else
            {
                StringBuilder message = new StringBuilder();
                foreach (IdentityError error in result.Errors)
                {
                    message.Append(error + Environment.NewLine);
                }

                throw new Exception(message.ToString());
            }
        }

        public async Task<bool> ConfirmEmail(string userId, string token)
        {
            User user = await userManager.FindByIdAsync(userId);

            if (user != null)
            {
                IdentityResult result = await userManager.ConfirmEmailAsync(user, token);
                return result.Succeeded;
            }

            return false;
        }

        public async Task<LoginResult> Login(Login loginViewModel)
        {
            User user = await userManager.FindByEmailAsync(loginViewModel.Email);
            if (user != null)
            {
                bool isPassCorrect = await userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if (isPassCorrect && user.EmailConfirmed)
                {
                    var token = await tokenProvider.GenerateToken(user);
                    return new LoginResult { IsSuccessful = true, Token = token };
                }
            }

            return new LoginResult { IsSuccessful = false, Message = "Invalid email and/or password" };
        }

        public async Task<bool> ForgotPassword(string email, UrlHelper urlHelper)
        {
            User user = await userManager.FindByEmailAsync(email);
            if (user != null)
            {
                string token = await userManager.GeneratePasswordResetTokenAsync(user);
                string confirmUrl = urlHelper.Action("ResetPassword", "Accounts", new { userId = user.Id, token = token },
                    "http");
                await emailService.SendEmailAsync(email, "Reset Password", confirmUrl);
            }

            return false;
        }

        public async Task<bool> ResetPassword(ResetPassword resetPassViewModel)
        {
            User user = await userManager.FindByIdAsync(resetPassViewModel.UserId);
            if (user != null)
            {
                IdentityResult result = await userManager.ResetPasswordAsync(user, resetPassViewModel.ResetToken,
                    resetPassViewModel.Password);
                return result.Succeeded;
            }

            return false;
        }

    }
}
