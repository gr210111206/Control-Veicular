using ControlVeicular.API.DTOs;
using ControlVeicular.API.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ControlVeicular.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IMongoCollection<Usuario> _usuariosCollection;

        public UsuariosController(IMongoDatabase mongoDatabase)
        {
            _usuariosCollection = mongoDatabase.GetCollection<Usuario>("Usuarios");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioResponseDTO>>> GetUsuarios([FromQuery] int skip = 0, [FromQuery] int limit = 100)
        {
            var usuarios = await _usuariosCollection.Find(_ => true)
                .Skip(skip)
                .Limit(limit)
                .ToListAsync();

            var response = usuarios.Select(u => new UsuarioResponseDTO
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Apellidos = u.Apellidos,
                Email = u.Email,
                Rol = u.Rol,
                NumeroEmpleado = u.NumeroEmpleado
            });

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioResponseDTO>> PostUsuario(UsuarioCreateDTO usuarioDto)
        {
            var existingUser = await _usuariosCollection.Find(u => u.Email == usuarioDto.Email).FirstOrDefaultAsync();
            if (existingUser != null)
            {
                return BadRequest(new { detail = "El email ya está registrado" });
            }

            var nuevoUsuario = new Usuario
            {
                Nombre = usuarioDto.Nombre,
                Apellidos = usuarioDto.Apellidos,
                Email = usuarioDto.Email,
                PasswordHash = usuarioDto.Password,
                Rol = usuarioDto.Rol,
                NumeroEmpleado = usuarioDto.NumeroEmpleado
            };

            await _usuariosCollection.InsertOneAsync(nuevoUsuario);

            var responseDto = new UsuarioResponseDTO
            {
                Id = nuevoUsuario.Id,
                Nombre = nuevoUsuario.Nombre,
                Apellidos = nuevoUsuario.Apellidos,
                Email = nuevoUsuario.Email,
                Rol = nuevoUsuario.Rol,
                NumeroEmpleado = nuevoUsuario.NumeroEmpleado
            };

            return CreatedAtAction(nameof(GetUsuarios), new { id = nuevoUsuario.Id }, responseDto);
        }
    }
}
