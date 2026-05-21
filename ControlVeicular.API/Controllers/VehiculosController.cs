using ControlVeicular.API.DTOs;
using ControlVeicular.API.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ControlVeicular.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly IMongoCollection<Vehiculo> _vehiculosCollection;

        public VehiculosController(IMongoDatabase mongoDatabase)
        {
            _vehiculosCollection = mongoDatabase.GetCollection<Vehiculo>("Vehiculos");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehiculoResponseDTO>>> GetVehiculos([FromQuery] int skip = 0, [FromQuery] int limit = 100)
        {
            var vehiculos = await _vehiculosCollection.Find(_ => true)
                .Skip(skip)
                .Limit(limit)
                .ToListAsync();

            var response = vehiculos.Select(v => new VehiculoResponseDTO
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
            });

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<VehiculoResponseDTO>> PostVehiculo(VehiculoCreateDTO vehiculoDto)
        {
            var existingVehiculo = await _vehiculosCollection.Find(v => v.Placas == vehiculoDto.Placas).FirstOrDefaultAsync();
            if (existingVehiculo != null)
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

            await _vehiculosCollection.InsertOneAsync(nuevoVehiculo);

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
