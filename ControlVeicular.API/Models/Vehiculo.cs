using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ControlVeicular.API.Models
{
    public class Vehiculo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string NumeroUnidad { get; set; } = string.Empty;
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int? Anio { get; set; }
        public string Placas { get; set; } = string.Empty;
        public int? KilometrajeActual { get; set; } = 0;
        public string? Estado { get; set; } = "Disponible";
        public decimal? RendimientoKmL { get; set; }
    }
}
