using ControlVeicular.API.Data;
using ControlVeicular.API.DTOs;
using ControlVeicular.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlVeicular.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitacorasController : ControllerBase
    {
        private readonly SicvContext _context;

        public BitacorasController(SicvContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BitacoraResponseDTO>>> GetBitacoras([FromQuery] int skip = 0, [FromQuery] int limit = 100)
        {
            var bitacoras = await _context.Bitacoras
                .Skip(skip)
                .Take(limit)
                .Select(b => new BitacoraResponseDTO
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
                    EvidenciaUrl = b.EvidenciaUrl
                })
                .ToListAsync();

            return Ok(bitacoras);
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
                EvidenciaUrl = bitacoraDto.EvidenciaUrl
            };

            _context.Bitacoras.Add(nuevaBitacora);
            await _context.SaveChangesAsync();

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
                EvidenciaUrl = nuevaBitacora.EvidenciaUrl
            };

            return CreatedAtAction(nameof(GetBitacoras), new { id = nuevaBitacora.IdBitacora }, responseDto);
        }
    }
}
