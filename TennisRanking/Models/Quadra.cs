using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TennisRanking.Models
{
    public class Quadra
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int FinalidadeUsoQuadraId { get; set; }
    }
}
