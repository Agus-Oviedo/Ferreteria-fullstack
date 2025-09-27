using System.ComponentModel.DataAnnotations;

namespace FerreteriaAPI.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string UsuarioAcceso { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Clave { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Rol { get; set; } = "Empleado"; // Valores esperados: "Admin", "Empleado"

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
