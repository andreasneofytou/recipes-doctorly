using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.Models
{
    public class BaseModel
    {
        [Key]
        public string Id { get; set; }

    }
}
