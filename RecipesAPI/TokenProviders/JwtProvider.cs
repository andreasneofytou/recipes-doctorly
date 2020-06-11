using Microsoft.AspNetCore.Identity;
using RecipesAPI.Models;
using RecipesAPI.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RecipesAPI.TokenProviders
{
    public class JwtProvider : ITokenProvider
    {
        private readonly TokenProviderOptions tokenProviderOptions;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;

        public JwtProvider(TokenProviderOptions tokenProviderOptions, UserManager<User> userMananger, RoleManager<Role> roleManager)
        {
            this.tokenProviderOptions = tokenProviderOptions;
            this.userManager = userMananger;
            this.roleManager = roleManager;
        }

        public async Task<string> GenerateToken(User user)
        {
            var now = DateTime.UtcNow;
            var nowOffset = DateTimeOffset.UtcNow;
            IdentityOptions options = new IdentityOptions();
            // Specifically add the jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
            // You can add other claims here, if you want:
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, nowOffset.ToUnixTimeSeconds().ToString(),
                    ClaimValueTypes.Integer64),
                new Claim(options.ClaimsIdentity.UserIdClaimType, user.Id.ToString()),
                new Claim(options.ClaimsIdentity.UserNameClaimType, user.Email)
            };

            var userRoles = await userManager.GetRolesAsync(user);
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await roleManager.FindByNameAsync(userRole);
                if (role != null)
                {
                    var roleClaims = await roleManager.GetClaimsAsync(role);
                    foreach (Claim roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }

            // Create the JWT and write it to a string
            var jwt = new JwtSecurityToken(
                issuer: tokenProviderOptions.Issuer,
                audience: tokenProviderOptions.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(tokenProviderOptions.Expiration),
                signingCredentials: tokenProviderOptions.SigningCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
    }

}
