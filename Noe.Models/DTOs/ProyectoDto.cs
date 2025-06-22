namespace Noe.Models.DTOs
{
    public class ProyectoDto : BaseDto
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Empresa { get; set; } = string.Empty;
    }
    
    public class ProyectoCreateDto
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Empresa { get; set; } = string.Empty;
    }
    
    public class ProyectoUpdateDto : BaseDto
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Empresa { get; set; } = string.Empty;
    }
}