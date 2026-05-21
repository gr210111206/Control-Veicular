using ControlVeicular.API.DTOs;
using ControlVeicular.API.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ControlVeicular.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitacorasController : ControllerBase
    {
        private readonly IMongoCollection<Bitacora> _bitacorasCollection;

        public BitacorasController(IMongoDatabase mongoDatabase)
        {
            _bitacorasCollection = mongoDatabase.GetCollection<Bitacora>("Bitacoras");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BitacoraResponseDTO>>> GetBitacoras([FromQuery] int skip = 0, [FromQuery] int limit = 100)
        {
            var bitacoras = await _bitacorasCollection.Find(_ => true)
                .Skip(skip)
                .Limit(limit)
                .ToListAsync();

            var response = bitacoras.Select(b => new BitacoraResponseDTO
            {
                IdBitacora = b.IdBitacora,
                IdVehiculo = b.IdVehiculo,
                IdUsuario = b.IdUsuario,
                FechaSalida = b.FechaSalida,
                FechaRetorno = b.FechaRetorno,
                KmInicial = b.KmInicial,
                KmFinal = b.KmFinal,
                Destino = b.Destino,
                Motivo = b.Motivo,
                EvidenciaUrl = b.EvidenciaUrl,
                Notas = b.Notas,
                Pasajeros = b.Pasajeros
            });

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<BitacoraResponseDTO>> PostBitacora(BitacoraCreateDTO bitacoraDto)
        {
            var nuevaBitacora = new Bitacora
            {
                IdVehiculo = bitacoraDto.IdVehiculo,
                IdUsuario = bitacoraDto.IdUsuario,
                FechaSalida = bitacoraDto.FechaSalida,
                FechaRetorno = bitacoraDto.FechaRetorno,
                KmInicial = bitacoraDto.KmInicial,
                KmFinal = bitacoraDto.KmFinal,
                Destino = bitacoraDto.Destino,
                Motivo = bitacoraDto.Motivo,
                EvidenciaUrl = bitacoraDto.EvidenciaUrl,
                Notas = bitacoraDto.Notas,
                Pasajeros = bitacoraDto.Pasajeros
            };

            await _bitacorasCollection.InsertOneAsync(nuevaBitacora);

            var responseDto = new BitacoraResponseDTO
            {
                IdBitacora = nuevaBitacora.IdBitacora,
                IdVehiculo = nuevaBitacora.IdVehiculo,
                IdUsuario = nuevaBitacora.IdUsuario,
                FechaSalida = nuevaBitacora.FechaSalida,
                FechaRetorno = nuevaBitacora.FechaRetorno,
                KmInicial = nuevaBitacora.KmInicial,
                KmFinal = nuevaBitacora.KmFinal,
                Destino = nuevaBitacora.Destino,
                Motivo = nuevaBitacora.Motivo,
                EvidenciaUrl = nuevaBitacora.EvidenciaUrl,
                Notas = nuevaBitacora.Notas,
                Pasajeros = nuevaBitacora.Pasajeros
            };

            return CreatedAtAction(nameof(GetBitacoras), new { id = nuevaBitacora.IdBitacora }, responseDto);
        }
    }
}
