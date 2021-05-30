using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TennisRanking.Data;
using TennisRanking.Models;

namespace TennisRanking.Controllers
{
    public class MotivoBloqueioController : Controller
    {
        private ApplicationDbContext _context;

        public MotivoBloqueioController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            List<MotivoBloqueio> motivos = _context.MotivosBloqueio.ToList();
            return View(motivos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [Route("motivobloqueio/read/{id}")]
        public IActionResult Read(int? id)
        {
            MotivoBloqueio motivo = _context.MotivosBloqueio.SingleOrDefault(m => m.Id == id);
            
            if (motivo == null)
                return NotFound();
            
            return View(motivo);
        }

        public IActionResult ReadAll()
        {
            return View("Index");
        }

        public IActionResult Update(int Id)
        {
            return View();
        }

        public IActionResult Delete()
        {

            return View();
        }

    }
}
