using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IntegratorIot.Domain.DTOs
{
    public class DeviceDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        [Description("Identificador do dispositivo")]
        public int identifier { get; set; }
        [Required]
        [StringLength(200)]
        [Description("Descrição do dispositivo, incluindo detalhes do seu uso e das informações geradas")]
        public string? Description { get; set; }
        [Required]
        [StringLength(200)]
        [Description("Nome do fabricante do dispositivo")]
        public string? Manufacturer { get; set; }
        [StringLength(150)]
        [Description("URL de acesso ao dispositivo")]
        [JsonIgnore]
        public string? Url { get; set; }
        [Description("Lista de comandos disponibilizada pelo dispositivo")]
        [Required(ErrorMessage = "Lista de comandos disponibilizada pelo dispositivo é obrigatório")]
        public IEnumerable<CommandDescriptionDto> Commands { get; set; }
        [Description("Lista com os identificadores do dispositivo")]
        [JsonIgnore]
        public DeviceListDto? DeviceList { get; set; }        

    }
}
