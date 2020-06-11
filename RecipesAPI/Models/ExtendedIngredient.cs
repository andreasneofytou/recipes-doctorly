using RecipesAPI.Enums;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace RecipesAPI.Models
{
    public class ExtendedIngredient: BaseModel
    {
        public string Aisle { get; set; }
        public IngredientConsistency Consistency  { get; set; }
        public string Name  { get; set; }
        public float Amount { get; set; }
        public Unit Unit { get; set; }
        public List<Measure> Measures { get; set; }
    }
}