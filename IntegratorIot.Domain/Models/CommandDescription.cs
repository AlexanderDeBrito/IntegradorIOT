namespace IntegradorIot.Models
{

    public class CommandDescription
    {
        public int Id { get; set; }
        public string? Operation { get; set; }
        public string? Description { get; set; }
        public string? Result { get; set; }
        public string? Format { get; set; }
        public int DeviceId { get; set; }
        public Device Device { get; set; }

        public Commands? Command { get; set; }

        public CommandDescription(string? operation, string? description, string? result, string? format)
        {
            ValidationDomain(operation, description, result, format);
        }

        public void ValidationDomain(string? operation, string? description, string? result, string? format)
        {
            Operation = operation;
            Description = description;
            Result = result;
            Format = format;           
        }
    }
}
