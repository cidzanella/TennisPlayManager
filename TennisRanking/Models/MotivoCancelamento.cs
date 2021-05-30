using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TennisRanking.Models
{
    public class MotivoCancelamento
    {
        [Key, Required]
        public int Id { get; set; }
     
        [Required]
        public string Motivo { get; set; }
    }
}
