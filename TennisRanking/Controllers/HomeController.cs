using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TennisRanking.Data;
using TennisRanking.Models;
using TennisRanking.ViewModels;

namespace TennisRanking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            List<DesafioVM> desafiosVM = new List<DesafioVM>();
            List<AmistosoVM> amistososVM = new List<AmistosoVM>();
            List<RankingTenistas> rankingTenistas = _context.RankingTenistas.ToList();
            List<Tenista> tenistas = _context.Tenistas.ToList();

            //recupera agenda de desafios
            //busca jogos que o tenista logado aparece como desafiante ou defensor e que ainda não tenha TenistaVencedorId  ou não tenha sido cancelado, indicando que está agendado
            IEnumerable<Jogo> desafiosAgendados = _context.Jogos.Include(j => j.Agenda).Where(j => j.EhDesafio == true
                                        && j.CancelamentoId == 0 && j.TenistaVencedorId == 0
                                        && j.Agenda.Data.Date >= DateTime.Now.Date).ToList();
            foreach (Jogo desafio in desafiosAgendados)
            {
                DesafioVM desafioVM = new DesafioVM();

                desafioVM.Jogo = desafio;
                desafioVM.TenistaA = tenistas.FirstOrDefault(t => t.Id == desafio.TenistaAId);
                desafioVM.TenistaB = tenistas.FirstOrDefault(t => t.Id == desafio.TenistaBId);
                desafioVM.PosicaoTenistaA = rankingTenistas.FirstOrDefault(r => r.TenistaId == desafio.TenistaAId).Posicao;
                desafioVM.PosicaoTenistaB = rankingTenistas.FirstOrDefault(r => r.TenistaId == desafio.TenistaBId).Posicao;
                desafiosVM.Add(desafioVM);
            }

            //recupear agenda de amistosos futuros
            IEnumerable<Jogo> amistososAgendados = _context.Jogos.Include(j => j.Agenda).Where(j => j.EhDesafio == false
                                        && j.CancelamentoId == 0 && j.TenistaVencedorId == 0
                                        && (j.Agenda.Data.Date > DateTime.Now.Date || (j.Agenda.Data.Date == DateTime.Now.Date && j.Agenda.HoraInicial.TimeOfDay >= DateTime.Now.TimeOfDay))).ToList();

            foreach (Jogo amistoso in amistososAgendados)
            {
                AmistosoVM amistosoVM = new AmistosoVM();

                amistosoVM.Jogo = amistoso;
                amistosoVM.TenistaA = _context.Tenistas.FirstOrDefault(t => t.Id == amistoso.TenistaAId);
                amistosoVM.TenistaB = _context.Tenistas.FirstOrDefault(t => t.Id == amistoso.TenistaBId);

                amistososVM.Add(amistosoVM);
            }

            // randomiza sequencia dos patrocinadores
            List<String> sponsorLogoSourceFiles = new List<string>();
            Random random = new Random();
            int randomNumber = random.Next(1, 8);
            int index = randomNumber;
            while (index <=8)
            {
                sponsorLogoSourceFiles.Add($"~/img/LogoSponsor{index}.png");
                index++;
            }
            index = 1;
            while (index < randomNumber)
            {
                sponsorLogoSourceFiles.Add($"~/img/LogoSponsor{index}.png");
                index++;
            }

            // recupera lista dos últimos 10 resultados de desafios 
            List<JogoVM> jogosVM = ListarUltimosResultadosJogos(true, 10, null);

            HomeVM homeVM = new HomeVM
            {
                DesafiosVM = desafiosVM,
                AmistososVM = amistososVM,
                SponsorsLogo = sponsorLogoSourceFiles,
                JogosVM = jogosVM
            };

            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult Regulamento()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        // TODO: estudar como montar um service para método ser usado por controller Jogo e Home (hoje está duplicado)
        // monta lista com ultimos x jogos de um tenista ou de qualquer tenista (desafio ou amistoso)
        // pode retornar todos os resultados ou os ultimos x jogos
        // pode retornar jogos de um tenista específico ou de qualquer
        private List<JogoVM> ListarUltimosResultadosJogos(bool ehDesafio, int? numeroJogos, int? idTenista)
        {
            List<JogoVM> jogosVM = new List<JogoVM>();
            List<Tenista> tenistas = _context.Tenistas.ToList();

            //recupera todos os jogos desafio ou amistosos, de acordo com parametro ehDesafio e que tenha um vencedor e não tenha sido cancelado
            List<Jogo> jogos = _context.Jogos.Include(j => j.Agenda).Where(j => j.EhDesafio == ehDesafio && j.TenistaVencedorId != 0 && j.CancelamentoId == 0).OrderByDescending(j => j.Agenda.Data).ToList();

            // se foi especificado um tenista filtra jogos apenas dele
            if (idTenista != null)
                jogos = jogos.Where(j => j.TenistaAId == idTenista || j.TenistaBId == idTenista).ToList();

            // se foi especificado um número de jogos filtra para mostrar apenas estes x ultimos
            if (numeroJogos != null)
                jogos = jogos.Take((int)numeroJogos).ToList();

            List<Placar> placars = _context.Placares.ToList();

            foreach (Jogo jogo in jogos)
            {
                JogoVM jogoVM = new JogoVM();

                jogoVM.Jogo = jogo;
                jogoVM.TenistaA = tenistas.FirstOrDefault(t => t.Id == jogo.TenistaAId);
                jogoVM.TenistaB = tenistas.FirstOrDefault(t => t.Id == jogo.TenistaBId);

                if (jogo.PlacarId == 0)
                {
                    jogoVM.Placar = new Placar { Set1GamesTenistaA = 0, Set1GamesTenistaB = 0, Set2GamesTenistaA = 0, Set2GamesTenistaB = 0 };
                }
                else
                {
                    jogoVM.Placar = placars.Find(p => p.Id == jogo.PlacarId);
                }
                jogosVM.Add(jogoVM);
            }
            return jogosVM;
        }

    }
}
