namespace ControlVeicular.API.DTOs
{
    public class VehiculoCreateDTO
    {
        public string NumeroUnidad { get; set; } = string.Empty;
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int? Anio { get; set; }
        public string Placas { get; set; } = string.Empty;
        public int? KilometrajeActual { get; set; } = 0;
        public string? Estado { get; set; } = "Disponible";
        public decimal? RendimientoKmL { get; set; }
    }

    public class VehiculoResponseDTO
    {
        public string? Id { get; set; }
        public string NumeroUnidad { get; set; } = string.Empty;
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int? Anio { get; set; }
        public string Placas { get; set; } = string.Empty;
        public int? KilometrajeActual { get; set; }
        public string? Estado { get; set; }
        public decimal? RendimientoKmL { get; set; }
    }
}
