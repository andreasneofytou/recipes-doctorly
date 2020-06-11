using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RecipesAPI.Models;
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
        [AllowAnonymous]
        public async Task<ActionResult> Get(int id)
        {
            var recipe = await recipesService.GetById(id);
            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        [HttpPost]
        [Authorize(Roles = "Superuser, Admin")]
        public async Task<ActionResult> Create([FromBody] Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            try
            {
                return Ok(await recipesService.Create(recipe));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Superuser, Admin")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            try
            {
                return Ok(await recipesService.Update(recipe));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Superuser, Admin")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await recipesService.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
