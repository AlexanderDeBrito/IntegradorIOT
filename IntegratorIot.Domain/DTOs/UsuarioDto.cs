using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace IntegratorIot.Domain.DTOs
{
    public class UsuarioDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required(ErrorMessage ="Nome é obrigatório")] 
        public string Nome { get;  set; }
        [Required]
        public string Email { get;  set; }
        [NotMapped]
        public string Password { get;  set; }
    }
}
