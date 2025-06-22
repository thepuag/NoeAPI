using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noe.Models.Entities;

public class Tecnologia
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

     [Required]
    [StringLength(500)]
    public string Descripcion { get; set; } = string.Empty;

    [Required]    
    public string IconoSvg { get; set; } = string.Empty;

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        
    public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;
        
    public bool Activo { get; set; } = true;
}
