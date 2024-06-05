using IntegratorIot.Domain.DTOs;
using IntegratorIot.Domain.Models;

namespace IntegradorIoc.Application.Interfaces
{
    public interface IDeviceService
    {
        Task<DeviceDto> Save(DeviceDto deviceDto);
        Task<DeviceDto> UpDate(DeviceDto deviceDto);
        Task<DeviceDto> Delete(DeviceDto deviceDto);
        Task<DeviceDto> GetAsync(int id);
        Task<DeviceListDto> GetAllAsync();
    }
}
