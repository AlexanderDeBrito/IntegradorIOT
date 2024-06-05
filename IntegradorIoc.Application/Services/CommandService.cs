using AutoMapper;
using IntegradorIoc.Application.Interfaces;
using IntegradorIot.Models;
using IntegratorIot.Domain.DTOs;
using IntegratorIot.Domain.Interfaces;

namespace IntegradorIoc.Application.Services
{
    public class CommandService : ICommandService
    {
        public readonly ICommandRepository repository;
        public readonly IMapper mapper;

        public CommandService(ICommandRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CommandDto> Delete(CommandDto commandDto)
        {
            return mapper.Map<CommandDto>(await repository.Delete(mapper.Map<Commands>(commandDto)));
        }

        public async Task<IEnumerable<CommandDto>> GetAllAsync()
        {
            return mapper.Map<IEnumerable<CommandDto>>(await repository.GetAll());
        }

        public async Task<CommandDto> GetAsync(int id)
        {
            return mapper.Map<CommandDto>(await repository.Get(id));
        }

        public async Task<CommandDto> Save(CommandDto commandDto)
        {
            return mapper.Map<CommandDto>( await repository.Save(mapper.Map<Commands>(commandDto)));
        }

        public async Task<CommandDto> UpDate(CommandDto commandDto)
        {
            return mapper.Map<CommandDto>(await repository.UpDate(mapper.Map<Commands>(commandDto)));
        }
    }
}
