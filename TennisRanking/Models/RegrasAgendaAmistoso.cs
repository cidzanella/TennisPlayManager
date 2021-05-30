using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TennisRanking.Models
{
    public class RegrasAgendaAmistoso
    {
        [Key, Required]
        public int Id { get; set; }
        public byte MinimoDiasEntreAmistosos { get; set; }
        public byte AntecedenciaMaximaDias { get; set; }
        public byte PrazoMinutosCancelamentoSemMulta { get; set; }
        public byte PrazoMinutosReagendamentoSemWO { get; set; }
        public byte MultaWO { get; set; }
        public DateTime HorarioLiberarAgendamento { get; set; }
    }
}
