using Microsoft.EntityFrameworkCore;
using RecipesAPI.DBContexts;
using RecipesAPI.Models;
using System;
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

        public async Task<Recipe> Create(Recipe recipe)
        {
            recipes.Add(recipe);
            await recipesDbContext.SaveChangesAsync();
            return recipe;
        }

        public async Task<Recipe> Update(Recipe recipe)
        {
            recipes.Update(recipe);
            await recipesDbContext.SaveChangesAsync();
            return recipe;
        }

        public async Task Delete(int id)
        {
            var recipe = new Recipe { Id = id };
            recipes.Remove(recipe);
            await recipesDbContext.SaveChangesAsync();
        }
    }
}
