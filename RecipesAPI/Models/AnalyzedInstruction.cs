using System.Collections.Generic;

namespace RecipesAPI.Models
{
    public class AnalyzedInstruction : BaseModel
    {
        public int StepSequence { get; set; }
        public string Instruction { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Equipment> Equipment { get; set; }
    }
}