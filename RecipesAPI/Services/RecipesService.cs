using Microsoft.EntityFrameworkCore;
using RecipesAPI.DBContexts;
using RecipesAPI.Models;
using System.Threading.Tasks;

namespace RecipesAPI.Services
{
    public class RecipesService
    {
        private readonly RecipesDbContext recipesDbContext;

        private DbSet<Recipe> _recipes;
        private DbSet<Recipe> recipes => _recipes ?? (_recipes = recipesDbContext.Set<Recipe>());

        public RecipesService(RecipesDbContext RecipesDbContext)
        {
            recipesDbContext = RecipesDbContext;
        }

        public async Task<Recipe> GetById(int id)
        {
            return await recipes.FindAsync(id);
        }
    }
}
