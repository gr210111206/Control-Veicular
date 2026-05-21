namespace ControlVeicular.API.DTOs
{
    public class BitacoraCreateDTO
    {
        public string IdVehiculo { get; set; } = string.Empty;
        public string IdUsuario { get; set; } = string.Empty;
        public DateTime? FechaSalida { get; set; }
        public DateTime? FechaRetorno { get; set; }
        public int? KmInicial { get; set; }
        public int? KmFinal { get; set; }
        public string? Destino { get; set; }
        public string? Motivo { get; set; }
        public string? EvidenciaUrl { get; set; }
        public string? Notas { get; set; }
        public List<string>? Pasajeros { get; set; }
    }

    public class BitacoraResponseDTO
    {
        public string? IdBitacora { get; set; }
        public string IdVehiculo { get; set; } = string.Empty;
        public string IdUsuario { get; set; } = string.Empty;
        public DateTime? FechaSalida { get; set; }
        public DateTime? FechaRetorno { get; set; }
        public int? KmInicial { get; set; }
        public int? KmFinal { get; set; }
        public string? Destino { get; set; }
        public string? Motivo { get; set; }
        public string? EvidenciaUrl { get; set; }
        public string? Notas { get; set; }
        public List<string>? Pasajeros { get; set; }
    }
}
