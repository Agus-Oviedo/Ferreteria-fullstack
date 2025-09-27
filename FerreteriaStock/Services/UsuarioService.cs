using FerreteriaStock.Models;
using System.Net.Http.Json;

namespace FerreteriaStock.Services
{
    public class UsuarioService
    {
        private readonly HttpClient _http;

        public UsuarioService(HttpClient http)
        {
            _http = http;
        }

        // 🔑 Login
        public async Task<Usuario?> ValidarLoginAsync(string email, string clave)
        {
            // El backend espera "Usuario" en lugar de "Email"
            var request = new
            {
                Usuario = email,
                Clave = clave
            };

            var response = await _http.PostAsJsonAsync("api/login", request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Usuario>();
            }

            return null;
        }

        // 👥 Obtener todos los usuarios
        public async Task<List<Usuario>> ObtenerTodosAsync()
        {
            return await _http.GetFromJsonAsync<List<Usuario>>("api/usuarios")
                   ?? new List<Usuario>();
        }

        // ➕ Crear usuario con manejo de errores
        public async Task AgregarAsync(Usuario usuario)
        {
            var response = await _http.PostAsJsonAsync("api/usuarios", usuario);

            if (!response.IsSuccessStatusCode)
            {
                // 📌 Lee el mensaje de error que devuelve la API (ej. "El email ya está en uso.")
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException(errorMessage);
            }
        }

        // ✏️ Editar usuario
        public async Task EditarAsync(Usuario usuario)
        {
            var response = await _http.PutAsJsonAsync($"api/usuarios/{usuario.Id}", usuario);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException(errorMessage);
            }
        }

        // 🗑 Eliminar usuario
        public async Task EliminarAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/usuarios/{id}");

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException(errorMessage);
            }
        }
    }
}
