using System.ComponentModel.DataAnnotations;

namespace FerreteriaStock.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La clave es obligatoria")]
        public string Clave { get; set; } = string.Empty;
    }
}
