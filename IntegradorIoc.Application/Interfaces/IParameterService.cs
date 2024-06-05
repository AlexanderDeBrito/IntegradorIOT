using IntegratorIot.Domain.DTOs;

namespace IntegradorIoc.Application.Interfaces
{
    public interface IParameterService
    {
        Task<ParameterDto> Save(ParameterDto parameterDto);
        Task<ParameterDto> UpDate(ParameterDto parameterDto);
        Task<ParameterDto> Delete(ParameterDto parameterDto);
        Task<ParameterDto> GetAsync(int id);
        Task<IEnumerable<ParameterDto>> GetAllAsync();
    }
}
