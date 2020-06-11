using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

    }
}
