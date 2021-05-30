using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisRanking.Models;

namespace TennisRanking.ViewModels
{
    public class ResultadoVM
    {
        public Tenista TenistaA { get; set; }

        public Tenista TenistaB { get; set; }

        public Jogo Jogo { get; set; }

        public Placar Placar { get; set; }

        public IEnumerable<Tenista> Tenistas { get; set; }

    }
}
