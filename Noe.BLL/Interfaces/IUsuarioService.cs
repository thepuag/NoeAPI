using Noe.Models.DTOs;

namespace Noe.BLL.Interfaces
{
    public interface IUsuarioService : IBaseService<UsuarioDto, UsuarioCreateDto, UsuarioUpdateDto>
    {
        Task<UsuarioDto?> GetByEmailAsync(string email);
        Task<UsuarioDto?> GetByGoogleIdAsync(string googleId);
    }
}