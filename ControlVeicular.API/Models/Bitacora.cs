using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlVeicular.API.Models
{
    [Table("Bitacoras")]
    public class Bitacora
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_bitacora")]
        public int IdBitacora { get; set; }

        [Required]
        [Column("id_vehiculo")]
        public int IdVehiculo { get; set; }

        [Required]
        [Column("id_usuario")]
        public int IdUsuario { get; set; }

        [Column("fecha_salida")]
        public DateTime? FechaSalida { get; set; }

        [Column("fecha_retorno")]
        public DateTime? FechaRetorno { get; set; }

        [Column("km_inicial")]
        public int? KmInicial { get; set; }

        [Column("km_final")]
        public int? KmFinal { get; set; }

        [MaxLength(255)]
        public string? Destino { get; set; }

        [MaxLength(255)]
        public string? Motivo { get; set; }

        [MaxLength(255)]
        [Column("evidencia_url")]
        public string? EvidenciaUrl { get; set; }

        [ForeignKey("IdVehiculo")]
        public virtual Vehiculo? Vehiculo { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuario? Usuario { get; set; }
    }
}
