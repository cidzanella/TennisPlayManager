using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TennisRanking.Models
{
    public class HorarioHabilitadoDesafio
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
