using IntegradorIot.Models;

namespace IntegratorIot.Domain.Interfaces
{
    public interface IDeviceRepository
    {
        Task<Device> Save(Device device);
        Task<Device> UpDate(Device device);
        Task<Device> Delete(Device device);
        Task<Device> Get(int id);
        Task<IEnumerable<Device>> GetAll();
    }
}
