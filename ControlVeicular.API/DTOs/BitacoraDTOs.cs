namespace ControlVeicular.API.DTOs
{
    public class BitacoraCreateDTO
    {
        public int IdVehiculo { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? FechaSalida { get; set; }
        public DateTime? FechaRetorno { get; set; }
        public int? KmInicial { get; set; }
        public int? KmFinal { get; set; }
        public string? Destino { get; set; }
        public string? Motivo { get; set; }
        public string? EvidenciaUrl { get; set; }
    }

    public class BitacoraResponseDTO
    {
        public int IdBitacora { get; set; }
        public int IdVehiculo { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? FechaSalida { get; set; }
        public DateTime? FechaRetorno { get; set; }
        public int? KmInicial { get; set; }
        public int? KmFinal { get; set; }
        public string? Destino { get; set; }
        public string? Motivo { get; set; }
        public string? EvidenciaUrl { get; set; }
    }
}
