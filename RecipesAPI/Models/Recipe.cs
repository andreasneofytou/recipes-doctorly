using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesAPI.Models
{
    public class Recipe : BaseModel
    {
        [Required]
        public string Title { get; set; }
        public int ReadyInMinutes { get; set; }
        public int Servings { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public string Instructions { get; set; }
        public List< AnalyzedInstruction> AnalyzedInstructions { get; set; }
        public List<Cuisine> Cuisines { get; set; }
        public List<DishType> DishTypes { get; set; }
        [Required]
        public List<ExtendedIngredient> ExtendedIngredients { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
        public bool IsGlutenFree { get; set; }
        public bool IsDairyFree { get; set; }
        public bool IsCheap { get; set; }
        public string SourceName { get; set; }
        public DateTime CreatedAt { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }
    }
}
