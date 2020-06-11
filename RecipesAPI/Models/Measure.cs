using RecipesAPI.Enums;

namespace RecipesAPI.Models
{
    public class Measure : BaseModel
    {
        public string Name { get; set; }
        public Unit Unit { get; set; }
    }
}