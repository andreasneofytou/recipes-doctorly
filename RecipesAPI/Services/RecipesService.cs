using RecipesAPI.DBContexts;
using RecipesAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Services
{
    public class RecipesService
    {
        private readonly RecipesDbContext recipesDbContext;

        public RecipesService(RecipesDbContext RecipesDbContext)
        {
            recipesDbContext = RecipesDbContext;
        }
        public async Task GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
