using System.ComponentModel.DataAnnotations;

namespace Noe.Models.Entities;

public class Usuario
{
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;
        
        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [StringLength(255)]
        public string GoogleId { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string ImagenUrl { get; set; } = string.Empty;
        
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        
        public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;
        
        public bool Activo { get; set; } = true;
}
