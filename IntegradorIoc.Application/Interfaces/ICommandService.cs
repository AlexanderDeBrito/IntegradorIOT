using IntegratorIot.Domain.DTOs;

namespace IntegradorIoc.Application.Interfaces
{
    public interface ICommandService
    {
        Task<CommandDto> Save(CommandDto commandDto);
        Task<CommandDto> UpDate(CommandDto commandDto);
        Task<CommandDto> Delete(CommandDto commandDto);
        Task<CommandDto> GetAsync(int id);
        Task<IEnumerable<CommandDto>> GetAllAsync();
    }
}
