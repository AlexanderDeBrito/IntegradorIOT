using IntegratorIot.Domain.Validation;

namespace IntegratorIot.Domain.Models
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public byte[]? PasswordHash { get; private set; }
        public byte[]? PasswordSalt { get; private set; }

        public Usuario(int id, string nome, string email)
        {
            DomainExceptionValidation.When(id < 0, "O Id não pode ser negativo");
            Id = id;
            ValidateDomain(nome, email);
        }

        public Usuario(string nome, string email)
        {
            ValidateDomain(nome, email);
        }

        public void AlterarSenha(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        private void ValidateDomain(string nome, string email)
        {
            DomainExceptionValidation.When(nome == null, "O Nome é obrigatório");
            DomainExceptionValidation.When(nome == null, "O E-mail é obrigatório");

            DomainExceptionValidation.When(nome.Length > 250, "O Nome não pode ultrapassar mais de 250 caracters");
            DomainExceptionValidation.When(email.Length > 200, "O E-mail não pode ultrapassar mais de 200 caracters");

            Nome = nome;
            Email = email;
        }
    }
}
