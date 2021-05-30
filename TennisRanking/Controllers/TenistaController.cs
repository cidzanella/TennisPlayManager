using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TennisRanking.Data;
using TennisRanking.Models;
using TennisRanking.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace TennisRanking.Controllers
{
    [Authorize]
    public class TenistaController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        // injeção de dependência a partir do DBContext criado em Startup.ConfigureServices
        public TenistaController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _environment = hostEnvironment;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult GerenciarTenistas()
        {
            if (User.Identity.Name.Contains("@gtmtennis.com.br") == false)
                return BadRequest(); 

            IEnumerable<Tenista> tenistas = _context.Tenistas.ToList().OrderBy(t=>t.Nome);
            return View(tenistas);
        }

        public IActionResult Bloquear(int id)
        {

            if (User.Identity.Name.Contains("@gtmtennis.com.br") == false)
                return BadRequest();

            Tenista tenista = _context.Tenistas.FirstOrDefault(t => t.Id == id);
            tenista.MotivoBloqueioId = 1;
            _context.SaveChanges();

            IEnumerable<Tenista> tenistas = _context.Tenistas.ToList().OrderBy(t => t.Nome);

            return View("Bloqueio", tenistas);
        }

        public IActionResult Desbloquear(int id)
        {
            if (User.Identity.Name.Contains("@gtmtennis.com.br") == false)
                return BadRequest();

            Tenista tenista = _context.Tenistas.FirstOrDefault(t => t.Id == id);
            tenista.MotivoBloqueioId = 0;
            _context.SaveChanges();

            IEnumerable<Tenista> tenistas = _context.Tenistas.ToList().OrderBy(t => t.Nome);

            return View("Bloqueio", tenistas);
        }

        public IActionResult MeuPerfil()
        {
            // inicializa com o Id do tenista logado
            Tenista tenista = _context.Tenistas.FirstOrDefault(t => t.Email == User.Identity.Name);
            
            // se não encontrou tenista então não foi criado ainda o perfil, chama o form para criação
            if (tenista == null)
                return RedirectToAction("Create");
            
            // como localizou o tenista no banco, apresenta o perfil
            return RedirectToAction("Perfil", new { id =  tenista.Id });
        }

        // apresenta o perfil do tenista
        public IActionResult Perfil(int? id)
        {
            // se não foi especificado um Id para apresentar o perfil de um dado tenista
            // inicializa com o Id do tenista logado
            if (!id.HasValue)
                id = 0;

            Tenista tenista = _context.Tenistas.FirstOrDefault(t => t.Id == id);

            if (tenista == null)
                return NotFound();

            TenistaPerfilVM perfilVM = new TenistaPerfilVM();
            perfilVM.Tenista = tenista;
            perfilVM.NomeCidade = _context.Cidades.Single(c => c.Id == tenista.CidadeId).Nome;
            if (tenista.JogaRanking)
                perfilVM.PosicaoRanking = _context.RankingTenistas.Single(t => t.TenistaId == tenista.Id).Posicao;
            
            return View(perfilVM);
        }

        public IActionResult Create()
        {
            TenistaFormVM tenistaFormVM = new TenistaFormVM
            {
                Tenista = new Tenista { Id = 0, Email = User.Identity.Name },
                Cidades = _context.Cidades.ToList().OrderBy(c => c.Nome)
            };

            return View("TenistaForm", tenistaFormVM);
        }

        public IActionResult Read()
        {
            return View();
        }

        //TODO: ADM listar todos os tenistas e ter uma função para incluir no ranking, posicionar no ranking, excluir do ranking
        //TODO: ADM usar email gtm@gtm.com.br
        //TODO: ADM criar role administrador para poder fazer funções gerenciais como: posicionar tenista no ranking, bloquear tenista, ...
        public IActionResult ReadAll()
        {
            Tenista _tenista = new Tenista();
            _tenista.Sexo = (byte)Sexo.Masculino;

            return View();
        }

        public IActionResult Update(int Id)
        {
            Tenista tenista = _context.Tenistas.Single(t => t.Id == Id);
            if (tenista == null)
                return NotFound();

            TenistaFormVM tenistaFormVM = new TenistaFormVM
            {
                Tenista = tenista,
                Cidades = _context.Cidades.ToList().OrderBy(c => c.Nome),
            };
            return View("TenistaForm", tenistaFormVM);
        }

        public IActionResult Delete() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(TenistaFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                TenistaFormVM tenistaFormVM = new TenistaFormVM
                {
                    Tenista = vm.Tenista,
                    Cidades = _context.Cidades.ToList()
                };
                return View("TenistaForm", tenistaFormVM);
            }

            //gera arquivo único com a imagem do perfil
            string uniqueFileName = UploadedFile(vm.ProfileImage);

            // se é um cadastro novo, usuário ainda não tem ID
            // a única propriedade que ainda não foi setada no model Tenista é o nome único do arquivo
            // as demais propriedades já foram setadas no submit do form
            // se id<>0 então é um update de um tenista e tem que testar se 
            if (vm.Tenista.Id == 0)
            {
                vm.Tenista.Foto = uniqueFileName; //como é um cadastro novo, salva um nome de arquivo de imagem, mesmo que seja nulo
                _context.Add(vm.Tenista);
            }
            else
            {
                Tenista tenistaDB = _context.Tenistas.Single(t => t.Id == vm.Tenista.Id);
                tenistaDB.Nome = vm.Tenista.Nome;
                tenistaDB.Sobrenome = vm.Tenista.Sobrenome;
                tenistaDB.Apelido = vm.Tenista.Apelido;
                tenistaDB.Nascimento = vm.Tenista.Nascimento;
                tenistaDB.AlturaCm = vm.Tenista.AlturaCm;
                tenistaDB.Sexo = vm.Tenista.Sexo;
                tenistaDB.Empunhadura = vm.Tenista.Empunhadura;
                tenistaDB.Backhand = vm.Tenista.Backhand;
                tenistaDB.Celular = vm.Tenista.Celular;
                tenistaDB.Email = vm.Tenista.Email;
                tenistaDB.CidadeId = vm.Tenista.CidadeId;
                tenistaDB.TipoTenista = vm.Tenista.TipoTenista;
                tenistaDB.JogaRanking = vm.Tenista.JogaRanking;
                tenistaDB.MotivoBloqueioId = vm.Tenista.MotivoBloqueioId;
                if (uniqueFileName!=null)               //se for null é porque não foi carregada nova imagem, não precisa atualizar
                    tenistaDB.Foto = uniqueFileName;    //como não é null então indica que foi carregada nova imagem e deve atualizar 
            };
            _context.SaveChanges();

            AjustarParticipacaoRanking(vm.Tenista); 

            // como localizou o tenista no banco, apresenta o perfil
            return RedirectToAction("MeuPerfil");
        }

        // copia a imagem do perfil para o diretório wwwroot.pictures com um nome único gerado neste método
        private string UploadedFile(IFormFile profileImage)
        {
            string uniqueFileName = null;
            
            // se usuário selecionou uma nova imagem para ser carregada então profileImage será diferente de null
            if (profileImage != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "pictures");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + profileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    profileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public IActionResult ExluirTenistaDoRanking(int id)
        {
            if (User.Identity.Name.Contains("@gtmtennis.com.br") == false)
                return BadRequest();

            Tenista tenista = _context.Tenistas.FirstOrDefault(t => t.Id == id);
            tenista.JogaRanking = false;
            _context.SaveChanges();

            AjustarParticipacaoRanking(tenista);

            IEnumerable<Tenista> tenistas = _context.Tenistas.ToList().OrderBy(t => t.Nome);

            return View("Bloqueio", tenistas);

        }

        //TODO: mover este código para a classe RankingTenista ??? Parece ser o certo.
        private void AjustarParticipacaoRanking(Tenista tenista)
        {
            //contagem do último colocado por sexo do ranking t.Sexo=tenista.Sexo
            // tenta localizar o tenista no ranking
            RankingTenistas tenistaNoRanking = _context.RankingTenistas.SingleOrDefault(t => t.TenistaId == tenista.Id && t.Sexo == tenista.Sexo);

            // se quer jogar ranking e não está no ranking ainda, adiciona o tenista na última posição
            if (tenista.JogaRanking)
            {
                if (tenistaNoRanking == null)
                {
                    //se não está no ranking ainda, adiciona na última posição
                    byte ultimoColocado = 1;
                    if (_context.RankingTenistas.Count()>0)
                        ultimoColocado = (byte)(_context.RankingTenistas.Where(t => t.Sexo == tenista.Sexo).Max(t => t.Posicao ) + 1);
                    
                    DateTime agora = DateTime.Today;

                    RankingTenistas rankingTenista = new RankingTenistas
                    {
                        TenistaId = tenista.Id,
                        Sexo = (byte)tenista.Sexo,
                        Posicao = ultimoColocado, 
                        PosicaoAnterior = 0, //como está entrando agora no ranking, posição anterior não existia, zero
                        PosicaoInicial = ultimoColocado, // - inicia na última posição do ranking
                        DataPosicaoAnterior = agora,
                        DataPosicaoAtual = agora,
                        DataPosicaoInicial = agora
                    };
                    _context.RankingTenistas.Add(rankingTenista);
                    _context.SaveChanges();
                }
            }
            else             // se não quer jogar ranking, remove tenista do ranking e atualiza posição dos demais
            {
                if (tenistaNoRanking != null)
                {
                    _context.RankingTenistas.Remove(tenistaNoRanking);
                    List<RankingTenistas> tenistas = _context.RankingTenistas.Where(t => t.Posicao > tenistaNoRanking.Posicao && t.Sexo == tenista.Sexo).ToList();
                    foreach (RankingTenistas t in tenistas)
                    {
                        t.PosicaoAnterior = t.Posicao;
                        t.DataPosicaoAnterior = t.DataPosicaoAtual;
                        t.Posicao = (byte)(t.Posicao - 1);
                        t.DataPosicaoAtual = DateTime.Today;
                    }
                    _context.SaveChanges();

                }
            }
        }
    }

}



