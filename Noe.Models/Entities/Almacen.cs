using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noe.Models.Entities
{
    public class Almacen
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int IdProducto { get; set; }
        
        [Required]
        public int Cantidad { get; set; }
        
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        
        public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;
        
        // Navegación
        [ForeignKey("IdProducto")]
        public virtual Producto Producto { get; set; } = null!;
    }
}