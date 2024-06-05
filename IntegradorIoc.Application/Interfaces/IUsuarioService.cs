using IntegratorIot.Domain.DTOs;
using IntegratorIot.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegradorIoc.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> Save(UsuarioDto usuarioDto);
        Task<UsuarioDto> UpDate(UsuarioDto usuarioDto);
        Task<UsuarioDto> Delete(UsuarioDto usuarioDto);
        Task<UsuarioDto> GetAsync(int id);
        Task<IEnumerable<UsuarioDto>> GetAllAsync();
    }
}
