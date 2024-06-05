using IntegradorIot.Models;
using IntegrationIot.Infra.Data.Context;
using IntegratorIot.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IntegrationIot.Infra.Data.Repositories
{
    public class ParameterRepository : IParameterRepository
    {
        public readonly ApplicationDbContext context;

        public ParameterRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Parameter> Delete(Parameter parameter)
        {
            context.Parameter.Remove(parameter);
            await context.SaveChangesAsync();
            return parameter;
        }

        public async Task<Parameter> Get(int id)
        {
            var parameter = await context.Parameter.Where(x => x.Id == id).FirstOrDefaultAsync();
            return parameter;
        }

        public async Task<IEnumerable<Parameter>> GetAll()
        {
            return await context.Parameter.ToListAsync();
        }

        public async Task<Parameter> Save(Parameter parameter)
        {
            context.Parameter.Add(parameter);
            await context.SaveChangesAsync();
            return parameter;
        }

        public async Task<Parameter> UpDate(Parameter parameter)
        {
            context.Parameter.Update(parameter);
            await context.SaveChangesAsync();
            return parameter;

        }
    }
}
