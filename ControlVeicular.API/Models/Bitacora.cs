using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ControlVeicular.API.Models
{
    public class Bitacora
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? IdBitacora { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string IdVehiculo { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.ObjectId)]
        public string IdUsuario { get; set; } = string.Empty;

        public DateTime? FechaSalida { get; set; }
        public DateTime? FechaRetorno { get; set; }
        public int? KmInicial { get; set; }
        public int? KmFinal { get; set; }
        public string? Destino { get; set; }
        public string? Motivo { get; set; }
        public string? EvidenciaUrl { get; set; }
    }
}
