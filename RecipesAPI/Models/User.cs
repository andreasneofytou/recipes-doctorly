using Microsoft.AspNetCore.Identity;
using System;

namespace RecipesAPI.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
