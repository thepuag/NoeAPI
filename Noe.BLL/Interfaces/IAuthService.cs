using Noe.Models.DTOs;

namespace Noe.BLL.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> GoogleLoginAsync(GoogleAuthDto googleAuthDto);
        Task<string> GenerateJwtTokenAsync(UsuarioDto usuario);
        Task<UsuarioDto?> ValidateGoogleTokenAsync(string token);
    }
}