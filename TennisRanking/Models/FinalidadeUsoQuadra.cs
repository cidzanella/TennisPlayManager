using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TennisRanking.Models
{
    public class FinalidadeUsoQuadra
    {
        [Key, Required]
        public byte Id { get; set; }
        [Required]
        public string Finalidade { get; set; } //aula, ranking, amistoso
        [Required]
        public int TempoReservaEmMinutos { get; set; } //cada finalidade tem um tempo de ocupoação em minutos: ex aula 30min amistoso 60min ranking 75min - a partir do horário inicial adiciona tempo para calcular próximos horario
    }
}
