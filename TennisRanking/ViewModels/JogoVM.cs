using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisRanking.Models;

namespace TennisRanking.ViewModels
{
    public class JogoVM
    {
        public Tenista TenistaA { get; set; }
        public Tenista TenistaB { get; set; }
        public Jogo Jogo { get; set; }
        public Agenda Agenda { get; set; }
        public Quadra Quadra { get; set; }
        public IEnumerable<Agenda> AgendasPossiveis { get; set; }
        public Placar Placar { get; set; }
    }
}
