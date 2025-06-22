namespace Noe.Models.DTOs
{
    public class ProyectoTecnologiaDto : BaseDto
    {
        public string IdProyecto { get; set; } = string.Empty;
        public string IdTecnologia { get; set; } = string.Empty;
        public string IconoSvg { get; set; } = string.Empty;
    }
    
    public class ProyectoTecnologiaCreateDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string IconoSvg { get; set; } = string.Empty;
    }
    
    public class ProyectoTecnologiaUpdateDto : BaseDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string IconoSvg { get; set; } = string.Empty;
    }
}