namespace IntegradorIot.Models
{
    public class Commands
    {
        public int Id { get; set; }       
        public string? Command { get; set; }       
        public int CommandDescriptionId {  get; set; }
        public CommandDescription CommandDescription { get; set; }
        public IEnumerable<Parameter> ?Parameters { get; set; }

        public Commands(string? command,int commandDescriptionId)
        {
            ValidationDomain(command, commandDescriptionId);
        }

        public void ValidationDomain(string? command,int commandDescriptionId)
        {
            Command = command;
            CommandDescriptionId = commandDescriptionId;
        }
    }
}
