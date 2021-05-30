using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisRanking.Models;

namespace TennisRanking.ViewModels
{
    public class DesafioVM : JogoVM
    {
        public HorarioHabilitadoDesafio HorarioHabilitadoDesafio { get; set; }
        public byte PosicaoTenistaA { get; set; }
        public byte PosicaoTenistaB { get; set; }

    }
}
