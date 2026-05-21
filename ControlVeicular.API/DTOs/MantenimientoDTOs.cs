namespace ControlVeicular.API.DTOs
{
    public class MantenimientoCreateDTO
    {
        public int IdVehiculo { get; set; }
        public string? TipoServicio { get; set; }
        public int? KmRealizado { get; set; }
        public int? KmProximoServicio { get; set; }
        public string? Estado { get; set; } = "Pendiente";
    }

    public class MantenimientoResponseDTO
    {
        public int IdMantenimiento { get; set; }
        public int IdVehiculo { get; set; }
        public string? TipoServicio { get; set; }
        public int? KmRealizado { get; set; }
        public int? KmProximoServicio { get; set; }
        public string? Estado { get; set; }
    }
}
