using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TennisRanking.Models
{
    // Classe com os dados do jogo: amistoso, desafio
    public class Jogo
    {
        [Key, Required]
        public int Id { get; set; }
        
        public int JogoOriginalId { get; set; }

        [Required]
        public int TenistaAId { get; set; }
        
        [Required]
        public int TenistaBId { get; set; }
        
        [Required]
        [Display(Name ="Agenda")]
        public int AgendaId { get; set; }

        public Agenda Agenda { get; set; }

        [Required]
        public bool EhDesafio { get; set; }

        [Required]
        public DateTime DataConvite { get; set; }
        
        public DateTime DataRespostaConvite { get; set; }
        
        public int RespostaConviteId { get; set; }
        
        public int TenistaVencedorId { get; set; }

        [Display(Name ="Tenista Ausente (W.O.)")]
        public int TenistaAusenteWOId { get; set; }

        [Display(Name="Tenista Desistente")]
        public int TenistaDesistenteId { get; set; }
        
        public int CancelamentoId { get; set; }

        public int PlacarId { get; set; }

        public string TokenConfirmacao { get; set; }

    }
}
