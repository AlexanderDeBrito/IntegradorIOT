using AutoMapper;
using IntegradorIoc.Application.Interfaces;
using IntegratorIot.Domain.DTOs;
using IntegratorIot.Domain.Interfaces;
using IntegratorIot.Domain.Models;
using System.Security.Cryptography;
using System.Text;

namespace IntegradorIoc.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        public readonly IMapper mapper;
        public readonly IUsuarioRepository repository;

        public UsuarioService(IMapper mapper, IUsuarioRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<UsuarioDto> Delete(UsuarioDto usuarioDto)
        {
            return mapper.Map<UsuarioDto>(await repository.Delete(mapper.Map<Usuario>(usuarioDto)));
        }

        public async Task<IEnumerable<UsuarioDto>> GetAllAsync()
        {
            return mapper.Map<IEnumerable<UsuarioDto>>(await repository.GetAll());
        }

        public async Task<UsuarioDto> GetAsync(int id)
        {
            return mapper.Map<UsuarioDto>(await repository.Get(id));
        }

        public async Task<UsuarioDto> Save(UsuarioDto usuarioDto)
        {
            var usuario = mapper.Map<Usuario>(usuarioDto);
            if (usuarioDto.Password != null)
            {
                using var hmac = new HMACSHA512();
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(usuarioDto.Password));
                byte[] passworSalt = hmac.Key;

                usuario.AlterarSenha(passwordHash, passworSalt);
            }

            return mapper.Map<UsuarioDto>(await repository.Save(usuario));
        }

        public async Task<UsuarioDto> UpDate(UsuarioDto usuarioDto)
        {
            return mapper.Map<UsuarioDto>(await repository.UpDate(mapper.Map<Usuario>(usuarioDto)));
        }
    }
}
