using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TennisRanking.Models
{
    public class Cidade
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
