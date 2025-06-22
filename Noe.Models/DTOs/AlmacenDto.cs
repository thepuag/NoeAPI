namespace Noe.Models.DTOs
{
    public class AlmacenDto : BaseDto
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public ProductoDto? Producto { get; set; }
    }
    
    public class AlmacenCreateDto
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }
    
    public class AlmacenUpdateDto : BaseDto
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
    }
}