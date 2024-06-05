using IntegratorIot.Domain.DTOs;

namespace IntegradorIoc.Application.Interfaces
{
    public interface ICommandDescriptionService
    {
        Task<CommandDescriptionDto> Save(CommandDescriptionDto commandDescriptionDto);
        Task<CommandDescriptionDto> UpDate(CommandDescriptionDto commandDescriptionDto);
        Task<CommandDescriptionDto> Delete(CommandDescriptionDto commandDescriptionDto);
        Task<CommandDescriptionDto> GetAsync(int id);
        Task<IEnumerable<CommandDescriptionDto>> GetAllAsync();
    }
}
