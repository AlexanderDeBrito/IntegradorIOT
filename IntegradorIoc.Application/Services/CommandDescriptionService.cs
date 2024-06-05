using AutoMapper;
using IntegradorIoc.Application.Interfaces;
using IntegradorIot.Models;
using IntegratorIot.Domain.DTOs;
using IntegratorIot.Domain.Interfaces;

namespace IntegradorIoc.Application.Services
{
    public class CommandDescriptionService : ICommandDescriptionService
    {
        public readonly ICommandDescriptionRepository repository;
        public readonly IMapper mapper;

        public CommandDescriptionService(ICommandDescriptionRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CommandDescriptionDto> Delete(CommandDescriptionDto commandDescriptionDto)
        {
           return mapper.Map<CommandDescriptionDto>(await repository.Delete(mapper.Map<CommandDescription>(commandDescriptionDto)));
        }

        public async Task<IEnumerable<CommandDescriptionDto>> GetAllAsync()
        {
            return mapper.Map<IEnumerable<CommandDescriptionDto>>(await repository.GetAll());
        }

        public async Task<CommandDescriptionDto> GetAsync(int id)
        {
            return mapper.Map<CommandDescriptionDto>(await repository.Get(id));
        }

        public async Task<CommandDescriptionDto> Save(CommandDescriptionDto commandDescriptionDto)
        {
            return mapper.Map<CommandDescriptionDto>(await repository.Save(mapper.Map<CommandDescription>(commandDescriptionDto)));
        }

        public async Task<CommandDescriptionDto> UpDate(CommandDescriptionDto commandDescriptionDto)
        {
            return mapper.Map<CommandDescriptionDto>(await repository.UpDate(mapper.Map<CommandDescription>(commandDescriptionDto)));
        }
    }
}
