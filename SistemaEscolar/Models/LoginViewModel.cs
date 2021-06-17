using System.ComponentModel.DataAnnotations;

namespace SitemaUnicesumar.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Informe o e-mail", AllowEmptyStrings = false)]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Informe a senha", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ErrorMenssage { get; set; }
    }
}