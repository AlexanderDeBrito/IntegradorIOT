using IntegradorIot.Models;

namespace IntegratorIot.Domain.Interfaces
{
    public interface IParameterRepository
    {
        Task<Parameter> Save(Parameter parameter);
        Task<Parameter> UpDate(Parameter parameter);
        Task<Parameter> Delete(Parameter parameter);
        Task<Parameter> Get(int id);
        Task<IEnumerable<Parameter>> GetAll();
    }
}
