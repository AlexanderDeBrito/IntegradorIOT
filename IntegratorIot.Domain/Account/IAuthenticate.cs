using IntegratorIot.Domain.Models;

namespace IntegratorIot.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync(string email,string senha);
        Task<bool> UserExists(string username);
        public string GenerateToken(int id, string email);
        public Task<Usuario> GetUserByEmail(string email);

    }
}
