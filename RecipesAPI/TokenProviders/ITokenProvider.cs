using RecipesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.TokenProviders
{
    public interface ITokenProvider
    {
        Task<string> GenerateToken(User user);
    }

}

