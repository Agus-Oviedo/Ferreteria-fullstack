using FerreteriaStock.Models;
using System.Net.Http.Json;

namespace FerreteriaStock.Services
{
    public class ProductoService
    {
        private readonly HttpClient _http;

        public ProductoService(HttpClient http)
        {
            _http = http;
        }

        // 🔹 Obtener todos los productos
        public async Task<List<Producto>> GetProductosAsync()
        {
            return await _http.GetFromJsonAsync<List<Producto>>("api/productos")
                   ?? new List<Producto>();
        }

        // 🔹 Obtener producto por Id
        public async Task<Producto?> GetProductoByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Producto>($"api/productos/{id}");
        }

        // 🔹 Agregar producto
        public async Task AddProductoAsync(Producto producto)
        {
            await _http.PostAsJsonAsync("api/productos", producto);
        }

        // 🔹 Actualizar producto
        public async Task UpdateProductoAsync(Producto producto)
        {
            await _http.PutAsJsonAsync($"api/productos/{producto.Id}", producto);
        }

        // 🔹 Eliminar producto
        public async Task DeleteProductoAsync(int id)
        {
            await _http.DeleteAsync($"api/productos/{id}");
        }
    }
}
