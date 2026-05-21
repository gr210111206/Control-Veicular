using ControlVeicular.API.Data;
using ControlVeicular.API.DTOs;
using ControlVeicular.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlVeicular.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientosController : ControllerBase
    {
        private readonly SicvContext _context;

        public MantenimientosController(SicvContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MantenimientoResponseDTO>>> GetMantenimientos([FromQuery] int skip = 0, [FromQuery] int limit = 100)
        {
            var mantenimientos = await _context.Mantenimientos
                .Skip(skip)
                .Take(limit)
                .Select(m => new MantenimientoResponseDTO
                {
                    IdMantenimiento = m.IdMantenimiento,
                    IdVehiculo = m.IdVehiculo,
                    TipoServicio = m.TipoServicio,
                    KmRealizado = m.KmRealizado,
                    KmProximoServicio = m.KmProximoServicio,
                    Estado = m.Estado
                })
                .ToListAsync();

            return Ok(mantenimientos);
        }

        [HttpPost]
        public async Task<ActionResult<MantenimientoResponseDTO>> PostMantenimiento(MantenimientoCreateDTO mantenimientoDto)
        {
            var nuevoMantenimiento = new Mantenimiento
            {
                IdVehiculo = mantenimientoDto.IdVehiculo,
                TipoServicio = mantenimientoDto.TipoServicio,
                KmRealizado = mantenimientoDto.KmRealizado,
                KmProximoServicio = mantenimientoDto.KmProximoServicio,
                Estado = mantenimientoDto.Estado
            };

            _context.Mantenimientos.Add(nuevoMantenimiento);
            await _context.SaveChangesAsync();

            var responseDto = new MantenimientoResponseDTO
            {
                IdMantenimiento = nuevoMantenimiento.IdMantenimiento,
                IdVehiculo = nuevoMantenimiento.IdVehiculo,
                TipoServicio = nuevoMantenimiento.TipoServicio,
                KmRealizado = nuevoMantenimiento.KmRealizado,
                KmProximoServicio = nuevoMantenimiento.KmProximoServicio,
                Estado = nuevoMantenimiento.Estado
            };

            return CreatedAtAction(nameof(GetMantenimientos), new { id = nuevoMantenimiento.IdMantenimiento }, responseDto);
        }
    }
}
