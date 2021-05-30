using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisRanking.Models;

namespace TennisRanking.ViewModels
{
    public class TenistaPerfilVM
    {
        public Tenista Tenista { get; set; }

        public string NomeCidade { get; set; }

        public byte PosicaoRanking { get; set; }
    }
}
