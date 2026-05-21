using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ControlVeicular.API.Models
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public string NumeroEmpleado { get; set; } = string.Empty;
    }
}
