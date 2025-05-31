namespace Noe.Models.DTOs
{
    public class GoogleAuthDto
    {
        public string Token { get; set; } = string.Empty;
    }
    
    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public UsuarioDto Usuario { get; set; } = null!;
        public DateTime ExpiresAt { get; set; }
    }
}