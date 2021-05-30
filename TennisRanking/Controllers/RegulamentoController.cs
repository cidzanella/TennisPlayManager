using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TennisRanking.Controllers
{
    public class RegulamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
