using System.ComponentModel.DataAnnotations;

namespace FerreteriaStock.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(150, ErrorMessage = "El nombre no puede superar los 150 caracteres")]
        public string? Nombre { get; set; }

        [MaxLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres")]
        public string? Descripcion { get; set; }

        public string? Imagen { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser mayor o igual a 0")]
        public decimal Precio { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock debe ser mayor o igual a 0")]
        public int Stock { get; set; }

        public Producto()
        {
            Nombre = string.Empty;
            Descripcion = string.Empty;
            Imagen = string.Empty;
        }
    }
}
