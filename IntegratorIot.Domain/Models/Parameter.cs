using System.ComponentModel;

namespace IntegradorIot.Models
{
    public class Parameter
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? CommandId { get; set; }
        public Commands? Command { get; set; }

        public Parameter(string? name, string? description, int? commandId)
        {
            ValidationDomain(name, description, commandId);
        }


        public void ValidationDomain(string? name, string? description, int? commandId)
        {
            Name = name;
            Description = description;
            CommandId = commandId;
        }
    }
}
