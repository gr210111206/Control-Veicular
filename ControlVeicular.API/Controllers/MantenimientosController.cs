using ControlVeicular.API.DTOs;
using ControlVeicular.API.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ControlVeicular.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientosController : ControllerBase
    {
        private readonly IMongoCollection<Mantenimiento> _mantenimientosCollection;

        public MantenimientosController(IMongoDatabase mongoDatabase)
        {
            _mantenimientosCollection = mongoDatabase.GetCollection<Mantenimiento>("Mantenimientos");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MantenimientoResponseDTO>>> GetMantenimientos([FromQuery] int skip = 0, [FromQuery] int limit = 100)
        {
            var mantenimientos = await _mantenimientosCollection.Find(_ => true)
                .Skip(skip)
                .Limit(limit)
                .ToListAsync();

            var response = mantenimientos.Select(m => new MantenimientoResponseDTO
            {
                IdMantenimiento = m.IdMantenimiento,
                IdVehiculo = m.IdVehiculo,
                TipoServicio = m.TipoServicio,
                KmRealizado = m.KmRealizado,
                KmProximoServicio = m.KmProximoServicio,
                Estado = m.Estado
            });

            return Ok(response);
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

            await _mantenimientosCollection.InsertOneAsync(nuevoMantenimiento);

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
