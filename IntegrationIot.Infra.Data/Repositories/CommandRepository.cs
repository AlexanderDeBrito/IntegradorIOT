using IntegradorIot.Models;
using IntegrationIot.Infra.Data.Context;
using IntegratorIot.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegrationIot.Infra.Data.Repositories
{
    public class CommandRepository : ICommandRepository
    {
        public readonly ApplicationDbContext context;

        public CommandRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Commands> Delete(Commands command)
        {
            context.Command.Remove(command);
            await context.SaveChangesAsync();
            return command;
        }

        public async Task<Commands> Get(int id)
        {
            var command = await context.Command.Include(x => x.CommandDescription).Where(x => x.Id == id).FirstOrDefaultAsync();
            return command;
        }

        public async Task<IEnumerable<Commands>> GetAll()
        {
            return await context.Command.Include(x => x.CommandDescription).ToListAsync();
        }

        public async Task<Commands> Save(Commands command)
        {
            context.Command.Add(command);
            await context.SaveChangesAsync();
            return command;
        }

        public async Task<Commands> UpDate(Commands command)
        {
            context.Command.Update(command);
            await context.SaveChangesAsync();  
            return command;
        }
    }
}
