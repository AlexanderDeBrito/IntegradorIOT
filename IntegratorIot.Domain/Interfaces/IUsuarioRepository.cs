using IntegratorIot.Domain.Models;

namespace IntegratorIot.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> Save(Usuario Usuario);
        Task<Usuario> UpDate(Usuario Usuario);
        Task<Usuario> Delete(Usuario Usuario);
        Task<Usuario> Get(int id);
        Task<IEnumerable<Usuario>> GetAll();
    }
}
