using System.ComponentModel.DataAnnotations;

namespace IntegradorIot.Api.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O E-mail é obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email {  get; set; }
        [Required(ErrorMessage = "A senha é obrigatório")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public LoginModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
