using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlVeicular.API.Models
{
    [Table("Mantenimientos")]
    public class Mantenimiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_mantenimiento")]
        public int IdMantenimiento { get; set; }

        [Required]
        [Column("id_vehiculo")]
        public int IdVehiculo { get; set; }

        [MaxLength(100)]
        [Column("tipo_servicio")]
        public string? TipoServicio { get; set; }

        [Column("km_realizado")]
        public int? KmRealizado { get; set; }

        [Column("km_proximo_servicio")]
        public int? KmProximoServicio { get; set; }

        public string? Estado { get; set; } = "Pendiente";

        [ForeignKey("IdVehiculo")]
        public virtual Vehiculo? Vehiculo { get; set; }
    }
}
