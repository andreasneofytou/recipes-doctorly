using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipesAPI.Services;

namespace RecipesAPI.Controllers
{
    [Route("recipes")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RecipesController : Controller
    {
        private readonly RecipesService recipesService;

        public RecipesController(RecipesService recipesService)
        {
            this.recipesService = recipesService;
        }

       [HttpGet("{id}")]
       public async Task<ActionResult> Get(int id)
        {
            var recipe = await recipesService.GetById(id);
            if(recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }
    }
}
