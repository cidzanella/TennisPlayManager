using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisRanking.Models;

namespace TennisRanking.ViewModels
{
    public class AmistosoVM : JogoVM
    {
        public HorarioHabilitadoAmistoso HorarioHabilitadoAmistoso { get; set; }
        public IEnumerable<Tenista> Tenistas { get; set; }
        public RankingTenistas Ranking { get; set; }

    }
}
