using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TennisRanking.Data;

namespace TennisRanking.Controllers
{
    public class HorarioQuadraController : Controller
    {
        ApplicationDbContext _context;

        public HorarioQuadraController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult ReservarQuadra()
        {
            // busca agendas livres para os próximos 30 dias
            


            return View();
        }

        public IActionResult ConfigurarHorariosAmistosos()
        {
            return View();

        }

        public IActionResult ConfigurarHorariosDesafios()
        {
                return View();

        }

    }
}
