using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IntegratorIot.Domain.DTOs
{
    public class CommandDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Description("Sequencia de bytes enviados para execução do comando")]
        public string? Command { get; set; }
        [Required]
        [Description("Lista de parâmetros aceitas pelo comando")]
        public ICollection<ParameterDto> Parameters { get; set; }
        [JsonIgnore]
        public int CommandDescriptionId { get; set; }
        [JsonIgnore]
        public CommandDescriptionDto? commandDescriptionDto { get; set; }
    }
}
