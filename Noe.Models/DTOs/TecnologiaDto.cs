namespace Noe.Models.DTOs
{
    public class TecnologiaDto : BaseDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string IconoSvg { get; set; } = string.Empty;
    }
    
    public class TecnologiaCreateDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string IconoSvg { get; set; } = string.Empty;
    }
    
    public class TecnologiaUpdateDto : BaseDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string IconoSvg { get; set; } = string.Empty;
    }
}