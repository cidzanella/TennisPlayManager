using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TennisRanking.Models
{
    public class RankingTenistas
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public byte Sexo { get; set; }

        [Required]
        public byte Posicao { get; set; }

        public Tenista Tenista { get; set; }

        [Required]
        public int TenistaId { get; set; }
        
        [Required]
        public DateTime DataPosicaoAtual { get; set; }
        
        public byte PosicaoAnterior { get; set; }
        
        public DateTime DataPosicaoAnterior { get; set; }
        
        public byte PosicaoInicial { get; set; }
        
        public DateTime DataPosicaoInicial { get; set; }


    }
}
