namespace FerreteriaStock.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string UsuarioAcceso { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Clave { get; set; }
        public string Rol { get; set; }
    }
}
