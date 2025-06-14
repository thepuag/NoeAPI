using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noe.Models.Entities;

public class Proyecto
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Titulo { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string Descripcion { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Empresa { get; set; } = string.Empty;

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        
    public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;
        
    public bool Activo { get; set; } = true;


}
