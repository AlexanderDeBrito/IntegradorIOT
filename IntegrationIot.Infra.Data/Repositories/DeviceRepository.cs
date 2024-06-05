using IntegradorIot.Models;
using IntegrationIot.Infra.Data.Context;
using IntegratorIot.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegrationIot.Infra.Data.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly ApplicationDbContext context;

        public DeviceRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Device> Delete(Device device)
        {
            context.Device.Remove(device);
            await context.SaveChangesAsync();
            return device;
        }

        public async Task<Device> Get(int id)
        {
           return await context.Device.Include(x => x.CommandDescriptions).Where(x => x.identifier == id).FirstOrDefaultAsync();              
        }

        public async Task<IEnumerable<Device>> GetAll()
        {
            return await context.Device.Include(x => x.CommandDescriptions).ToListAsync();
        }

        public async Task<Device> Save(Device device)
        {
            context.Device.Add(device);
            await context.SaveChangesAsync();
            return device;
        }
        public async Task<Device> UpDate(Device device)
        {
            context.Device.Update(device);
            await context.SaveChangesAsync();
            return device;
        }

    }
}
