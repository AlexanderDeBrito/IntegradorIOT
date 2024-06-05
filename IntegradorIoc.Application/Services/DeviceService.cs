
using AutoMapper;
using IntegradorIoc.Application.Interfaces;
using IntegradorIot.Models;
using IntegrationIot.Infra.Data.Context;
using IntegrationIot.Infra.Data.Repositories;
using IntegratorIot.Domain.DTOs;
using IntegratorIot.Domain.Interfaces;

namespace IntegradorIoc.Application.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _repository;
        private readonly IMapper mapper;
        private readonly ICommandDescriptionService commandDescriptionService;
        private readonly ICommandService commandService;
        private readonly IParameterService parameterService;
        private readonly ApplicationDbContext _context;

        public DeviceService(IDeviceRepository repository, IMapper mapper, ICommandDescriptionService commandDescriptionService,
            ICommandService commandService, IParameterService parameterService, ApplicationDbContext context)
        {
            _repository = repository;
            this.mapper = mapper;
            this.commandDescriptionService = commandDescriptionService;
            this.commandService = commandService;
            this.parameterService = parameterService;
            this._context = context;
        }

        public async Task<DeviceDto> Delete(DeviceDto deviceDto)
        {
            var device = mapper.Map<Device>(deviceDto);
            return mapper.Map<DeviceDto>(await _repository.Delete(device));
        }

        public async Task<DeviceListDto> GetAllAsync()
        {
            try
            {
                var devices = mapper.Map<IEnumerable<DeviceDto>>(await _repository.GetAll());
                var deviceList = new DeviceListDto();
                deviceList.Itens = new List<string>();
                foreach (var device in devices)
                {
                    deviceList.Itens.Add(device.identifier.ToString());
                }

                return deviceList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<DeviceDto> GetAsync(int id)
        {
            return mapper.Map<DeviceDto>(await _repository.Get(id));
        }

        public async Task<DeviceDto> Save(DeviceDto deviceDto)
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var device = mapper.Map<Device>(deviceDto);
                    device = await _repository.Save(device);
                    device.Url = device.Url + $"/{device.Id}";


                    foreach (var item in deviceDto.Commands)
                    {
                        item.DeviceId = device.Id;
                        var commandDescription = await commandDescriptionService.Save(item);

                        
                        item.CommandDto.CommandDescriptionId = commandDescription.Id;
                        var command = await commandService.Save(item.CommandDto);


                        foreach (var parameter in item.CommandDto.Parameters)
                        {
                            parameter.CommandId = command.Id;
                            await parameterService.Save(parameter);
                        }
                    }

                    return mapper.Map<DeviceDto>(device);
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw new Exception(ex.Message);
                }

            }

        }

        public async Task<DeviceDto> UpDate(DeviceDto deviceDto)
        {
            var device = mapper.Map<Device>(deviceDto);
            return mapper.Map<DeviceDto>(await _repository.UpDate(device));
        }
    }
}
