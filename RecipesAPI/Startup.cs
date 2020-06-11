using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using RecipesAPI.Claims;
using RecipesAPI.DBContexts;
using RecipesAPI.Models;
using RecipesAPI.Options;
using RecipesAPI.Services;
using RecipesAPI.TokenProviders;

namespace RecipesAPI
{
    public class Startup
    {

        private readonly string secretKey;
        private readonly SymmetricSecurityKey signingKey;
        private readonly TokenProviderOptions tokenProvierOptions;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            secretKey = Configuration["Security:SigningKey"];
            signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            tokenProvierOptions = new TokenProviderOptions
            {
                Audience = "recipes.com",
                Issuer = "recipes.com",
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
            };

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
            })
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();
            services.AddScoped<IUserClaimsPrincipalFactory<User>, AppClaimsPrincipalFactory<User, Role>>();
            services.AddEntityFrameworkNpgsql().AddDbContext<AuthDbContext>(options => options.UseNpgsql(Configuration["ConnectionStrings:AuthConnection"]));
            services.AddDbContext<RecipesDbContext>(options => options.UseNpgsql(Configuration["ConnectionStrings:RecipesConnection"]));

            services.AddSingleton(tokenProvierOptions);
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddTransient<ITokenProvider, JwtProvider>();
            services.AddTransient<EmailService>();
            services.AddScoped<AuthService>();
            services.AddScoped<RecipesService>();

            services.Configure<EmailClientOptions>(Configuration.GetSection("EmailOptions"));
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // The signing key must match!
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,

                    // Validate the JWT Issuer (iss) claim
                    ValidateIssuer = true,
                    ValidIssuer = "recipes.com",

                    // Validate the JWT Audience (aud) claim
                    ValidateAudience = true,
                    ValidAudience = "recipes.com",

                    // Validate the token expiry
                    ValidateLifetime = true,

                    // If you want to allow a certain amount of clock drift, set that here:
                    ClockSkew = TimeSpan.Zero
                };
            });


            services.AddSwaggerDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsProduction())
            {
                app.UseDeveloperExceptionPage(); app.UseOpenApi();
                app.UseSwaggerUi3();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
