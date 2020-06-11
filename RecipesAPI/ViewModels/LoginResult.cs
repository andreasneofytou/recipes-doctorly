using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.ViewModels
{
    public class LoginResult
    {
        public bool IsSuccessful { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }

    }
}
