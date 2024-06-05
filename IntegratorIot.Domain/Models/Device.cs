namespace IntegradorIot.Models
{
    public class Device
    {        
        public int Id { get; set; }        
        public int identifier { get; set; }       
        public string? Description { get; set; }        
        public string? Manufacturer { get; set; }        
        public string? Url { get; set; }
        public IEnumerable<CommandDescription>? CommandDescriptions { get; set; }

        public Device(string? description, string? manufacturer, string? url)
        {
            ValidateDomain(description, manufacturer, url);
        }

        public void ValidateDomain(string? description, string? manufacturer, string? url)
        {
            Description = description;
            Manufacturer = manufacturer;
            Url = url;
            
        }
    }
}
