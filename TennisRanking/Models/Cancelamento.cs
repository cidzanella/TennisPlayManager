using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TennisRanking.Models
{
    public class Cancelamento
    {
        [Key, Required]
        public int Id { get; set; }
        
        [Required]
        public int MotivoCancelamentoId { get; set; }
        
        [Required]
        public int CanceladoPorTenistaId { get; set; }
        
        [Required]
        public DateTime DataCancelamento { get; set; }
        
        public bool GerouWO { get; set; }
        
        public bool GerouMulta { get; set; }

    }
}
