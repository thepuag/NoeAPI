using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noe.Models.Entities
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Nombre { get; set; } = string.Empty;
        
        [StringLength(1000)]
        public string Descripcion { get; set; } = string.Empty;
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }
        
        [StringLength(500)]
        public string UrlImg { get; set; } = string.Empty;
        
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        
        public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;
        
        public bool Activo { get; set; } = true;
        
        // Navegación
        public virtual ICollection<Almacen> Almacenes { get; set; } = new List<Almacen>();
    }
}