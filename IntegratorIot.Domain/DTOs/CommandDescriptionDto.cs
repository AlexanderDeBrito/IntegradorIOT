using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IntegratorIot.Domain.DTOs
{
    public class CommandDescriptionDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        [Description("Nome da operação executada pelo dispositivo")]
        public string? Operation { get; set; }        
        [Required]
        [StringLength(300)]
        [Description("Descrição e detalhes adicionais sobre a operação e/ou o comando")]
        public string? Description { get; set; }
        [Required]
        [StringLength(150)]
        [Description("Descrição do resultado esperado da execução do comando")]
        public string? Result { get; set; }
        [Required]
        [StringLength(100)]
        [Description("Definição, usando o padrão OpenAPI para especificação de schemas de dados, do formato dos dados retornados pelo comando.")]
        public string? Format { get; set; }
        [Required(ErrorMessage ="Paramentros aceito pelo comando obrigatório")]
        public CommandDto CommandDto { get; set; }
        [JsonIgnore]
        public int DeviceId { get; set; }
        [JsonIgnore]
        public DeviceDto ?DeviceDto { get; set; }
    }
}
