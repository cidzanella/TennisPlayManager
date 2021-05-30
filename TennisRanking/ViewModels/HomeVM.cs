using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisRanking.Models;

namespace TennisRanking.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<DesafioVM> DesafiosVM { get; set; }
        public IEnumerable<AmistosoVM> AmistososVM { get; set; }
        public IEnumerable<String> SponsorsLogo { get; set; }
        public IEnumerable<JogoVM> JogosVM { get; set; }
    }
}
