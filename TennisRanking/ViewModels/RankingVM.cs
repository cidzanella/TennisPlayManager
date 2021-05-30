using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisRanking.Models;

namespace TennisRanking.ViewModels
{
    public class RankingVM
    {
        public Tenista Tenista { get; set; }

        public Sexo Sexo { get; set; }

        public IEnumerable<Tenista> Tenistas { get; set; }
        
        public IEnumerable<RankingTenistas> Ranking{ get; set; }
    }
}
