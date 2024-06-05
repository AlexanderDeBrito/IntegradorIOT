using IntegradorIot.Models;
using IntegrationIot.Infra.Data.Context;
using IntegratorIot.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegrationIot.Infra.Data.Repositories
{
    public class CommandDescriptionRepository : ICommandDescriptionRepository
    {
        public readonly ApplicationDbContext context;

        public CommandDescriptionRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<CommandDescription> Delete(CommandDescription commandDescription)
        {
            context.CommandDescription.Remove(commandDescription);
            await context.SaveChangesAsync();
            return commandDescription;
        }

        public async Task<CommandDescription> Get(int id)
        {
            var commandDescription = await context.CommandDescription.Include(x => x.Device).Where(x => x.Id == id).FirstOrDefaultAsync();
            return commandDescription;
        }

        public async Task<IEnumerable<CommandDescription>> GetAll()
        {
            return await context.CommandDescription.Include(x => x.Device).ToListAsync();
        }

        public async Task<CommandDescription> Save(CommandDescription commandDescription)
        {
            context.CommandDescription.Add(commandDescription);
            await context.SaveChangesAsync(true);
            return commandDescription;
        }

        public async Task<CommandDescription> UpDate(CommandDescription commandDescription)
        {
            context.CommandDescription.Update(commandDescription);
            await context.SaveChangesAsync();
            return commandDescription;
        }
    }
}
