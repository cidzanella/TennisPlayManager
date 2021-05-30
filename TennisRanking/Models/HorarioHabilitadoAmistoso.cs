using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TennisRanking.Models
{
    public class HorarioHabilitadoAmistoso
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public byte DiaSemana { get; set; }
        [Required]
        public DateTime HorarioInicial { get; set; }
        [Required]
        public DateTime HorarioFinal { get; set; }
        [Required]
        public int QuadraId { get; set; }
    }
}
