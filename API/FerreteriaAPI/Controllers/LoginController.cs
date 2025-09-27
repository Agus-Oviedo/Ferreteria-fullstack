using FerreteriaAPI.Data;
using FerreteriaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Usuario) || string.IsNullOrWhiteSpace(request.Clave))
            {
                return BadRequest("Email y clave son obligatorios.");
            }

            var usuario = _context.Usuarios.FirstOrDefault(u =>
                u.Email.ToLower() == request.Usuario.ToLower() && u.Clave == request.Clave);

            if (usuario == null)
                return Unauthorized("Credenciales incorrectas.");

            return Ok(usuario);
        }
    }
}
