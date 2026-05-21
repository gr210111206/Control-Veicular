using ControlVeicular.API.Data;
using ControlVeicular.API.DTOs;
using ControlVeicular.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlVeicular.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly SicvContext _context;

        public VehiculosController(SicvContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehiculoResponseDTO>>> GetVehiculos([FromQuery] int skip = 0, [FromQuery] int limit = 100)
        {
            var vehiculos = await _context.Vehiculos
                .Skip(skip)
                .Take(limit)
                .Select(v => new VehiculoResponseDTO
                {
                    Id = v.Id,
                    NumeroUnidad = v.NumeroUnidad,
                    Marca = v.Marca,
                    Modelo = v.Modelo,
                    Anio = v.Anio,
                    Placas = v.Placas,
                    KilometrajeActual = v.KilometrajeActual,
                    Estado = v.Estado,
                    RendimientoKmL = v.RendimientoKmL
                })
                .ToListAsync();

            return Ok(vehiculos);
        }

        [HttpPost]
        public async Task<ActionResult<VehiculoResponseDTO>> PostVehiculo(VehiculoCreateDTO vehiculoDto)
        {
            if (await _context.Vehiculos.AnyAsync(v => v.Placas == vehiculoDto.Placas))
            {
                return BadRequest(new { detail = "Las placas ya están registradas" });
            }

            var nuevoVehiculo = new Vehiculo
            {
                NumeroUnidad = vehiculoDto.NumeroUnidad,
                Marca = vehiculoDto.Marca,
                Modelo = vehiculoDto.Modelo,
                Anio = vehiculoDto.Anio,
                Placas = vehiculoDto.Placas,
                KilometrajeActual = vehiculoDto.KilometrajeActual,
                Estado = vehiculoDto.Estado,
                RendimientoKmL = vehiculoDto.RendimientoKmL
            };

            _context.Vehiculos.Add(nuevoVehiculo);
            await _context.SaveChangesAsync();

            var responseDto = new VehiculoResponseDTO
            {
                Id = nuevoVehiculo.Id,
                NumeroUnidad = nuevoVehiculo.NumeroUnidad,
                Marca = nuevoVehiculo.Marca,
                Modelo = nuevoVehiculo.Modelo,
                Anio = nuevoVehiculo.Anio,
                Placas = nuevoVehiculo.Placas,
                KilometrajeActual = nuevoVehiculo.KilometrajeActual,
                Estado = nuevoVehiculo.Estado,
                RendimientoKmL = nuevoVehiculo.RendimientoKmL
            };

            return CreatedAtAction(nameof(GetVehiculos), new { id = nuevoVehiculo.Id }, responseDto);
        }
    }
}
