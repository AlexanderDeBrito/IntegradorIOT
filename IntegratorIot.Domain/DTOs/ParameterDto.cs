using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IntegratorIot.Domain.DTOs
{
    public class ParameterDto
    {
        [JsonIgnore]
        public int Id {  get; set; }
        [Required(ErrorMessage = "Nome do parêmetro é obrigatório")]
        [Description("Nome do parâmetro")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Descrição do parêmetro é obrigatório")]
        [StringLength(200)]
        [Description("Descrição do parâmetro, incluindo detalhes de sua utilização,valores possíveis e funcionamento experado da operação de acordo com esses valores")]
        public string? Description { get; set; }
        [JsonIgnore]
        public CommandDto? CommandDto { get; set; }
        [JsonIgnore]
        public int? CommandId { get; set; }
    }
}
