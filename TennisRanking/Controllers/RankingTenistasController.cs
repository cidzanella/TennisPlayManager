using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TennisRanking.Data;
using TennisRanking.ViewModels;

namespace TennisRanking.Controllers
{
    public class RankingTenistasController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        // injeção de dependência a partir do DBContext criado em Startup.ConfigureServices
        public RankingTenistasController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Ranking(Sexo sexo)
        {
            RankingVM rankingVM = new RankingVM
            {
                Sexo = sexo,
                Tenistas = _context.Tenistas,
                Ranking = _context.RankingTenistas.Include(t => t.Tenista).Where(t => t.Sexo == (byte)sexo).ToList().OrderBy(t => t.Posicao)
            };
            
            return View("Ranking", rankingVM);
        }

        // Adiciona um tenista na lista
        public IActionResult AdicionarTenista(int id)
        {
            return View();
        }

        // Remover um tenista da lista
        public IActionResult RemoverTenista(int id)
        {
            return View();
        }

        // Define uma nova posição para um tenista da lista
        public IActionResult PosicionarTenista(int id)
        {
            return View();
        }

    }
}
