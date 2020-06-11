using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.ViewModels
{
    public class ResetPassword
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string ResetToken { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
