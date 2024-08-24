using System.ComponentModel.DataAnnotations;

namespace ProjetoDemo.API.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password), ErrorMessage = "Password don't match")]
        public string ConfirmPassword { get; set; }
    }
}
