namespace Noe.Models.DTOs
{
    public class UsuarioDto : BaseDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string GoogleId { get; set; } = string.Empty;
        public string ImagenUrl { get; set; } = string.Empty;
    }
    
    public class UsuarioCreateDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string GoogleId { get; set; } = string.Empty;
        public string ImagenUrl { get; set; } = string.Empty;
    }
    
    public class UsuarioUpdateDto : BaseDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ImagenUrl { get; set; } = string.Empty;
    }
}