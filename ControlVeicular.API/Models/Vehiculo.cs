using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlVeicular.API.Models
{
    [Table("Vehiculos")]
    public class Vehiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("numero_unidad")]
        public string NumeroUnidad { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Marca { get; set; }

        [MaxLength(100)]
        public string? Modelo { get; set; }

        public int? Anio { get; set; }

        [Required]
        [MaxLength(50)]
        public string Placas { get; set; } = string.Empty;

        [Column("kilometraje_actual")]
        public int? KilometrajeActual { get; set; } = 0;

        public string? Estado { get; set; } = "Disponible";

        [Column("rendimiento_kmL", TypeName = "decimal(5,2)")]
        public decimal? RendimientoKmL { get; set; }
    }
}
