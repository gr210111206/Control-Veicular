using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ControlVeicular.API.Models
{
    public class Mantenimiento
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? IdMantenimiento { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string IdVehiculo { get; set; } = string.Empty;

        public string? TipoServicio { get; set; }
        public int? KmRealizado { get; set; }
        public int? KmProximoServicio { get; set; }
        public string? Estado { get; set; } = "Pendiente";
    }
}
