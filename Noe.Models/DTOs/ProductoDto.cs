namespace Noe.Models.DTOs
{
    public class ProductoDto : BaseDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string UrlImg { get; set; } = string.Empty;
    }
    
    public class ProductoCreateDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string UrlImg { get; set; } = string.Empty;
    }
    
    public class ProductoUpdateDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string UrlImg { get; set; } = string.Empty;
    }
}