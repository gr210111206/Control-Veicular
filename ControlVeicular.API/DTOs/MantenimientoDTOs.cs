namespace ControlVeicular.API.DTOs
{
    public class MantenimientoCreateDTO
    {
        public string IdVehiculo { get; set; } = string.Empty;
        public string? TipoServicio { get; set; }
        public int? KmRealizado { get; set; }
        public int? KmProximoServicio { get; set; }
        public string? Estado { get; set; } = "Pendiente";
    }

    public class MantenimientoResponseDTO
    {
        public string? IdMantenimiento { get; set; }
        public string IdVehiculo { get; set; } = string.Empty;
        public string? TipoServicio { get; set; }
        public int? KmRealizado { get; set; }
        public int? KmProximoServicio { get; set; }
        public string? Estado { get; set; }
    }
}
