using IntegradorIot.Models;

namespace IntegratorIot.Domain.Interfaces
{
    public interface ICommandRepository
    {
        Task<Commands> Save(Commands command);
        Task<Commands> UpDate(Commands command);
        Task<Commands> Delete(Commands command);
        Task<Commands> Get(int id);
        Task<IEnumerable<Commands>> GetAll();
    }
}
