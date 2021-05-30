using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TennisRanking.Models
{
    public class Agenda
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public int QuadraId { get; set; }

        [Required]
        public int FinalidadeUsoQuadraId { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public DateTime HoraInicial { get; set; }

        [Required]
        public DateTime HoraFinal { get; set; }

        public bool EhPreReserva { get; set; } //avaliar se vai usar o conceito

        public bool FoiCancelada { get; set; }

        public string DisplayAgenda
        {
            get
            {
                return $"{ Data.ToString("ddd dd/MM/yyyy").ToUpper() } - {HoraInicial.ToString("HH:mm")} - Quadra #{QuadraId}";
            }
        }
    }
}
