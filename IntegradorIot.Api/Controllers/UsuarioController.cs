using IntegradorIoc.Application.Interfaces;
using IntegradorIot.Api.Models;
using IntegratorIot.Domain.Account;
using IntegratorIot.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorIot.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IAuthenticate authenticateService;
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IAuthenticate authenticateService, IUsuarioService usuarioService)
        {
            this.authenticateService = authenticateService;
            this.usuarioService = usuarioService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserToken>> Save(UsuarioDto usuarioDto)
        {
            if (usuarioDto == null) 
                return BadRequest("Dados inválidos");
                    
            var emailExistente  =   await authenticateService.UserExists(usuarioDto.Email);

            if (emailExistente)
                return BadRequest("E-mail já existente");

            var usuario = await usuarioService.Save(usuarioDto);
            if (usuario == null)
                return BadRequest("Ocorreu um erro ao cadastrar usuario");

            var token = authenticateService.GenerateToken(usuario.Id, usuario.Email);

            return new UserToken
            {
                Token = token
            };
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login(LoginModel login)
        {
            if (login == null)
                return BadRequest("Dados inválidos");

            var emailExistente = await authenticateService.UserExists(login.Email);
            if (!emailExistente)
                return BadRequest("Usuario não existe");
            
            var result = await authenticateService.AuthenticateAsync(login.Email, login.Password);
            if (!result)
                return Unauthorized("Usuário ou senha inválidos");

            var usuario =  await authenticateService.GetUserByEmail(login.Email);

            var token = authenticateService.GenerateToken(usuario.Id, usuario.Email);

            return new UserToken
            {
                Token = token
            };
        }
    }
}
