using IntegrationIot.Infra.Data.Context;
using IntegratorIot.Domain.Interfaces;
using IntegratorIot.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegrationIot.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Usuario> Delete(Usuario Usuario)
        {
            context.Usuario.Remove(Usuario);
            await context.SaveChangesAsync();
            return Usuario;
        }

        public async Task<Usuario> Get(int id)
        {
            return await context.Usuario.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await context.Usuario.ToListAsync();
        }

        public async Task<Usuario> Save(Usuario Usuario)
        {
            context.Usuario.Add(Usuario);
            await context.SaveChangesAsync();
            return Usuario;
        }
        public async Task<Usuario> UpDate(Usuario Usuario)
        {
            context.Usuario.Update(Usuario);
            await context.SaveChangesAsync();
            return Usuario;
        }
    }
}
