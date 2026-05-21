using ControlVeicular.API.Data;
using ControlVeicular.API.DTOs;
using ControlVeicular.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlVeicular.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly SicvContext _context;

        public UsuariosController(SicvContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioResponseDTO>>> GetUsuarios([FromQuery] int skip = 0, [FromQuery] int limit = 100)
        {
            var usuarios = await _context.Usuarios
                .Skip(skip)
                .Take(limit)
                .Select(u => new UsuarioResponseDTO
                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    Apellidos = u.Apellidos,
                    Email = u.Email,
                    Rol = u.Rol,
                    NumeroEmpleado = u.NumeroEmpleado
                })
                .ToListAsync();

            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioResponseDTO>> PostUsuario(UsuarioCreateDTO usuarioDto)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Email == usuarioDto.Email))
            {
                return BadRequest(new { detail = "El email ya está registrado" });
            }

            var nuevoUsuario = new Usuario
            {
                Nombre = usuarioDto.Nombre,
                Apellidos = usuarioDto.Apellidos,
                Email = usuarioDto.Email,
                PasswordHash = usuarioDto.Password, // Simple mapping, in a real app hash it
                Rol = usuarioDto.Rol,
                NumeroEmpleado = usuarioDto.NumeroEmpleado
            };

            _context.Usuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync();

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
