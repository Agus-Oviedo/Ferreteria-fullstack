using FerreteriaStock.Models;

namespace FerreteriaStock.Services
{
    /// <summary>
    /// Maneja el estado de la sesión del usuario en el cliente.
    /// Es un servicio singleton, inyectado en Blazor.
    /// </summary>
    public class SesionUsuario
    {
        /// <summary>
        /// Usuario actualmente logueado. Null si no hay sesión activa.
        /// </summary>
        public Usuario? UsuarioActual { get; private set; }

        /// <summary>
        /// Indica si hay un usuario logueado en este momento.
        /// </summary>
        public bool EstaLogueado => UsuarioActual != null;

        /// <summary>
        /// Evento que se dispara cuando se inicia o cierra sesión.
        /// Permite actualizar componentes que dependan de la sesión.
        /// </summary>
        public event Action? OnCambioSesion;

        /// <summary>
        /// Inicia la sesión con un usuario válido.
        /// </summary>
        public void IniciarSesion(Usuario usuario)
        {
            UsuarioActual = usuario;
            OnCambioSesion?.Invoke();
        }

        /// <summary>
        /// Cierra la sesión actual.
        /// </summary>
        public void CerrarSesion()
        {
            UsuarioActual = null;
            OnCambioSesion?.Invoke();
        }
    }
}
