using Microsoft.AspNetCore.Identity;

namespace RecipesAPI.Models
{
    public class Role : IdentityRole<int>
    {
        public Role() : base()
        {
        }

        public Role(string name) : base(name)
        {
        }
    }

}
