using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Noe.Models.Entities;

public class ProyectoTecnologia
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int IdProyecto { get; set; }

    [ForeignKey("IdProyecto")]
    public Proyecto Proyecto { get; set; } = null!;

    [Required]
    public int IdTecnologia { get; set; }

    [ForeignKey("IdTecnologia")]
    public Tecnologia Tecnologia { get; set; } = null!;

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        
    public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;
        
    public bool Activo { get; set; } = true;
}
