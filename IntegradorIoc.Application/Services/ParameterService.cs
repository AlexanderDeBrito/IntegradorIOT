using AutoMapper;
using IntegradorIoc.Application.Interfaces;
using IntegradorIot.Models;
using IntegratorIot.Domain.DTOs;
using IntegratorIot.Domain.Interfaces;

namespace IntegradorIoc.Application.Services
{
    public class ParameterService : IParameterService
    {
        public readonly IParameterRepository repository;
        public readonly IMapper mapper;

        public ParameterService(IParameterRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ParameterDto> Delete(ParameterDto parameterDto)
        {
           return mapper.Map<ParameterDto>(await repository.Delete(mapper.Map<Parameter>(parameterDto)));
        }

        public async Task<IEnumerable<ParameterDto>> GetAllAsync()
        {
            return mapper.Map<IEnumerable<ParameterDto>>(await repository.GetAll());
        }

        public async Task<ParameterDto> GetAsync(int id)
        {
            return mapper.Map<ParameterDto>(await repository.Get(id));
        }

        public async Task<ParameterDto> Save(ParameterDto parameterDto)
        {
            return mapper.Map<ParameterDto>(await repository.Save(mapper.Map<Parameter>(parameterDto)));
        }

        public async Task<ParameterDto> UpDate(ParameterDto parameterDto)
        {
            return mapper.Map<ParameterDto>(await repository.UpDate(mapper.Map<Parameter>(parameterDto)));
        }
    }
}
