using IntegradorIot.Models;

namespace IntegratorIot.Domain.Interfaces
{
    public interface ICommandDescriptionRepository
    {
        Task<CommandDescription> Save(CommandDescription commandDescription);
        Task<CommandDescription> UpDate(CommandDescription commandDescription);
        Task<CommandDescription> Delete(CommandDescription commandDescription);
        Task<CommandDescription> Get(int id);
        Task<IEnumerable<CommandDescription>> GetAll();
    }
}
