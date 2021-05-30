using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using TennisRanking.Data;
using TennisRanking.Models;
using TennisRanking.ViewModels;

namespace TennisRanking.Controllers
{
    // Ações relacionadas ao agendamento de jogos amistosos e desafios e lançamento de resultados
    public class JogoController : Controller
    {
        private readonly IEmailSender _emailSender;

        // attributes routes annotation
        // criação via attributes annotation da rota para acessar a ação 
        // aplicação de constraint range em mês para limitar 1 a 12 (+ google asp.net core attribute route constraint)
        [Route("jogo/jogospormes/{ano}/{mes:range(1,12)}")]
        public IActionResult JogosPorMes(int ano, int mes)
        {
            return Content(ano + "/" + mes);
        }

        private ApplicationDbContext _context;

        public JogoController(ApplicationDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            return View();
        }

        // Recebe como parâmetro o id do defensor (desafiado) e com base nas regras apresenta agendas
        public IActionResult Desafiar(int id)
        {
            List<Jogo> jogosBD = _context.Jogos.Include(j => j.Agenda).ToList();

            List<Tenista> tenistas = _context.Tenistas.ToList();
            Tenista tenistaA = tenistas.FirstOrDefault(t => t.Email == User.Identity.Name);
            Tenista tenistaB = tenistas.FirstOrDefault(t => t.Id == id);
            
            List<RankingTenistas> rankingTenistas = _context.RankingTenistas.ToList();
            int posicaoTenistaA = rankingTenistas.FirstOrDefault(t => t.TenistaId == tenistaA.Id).Posicao;
            int posicaoTenistaB = rankingTenistas.FirstOrDefault(t => t.TenistaId == tenistaB.Id).Posicao;
            int distanciaEntretenistas = posicaoTenistaA - posicaoTenistaB;
            
            RegrasGerais regras = _context.RegrasGerais.FirstOrDefault();
            int minimoDiasEntreDesafios = regras.MinimoDiasEntreDesafios;
            int limitePosicoesAcima = regras.PosicoesAcima;
            int minimoDiasParaRevanche = regras.MinimoDiasParaRevanche;
            
            DateTime hoje = DateTime.Today.Date;
            string headerMsgErro = "<h3>Oops! Algo não deu certo aqui!</h3>";
            string headerMsgOk = "<h3>Sucesso!</h3>";

            //Valida Agendamento do Desafio
            if (tenistaA == null || tenistaB == null)
            {
                TempData["Mensagem"] = $"{headerMsgErro}<h4>Ocorreu um erro! Retorne a página anterior e tente novamente.</h4>";
                return View("Mensagem");
            }

            if (posicaoTenistaA == 0 || posicaoTenistaB == 0)
            {
                TempData["Mensagem"] = $"{headerMsgErro}<h4>Ocorreu um erro! Tenista não localizado no ranking. Retorne a página anterior e tente novamente.</h4>";
                return View("Mensagem");
            }

            if (distanciaEntretenistas > limitePosicoesAcima || distanciaEntretenistas <= 0)
            {
                TempData["Mensagem"] = $"{headerMsgErro}<h4>O tenista {tenistaB.DisplayNome} encontra-se na posição #{posicaoTenistaB} do ranking e no momento fora do seu alcance. Você pode desafiar até {limitePosicoesAcima} posições acima da sua atual (#{posicaoTenistaA}).</h4>";
                return View("Mensagem");
            }

            // se tenista A está bloqueado não pode desafiar
            if (tenistaA.MotivoBloqueioId != 0)
            {
                TempData["Mensagem"] = $"{headerMsgErro}<h4>No momento você não está habilitado a desafiar posições no ranking. Entre em contato com o GTM para mais informações.</h4>";
                return View("Mensagem");
            }

            // se tenista B está bloqueado não pode ser desafiado
            if (tenistaB.MotivoBloqueioId != 0)
            {
                TempData["Mensagem"] = $"{headerMsgErro}<h4>No momento o tenista {tenistaB.DisplayNome} não está recebendo desafios.</h4>";
                return View("Mensagem");
            }

            // se existe um jogo de ranking do tenistaA como desafiante (A) ou como defensor (B) que esteja sem TenistaVencedorId ou cancelamento não pode agendar outro: isso resolve caso de tentar agendar um segundo  jogo com um já agendado e não jogado
            if (jogosBD.FirstOrDefault(j => (j.TenistaAId == tenistaA.Id || j.TenistaBId == tenistaA.Id) && (j.CancelamentoId == 0 && j.TenistaVencedorId == 0) && (j.EhDesafio)) != null)
            {
                TempData["Mensagem"] = $"{headerMsgErro}<h4>Você já possui um desafio agendado ou ainda não informou o resultado de um desafio anterior.</h4>";
                return View("Mensagem");
            }
            // se existe um jogo de ranking do tenistaB como desafiante (A) ou como defensor (B) que esteja sem TenistaVencedorId ou cancelamento não pode agendar outro: isso resolve caso de tentar agendar um segundo  jogo com um já agendado e não jogado
            if (jogosBD.FirstOrDefault(j => (j.TenistaAId == tenistaB.Id || j.TenistaBId == tenistaB.Id) && (j.CancelamentoId == 0 && j.TenistaVencedorId == 0) && (j.EhDesafio)) != null)
            {
                TempData["Mensagem"] = $"{headerMsgErro}<h4>O tenista {tenistaB.DisplayNome} já possui um desafio agendado ou ainda não informou o resultado de um desafio anterior.</h4>";
                return View("Mensagem");
            }

            // se desafiante chamou jogo a menos do que x dias então tem que aguadar
            if (jogosBD.FirstOrDefault(j => (j.TenistaAId == tenistaA.Id) && (j.CancelamentoId == 0) && (j.Agenda.Data.AddDays(minimoDiasEntreDesafios).Date >= hoje.Date) && (j.EhDesafio)) != null)
            {
                TempData["Mensagem"] = $"{headerMsgErro}<h4>Você chamou um desafio há poucos dias assim terá que aguardar mais um pouco para chamar este jogo. O ranking está funcionando com um intervalo mínimo de {minimoDiasEntreDesafios} dias para chamada de um novo desafio.</h4>";
                return View("Mensagem");
            }

            // testar se é revanche e neste caso se respeitou o intervalo
            if (jogosBD.FirstOrDefault(j => ( (j.TenistaAId == tenistaA.Id && j.TenistaBId == tenistaB.Id) || (j.TenistaAId == tenistaB.Id && j.TenistaBId == tenistaA.Id)) && (j.CancelamentoId == 0) && (j.Agenda.Data.AddDays(minimoDiasParaRevanche).Date >= hoje.Date) && (j.EhDesafio)) != null)
            {
                TempData["Mensagem"] = $"{headerMsgErro}<h4>Esse duelo está virando um clássico! Mas você terá que aguardar mais um pouco para chamar este jogo. O ranking está funcionando com um intervalo mínimo de {minimoDiasParaRevanche} dias para chamada de um desafio revanche.</h4>";
                return View("Mensagem");
            }

            DesafioVM desafioVM = new DesafioVM
            {
                TenistaA = tenistaA,
                TenistaB = tenistaB,
                AgendasPossiveis = CalcularDatasParaDesafio()
            };
            
            return View(desafioVM);
        }

        // Recebe como parâmetro o id do tenista convidado para o amistoso e a agenda escolhida, irá validar se é possível ou não esta agenda
        public IActionResult RegistrarAmistoso(AmistosoVM amistosoVM)
        {
            amistosoVM.TenistaA = _context.Tenistas.FirstOrDefault(t => t.Id == amistosoVM.TenistaA.Id);
            amistosoVM.TenistaB = _context.Tenistas.FirstOrDefault(t => t.Id == amistosoVM.Jogo.TenistaBId);

            // recuperar agenda selecionada da lista de agendas possíveis (aqui AgendaId recebida da View não é um id do BD mas da lista)
            amistosoVM.AgendasPossiveis = CalcularDatasParaAmistoso();
            amistosoVM.Agenda = amistosoVM.AgendasPossiveis.FirstOrDefault(a => a.Id == amistosoVM.Jogo.AgendaId);
            amistosoVM.Agenda.EhPreReserva = true;  
            amistosoVM.Agenda.Id = 0;

            // validar se o amistoso pode ser agendado, se ambos tenista cumprem os requisitos
            string msgRespostaValidacaoAgenda = ValidarAgendamentoAmistoso(amistosoVM);

            // se retornou alguma string de mensagem então agenda não foi validada, apresenta mensagem
            if (! String.IsNullOrEmpty(msgRespostaValidacaoAgenda))
            {
                TempData["Mensagem"] = msgRespostaValidacaoAgenda;
                return View("Mensagem");
            }

            // como agendamento foi aprovado, registrar no banco 

            amistosoVM.TenistaA = _context.Tenistas.FirstOrDefault(t => t.Id == amistosoVM.TenistaA.Id);
            amistosoVM.TenistaB = _context.Tenistas.FirstOrDefault(t => t.Id == amistosoVM.Jogo.TenistaBId);

            // gravar agenda no BD
            _context.Agendas.Add(amistosoVM.Agenda);
            _context.SaveChanges();

            // gravar desafio no BD
            amistosoVM.Jogo.AgendaId = amistosoVM.Agenda.Id;
            amistosoVM.Jogo.TenistaAId = amistosoVM.TenistaA.Id;
            amistosoVM.Jogo.RespostaConviteId = 0;
            amistosoVM.Jogo.DataConvite = DateTime.Now;
            amistosoVM.Jogo.EhDesafio = false;
            amistosoVM.Jogo.PlacarId = 0;
            amistosoVM.Jogo.TenistaDesistenteId = 0;
            amistosoVM.Jogo.TenistaVencedorId = 0;
            amistosoVM.Jogo.TokenConfirmacao = GerarTokenConfirmacaoAmistoso(amistosoVM); //gera o token que será usado para callback e confirmação da agenda
            _context.Jogos.Add(amistosoVM.Jogo);
            _context.SaveChanges();

            // enviar email de confirmação para desafiante e defensor
            EnviarEmailConviteAmistoso(amistosoVM);

            return View(amistosoVM);
        }

        private async void EnviarEmailConviteAmistoso(AmistosoVM amistosoVM)
        {
            string tokenConfirmacao = amistosoVM.Jogo.TokenConfirmacao;
            string callbackUrlConfirmar = GerarCallBackUrlAmistoso(amistosoVM, "ConfirmarAmistoso", tokenConfirmacao);
            string callbackUrlRecusar = GerarCallBackUrlAmistoso(amistosoVM, "RecusarAmistoso", tokenConfirmacao);

            string anfitriao = amistosoVM.TenistaA.DisplayNome;

            //monta email
            await _emailSender.SendEmailAsync(
                                amistosoVM.TenistaB.Email,
                                $"Amistoso! - {amistosoVM.Agenda.DisplayAgenda}",
                                $"<p>Olá <b>{amistosoVM.TenistaB.Nome.Trim()}</b>!</p>" +
                                $"<p>Você está sendo convidado para um jogo amistoso." +
                                $"<p>O tenista <b>{anfitriao}</b> pré-agendou a seguinte agenda:</p>" +
                                $"<h4><b>{amistosoVM.Agenda.DisplayAgenda}</b></h4>" +
                                $"<p>Responda este convite com umas das opções abaixo:</p>" +
                                $"<ul>" +
                                $"<li><a href = '{HtmlEncoder.Default.Encode(callbackUrlConfirmar)}'>Confirmar esta agenda</a > de jogo treino!</li>" +
                                $"<li><a href = '{HtmlEncoder.Default.Encode(callbackUrlRecusar)}'>Recusar este convite</a > e aguardar uma nova agenda.</li>" +
                                $"</ul>" +
                                $"<p>ATENÇÃO: RESPONDA RAPIDAMENTE PARA GARANTIR ESTA AGENDA!<BR/>Esta é uma <b>pré-reserva</b> e enquanto não for confirmada através do link acima existe a possibilidade de um outro jogo ocupar esta agenda caso seja confirmado primeiro. Então não perca tempo. Confirme já e garanta este jogo!</p>" +
                                $"<p>Ranking GTM</p>");
        }

        private string GerarTokenConfirmacaoAmistoso(AmistosoVM amistosoVM)
        {
            // monta uma string única para ser usada como token
            string tokenConfirmacao = $"{amistosoVM.GetHashCode()} {DateTime.UtcNow.GetHashCode()}";
            tokenConfirmacao = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(tokenConfirmacao));

            return tokenConfirmacao;
        }

        // valida se tem algum amistoso agendado no dia, no dia anterior ou posterior a data pretendida para agendamento do desafio
        private string ValidarAgendamentoDesafioContraAgendaAmistoso(DesafioVM desafioVM)
        {
            string headerMsgErro = "<h3>Oops! Algo não deu certo aqui!</h3>";

            DateTime agora = DateTime.Now;

            // busca agendas do tenista em que ele aparece como A ou B e que não tenham sido canceladas - jogos passados ou futuros
            List<Jogo> jogosTenistaA = _context.Jogos.Include(j => j.Agenda).Where(j => (j.TenistaAId == desafioVM.TenistaA.Id || j.TenistaBId == desafioVM.TenistaA.Id) && j.CancelamentoId == 0).ToList();
            List<Jogo> jogosTenistaB = _context.Jogos.Include(j => j.Agenda).Where(j => (j.TenistaAId == desafioVM.TenistaB.Id || j.TenistaBId == desafioVM.TenistaB.Id) && j.CancelamentoId == 0).ToList();

            List<Jogo> amistososTenistaA = jogosTenistaA.Where(j => j.EhDesafio == false).ToList();
            List<Jogo> amistososTenistaB = jogosTenistaB.Where(j => j.EhDesafio == false).ToList();

            if (jogosTenistaA.Count == 0 && jogosTenistaB.Count == 0)
                return null;

            if (amistososTenistaA.Count == 0 && amistososTenistaB.Count == 0)
                return null;

            // verifica se tenistaA tem agenda futura de AMISTOSO como A ou como B, se tiver e ela for a mesma data do amistoso pretendido
            // ou se for um dia anterior ou posterior então não autoriza 
            Jogo amistosoFuturoTenistaA = amistososTenistaA.FirstOrDefault(j => j.Agenda.Data.Date > agora.Date || (j.Agenda.Data.Date == agora.Date && j.Agenda.HoraInicial.TimeOfDay >= agora.TimeOfDay));
            if (amistosoFuturoTenistaA != null &&
                (amistosoFuturoTenistaA.Agenda.Data.Date == desafioVM.Agenda.Data.Date) ||
                (amistosoFuturoTenistaA.Agenda.Data.AddDays(-1).Date == desafioVM.Agenda.Data.Date) ||
                (amistosoFuturoTenistaA.Agenda.Data.AddDays(1).Date == desafioVM.Agenda.Data.Date))
                return $"{headerMsgErro}<h4>O tenista {desafioVM.TenistaA.DisplayNome} tem amistoso agendado para o dia, dia anterior ou dia posterior a agenda solicitada para este desafio e assim não será possível agendar para esta data salvo se o amistoso for cancelado.</h4>";

            // verifica se tenista B tem agenda futura de DESAFIO como A ou como B, se tiver e ela for a mesma data do amistoso pretendido
            // ou se for um dia anterior ou posterior então não autoriza 
            Jogo amistosoFuturoTenistaB = amistososTenistaB.FirstOrDefault(j => j.Agenda.Data.Date > agora.Date || (j.Agenda.Data.Date == agora.Date && j.Agenda.HoraInicial.TimeOfDay >= agora.TimeOfDay));
            if (amistosoFuturoTenistaB != null &&
                (amistosoFuturoTenistaB.Agenda.Data.Date == desafioVM.Agenda.Data.Date) ||
                (amistosoFuturoTenistaB.Agenda.Data.AddDays(-1).Date == desafioVM.Agenda.Data.Date) ||
                (amistosoFuturoTenistaB.Agenda.Data.AddDays(1).Date == desafioVM.Agenda.Data.Date))
                return $"{headerMsgErro}<h4>O tenista {desafioVM.TenistaB.DisplayNome} tem amistoso agendado para o dia, dia anterior ou dia posterior a agenda solicitada para este desafio e assim não será possível agendar para esta data salvo se o amiostoso for cancelado.</h4>";

            return null;
        }
        // valida as regras de agendamento de amistoso e retorna mensagem indicando restrição encontrada ou null caso agenda seja viável
        private string ValidarAgendamentoAmistoso(AmistosoVM amistosoVM)
        {
            string headerMsgErro = "<h3>Oops! Algo não deu certo aqui!</h3>";

            if (amistosoVM.TenistaA == null || amistosoVM.TenistaB == null)
                return $"{headerMsgErro}<h4>Ocorreu um erro! Retorne a página anterior e tente novamente.</h4>";

            // se tenista A está bloqueado não pode desafiar
            if (amistosoVM.TenistaA.MotivoBloqueioId != 0)
                return $"{headerMsgErro}<h4>No momento você não está habilitado a agendar amistosos. Entre em contato com o GTM para mais informações.</h4>";

            // se tenista B está bloqueado não pode ser desafiado
            if (amistosoVM.TenistaB.MotivoBloqueioId != 0)
                return $"{headerMsgErro}<h4>No momento o tenista {amistosoVM.TenistaB.DisplayNome} não está disponível para agendamento de amistoso.</h4>";

            DateTime agora = DateTime.Now;
            RegrasAgendaAmistoso regrasAgendaAmistoso = _context.RegrasAgendaAmistoso.First();

            // busca agendas do tenista em que ele aparece como A ou B e que não tenham sido canceladas - jogos passados ou futuros
            List<Jogo> jogosTenistaA = _context.Jogos.Include(j => j.Agenda).Where(j => (j.TenistaAId == amistosoVM.TenistaA.Id || j.TenistaBId == amistosoVM.TenistaA.Id) && j.CancelamentoId == 0 ).ToList();
            List<Jogo> jogosTenistaB = _context.Jogos.Include(j => j.Agenda).Where(j => (j.TenistaAId == amistosoVM.TenistaB.Id || j.TenistaBId == amistosoVM.TenistaB.Id) && j.CancelamentoId == 0 ).ToList();

            List<Jogo> amistososTenistaA = jogosTenistaA.Where(j => j.EhDesafio == false).ToList();
            List<Jogo> amistososTenistaB = jogosTenistaB.Where(j => j.EhDesafio == false).ToList();
            
            List<Jogo> desafiosTenistaA = jogosTenistaA.Where(j => j.EhDesafio == true).ToList();
            List<Jogo> desafiosTenistaB = jogosTenistaB.Where(j => j.EhDesafio == true).ToList();

            // se não encontrou jogo anterior dos tenistas então eles estão liberados para agendamento
            if (jogosTenistaA.Count == 0 && jogosTenistaB.Count == 0)
                return null;

            // verifica se tenista A tem agenda futura de amistoso como A ou como B, se tiver já recusa nova agenda
            // 
            Jogo amistosoFuturoTenistaA = amistososTenistaA.FirstOrDefault(j => j.Agenda.Data.Date > agora.Date || (j.Agenda.Data.Date == agora.Date && j.Agenda.HoraInicial.TimeOfDay >= agora.TimeOfDay));
            if (amistosoFuturoTenistaA != null)
                return $"{headerMsgErro}<h4>O tenista {amistosoVM.TenistaA.DisplayNome} tem amistoso agendado no momento e assim não será possível agendar um segundo amistoso até que este primeiro seja jogado ou cancelado.</h4>";

            // verifica se tenista B tem agenda futura de amistoso como A ou como B, se tiver já recusa nova agenda
            Jogo amistosoFuturoTenistaB = amistososTenistaB.FirstOrDefault(j => j.Agenda.Data.Date > agora.Date || (j.Agenda.Data.Date == agora.Date && j.Agenda.HoraInicial.TimeOfDay >= agora.TimeOfDay));
            if (amistosoFuturoTenistaB != null)
                return $"{headerMsgErro}<h4>O tenista {amistosoVM.TenistaB.DisplayNome} tem amistoso agendado no momento e assim não será possível agendar um segundo amistoso até que este primeiro seja jogado ou cancelado.</h4>";

            // se agenda é para hoje e já passou do horário de liberação de agendamento (13H) então pode agendar mesmo que tenha desafio agendado
            if (amistosoVM.Agenda.Data.Date == agora.Date && agora.TimeOfDay >= regrasAgendaAmistoso.HorarioLiberarAgendamento.TimeOfDay)
                return null;

            // verifica se tenistaA tem agenda futura de DESAFIO como A ou como B, se tiver e ela for a mesma data do amistoso pretendido
            // ou se for um dia anterior ou posterior então não autoriza 
            Jogo desafioFuturoTenistaA = desafiosTenistaA.FirstOrDefault(j => j.Agenda.Data.Date > agora.Date || (j.Agenda.Data.Date == agora.Date && j.Agenda.HoraInicial.TimeOfDay >= agora.TimeOfDay));
            if ( desafioFuturoTenistaA != null)
                if ((desafioFuturoTenistaA.Agenda.Data.Date == amistosoVM.Agenda.Data.Date) || 
                    (desafioFuturoTenistaA.Agenda.Data.AddDays(-1).Date == amistosoVM.Agenda.Data.Date) ||
                    (desafioFuturoTenistaA.Agenda.Data.AddDays(1).Date == amistosoVM.Agenda.Data.Date))
                    return $"{headerMsgErro}<h4>O tenista {amistosoVM.TenistaA.DisplayNome} tem desafio agendado para o dia, dia anterior ou dia posterior a agenda solicitada para o amistoso e assim não será possível agendar para esta data salvo se o desafio for cancelado.</h4>";

            // verifica se tenista B tem agenda futura de DESAFIO como A ou como B, se tiver e ela for a mesma data do amistoso pretendido
            // ou se for um dia anterior ou posterior então não autoriza 
            Jogo desafioFuturoTenistaB = desafiosTenistaB.FirstOrDefault(j => j.Agenda.Data.Date > agora.Date || (j.Agenda.Data.Date == agora.Date && j.Agenda.HoraInicial.TimeOfDay >= agora.TimeOfDay));
            if ( desafioFuturoTenistaB != null)
                if ((desafioFuturoTenistaB.Agenda.Data.Date == amistosoVM.Agenda.Data.Date) || 
                    (desafioFuturoTenistaB.Agenda.Data.AddDays(-1).Date == amistosoVM.Agenda.Data.Date) ||
                    (desafioFuturoTenistaB.Agenda.Data.AddDays(1).Date == amistosoVM.Agenda.Data.Date) )
                    return $"{headerMsgErro}<h4>O tenista {amistosoVM.TenistaB.DisplayNome} tem desafio agendado para o dia, dia anterior ou dia posterior a agenda solicitada para o amistoso e assim não será possível agendar para esta data salvo se o desafio for cancelado.</h4>";

            
            // se for para data futura então tem que validar demais regras
            // verifica se passou o tempo mínimo desde o último jogo 
            int intervalo = regrasAgendaAmistoso.MinimoDiasEntreAmistosos;
            
            // se encontrou jogo anterior do tenista então validar intervalo: testa se a agenda escolhida está na distância exigida
            if (jogosTenistaA.Count != 0)
            {
                DateTime dataUltimoJogoTenistaA = jogosTenistaA.Where(j => j.Agenda.Data.Date < agora.Date || (j.Agenda.Data.Date == agora.Date && j.Agenda.HoraInicial.TimeOfDay < agora.TimeOfDay)).OrderByDescending(j => j.Agenda.Data).First().Agenda.Data;
                DateTime dataParaProximoJogoTenistaA = dataUltimoJogoTenistaA.AddDays(intervalo);
                if (dataParaProximoJogoTenistaA.Date > amistosoVM.Agenda.Data.Date)
                    return $"{headerMsgErro}<h4>Como você jogou a pouco tempo a data para seu próximo amistoso deverá ser a partir de {dataParaProximoJogoTenistaA.ToShortDateString()}.<h4>";
            }

            // se encontrou jogo anterior do tenista então validar intervalo
            if (jogosTenistaB.Count != 0)
            {
                DateTime dataUltimoJogoTenistaB = jogosTenistaB.Where(j => j.Agenda.Data.Date < agora.Date || (j.Agenda.Data.Date == agora.Date && j.Agenda.HoraInicial.TimeOfDay < agora.TimeOfDay)).OrderByDescending(j => j.Agenda.Data).First().Agenda.Data;
                DateTime dataParaProximoJogoTenistaB = dataUltimoJogoTenistaB.AddDays(intervalo);
                if (dataUltimoJogoTenistaB.AddDays(intervalo).Date > amistosoVM.Agenda.Data.Date)
                    return $"{headerMsgErro}<h4>Como o tenista {amistosoVM.TenistaB.DisplayNome} jogou a pouco tempo a data para um próximo amistoso com ele deverá ser a partir de {dataParaProximoJogoTenistaB.ToShortDateString()}.<h4>";
            }
            
            return null;
        }

        //registra o desafio no banco de dados após usuário selecionar uma agenda para o jogo, envia email de desafio com três possiveis respostas: aceitar, recusar, entregar WO
        public IActionResult RegistrarDesafio(DesafioVM desafioVM)
        {
            desafioVM.TenistaA = _context.Tenistas.FirstOrDefault(t => t.Id == desafioVM.TenistaA.Id);
            desafioVM.TenistaB = _context.Tenistas.FirstOrDefault(t => t.Id == desafioVM.TenistaB.Id);

            // recuperar agenda selecionada da lista de agendas possíveis (aqui AgendaId recebida da View não é um id do BD mas da lista)
            desafioVM.AgendasPossiveis = CalcularDatasParaDesafio();
            desafioVM.Agenda = desafioVM.AgendasPossiveis.FirstOrDefault(a => a.Id == desafioVM.Jogo.AgendaId);
            desafioVM.Agenda.EhPreReserva = true; 
            desafioVM.Agenda.Id = 0;

            // validar se não tem amistoso no dia, no dia anterior ou no dia posterior a agenda pretendida para o desafio
            string msgRespostaValidacaoAgenda = ValidarAgendamentoDesafioContraAgendaAmistoso(desafioVM);

            // se retornou alguma string de mensagem então agenda não foi validada, apresenta mensagem
            if (!String.IsNullOrEmpty(msgRespostaValidacaoAgenda))
            {
                TempData["Mensagem"] = msgRespostaValidacaoAgenda;
                return View("Mensagem");
            }

            // como agendamento foi aprovado, registrar no banco 
            _context.Agendas.Add(desafioVM.Agenda); 
            _context.SaveChanges();

            // gravar desafio no BD
            desafioVM.Jogo.AgendaId = desafioVM.Agenda.Id;
            desafioVM.Jogo.TenistaAId = desafioVM.TenistaA.Id;
            desafioVM.Jogo.TenistaBId = desafioVM.TenistaB.Id;
            desafioVM.Jogo.RespostaConviteId = 0;
            desafioVM.Jogo.DataConvite = DateTime.Now;
            desafioVM.Jogo.EhDesafio = true;
            desafioVM.Jogo.PlacarId = 0;
            desafioVM.Jogo.TenistaDesistenteId = 0;
            desafioVM.Jogo.TenistaVencedorId = 0;
            desafioVM.Jogo.TokenConfirmacao = GerarTokenConfirmacaoDesafio(desafioVM); //gera o token que será usado para callback e confirmação da agenda
            _context.Jogos.Add(desafioVM.Jogo);
            _context.SaveChanges();

            // enviar email de confirmação para desafiante e defensor
            EnviarEmailChamadaDesafio(desafioVM);

            return View(desafioVM);
        }

        // entrou resposta do desafiado através de clique no link do email aceitando o desafio
        public IActionResult ConfirmarDesafio(string code)
        {
            Jogo jogo = _context.Jogos.Include(j => j.Agenda).FirstOrDefault(j => j.TokenConfirmacao == code);

            //se não localizar o jogo pelo code quer dizer que o code já foi consumido por outra resposta
            if (jogo == null)
            {
                TempData["Mensagem"] = MontarMensagemConviteNaoLocalizado();
                return View("Mensagem");
            }

            // confirmar a reserva
            jogo.RespostaConviteId = (int)RespostaConvite.Aceito; 
            jogo.Agenda.EhPreReserva = false; 
            jogo.DataRespostaConvite = DateTime.Now;
            jogo.TokenConfirmacao = ""; //exclui token por ser chave de passagem única
            _context.SaveChanges();

            //Cancelar demais jogos pré-agendados para esta mesma agenda
            CancelarPreAgendasConflitantesComJogoConfirmado(jogo);

            Tenista tenistaA = _context.Tenistas.FirstOrDefault(t => t.Id == jogo.TenistaAId);
            Tenista tenistaB = _context.Tenistas.FirstOrDefault(t => t.Id == jogo.TenistaBId);

            string msgConfirmacao = $"<h2>Desafio Confirmado!</h2><br/><h4>{tenistaA.DisplayNome}   vs   {tenistaB.DisplayNome}</h4><p>{jogo.Agenda.DisplayAgenda}</p>" +
                $"<p>O desafio está confirmado, agora é na quadra ... Bom jogo!</p>";
            TempData["Mensagem"] = msgConfirmacao;

            string headerMsg = $"Desafio Confirmado! - {jogo.Agenda.DisplayAgenda}";
            //enviar email confirmando a reserva, mudar de pré-reserva na agenda
            EnviarEmailTenistasJogo(jogo, headerMsg, msgConfirmacao);

            return View("Mensagem");
        }

        // entrou resposta do convidado através de clique no link do email aceitando o convite jogo
        public IActionResult ConfirmarAmistoso(string code)
        {
            Jogo jogo = _context.Jogos.Include(j => j.Agenda).FirstOrDefault(j => j.TokenConfirmacao == code);

            //se não localizar o jogo pelo code quer dizer que o code já foi consumido por outra resposta
            if (jogo == null)
            {
                TempData["Mensagem"] = MontarMensagemConviteNaoLocalizado();
                return View("Mensagem");
            }

            // confirmar a reserva
            jogo.RespostaConviteId = (int)RespostaConvite.Aceito;
            jogo.Agenda.EhPreReserva = false;
            jogo.DataRespostaConvite = DateTime.Now;
            jogo.TokenConfirmacao = ""; //exclui token por ser chave de passagem única
            _context.SaveChanges();

            //Cancelar demais jogos pré-agendados para esta mesma agenda
            CancelarPreAgendasConflitantesComJogoConfirmado(jogo);

            Tenista tenistaA = _context.Tenistas.FirstOrDefault(t => t.Id == jogo.TenistaAId);
            Tenista tenistaB = _context.Tenistas.FirstOrDefault(t => t.Id == jogo.TenistaBId);

            string msgConfirmacao = $"<h2>Amistoso Confirmado!</h2><br/><h4>{tenistaA.DisplayNome}   vs   {tenistaB.DisplayNome}</h4><p>{jogo.Agenda.DisplayAgenda}</p>" +
                $"<p>O jogo amistoso está confirmado... Bom treino!</p>";
            TempData["Mensagem"] = msgConfirmacao;

            string headerMsg = $"Amistoso Confirmado! - {jogo.Agenda.DisplayAgenda}";
            //enviar email confirmando a reserva, mudar de pré-reserva na agenda
            EnviarEmailTenistasJogo(jogo, headerMsg, msgConfirmacao);

            return View("Mensagem");
        }

        // entrou resposta do desafiado através de clique no link do email recusando o desafio
        public IActionResult RecusarDesafio(string code)
        {
            Jogo jogo = _context.Jogos.FirstOrDefault(j => j.TokenConfirmacao == code);
            //se não localizar o jogo pelo code quer dizer que o code já foi consumido por outra resposta
            if (jogo == null)
            {
                TempData["Mensagem"] = MontarMensagemConviteNaoLocalizado();
                return View("Mensagem");
            }

            //verifica se já teve um convite anterior recusado
            //se teve então não pode ser recusado novamente, deve entregar posição por WO
            Jogo jogoAnteriorRecusado = _context.Jogos.Include(j => j.Agenda).FirstOrDefault(j => j.TenistaAId == jogo.TenistaAId && j.TenistaBId == jogo.TenistaBId && j.RespostaConviteId == (int)RespostaConvite.Recusado && j.EhDesafio == true);
            if (jogoAnteriorRecusado != null)
            {
                // altera resposta do convite alterior para evitar que um eventual novo convite gere novamente um WO na primeira recusa
                jogoAnteriorRecusado.RespostaConviteId = (int)RespostaConvite.EntregouPosicaoWO;
                _context.SaveChanges();

                RedirectToAction("EntregarDesafio", new { code = code });
            }

            //motivo 4 - Solicitação do desafiado 
            int idCancelamento = RegistrarCancelamentoBD(jogo.TenistaBId, 4, false, false);

            //cancela agenda
            Agenda agenda = _context.Agendas.FirstOrDefault(a => a.Id == jogo.AgendaId);
            agenda.FoiCancelada = true; //indica que a agenda foi cancelada, não será usada a quadra, pode liberar para outro desafio

            // atualiza jogo com resposta e cancelamento
            jogo.RespostaConviteId = (int)RespostaConvite.Recusado; // 2: recusado
            jogo.DataRespostaConvite = DateTime.Now;
            jogo.CancelamentoId = idCancelamento;
            jogo.TokenConfirmacao = ""; //exclui token por ser chave de passagem única
            _context.SaveChanges();

            Tenista tenistaA = _context.Tenistas.FirstOrDefault(t => t.Id == jogo.TenistaAId);
            Tenista tenistaB = _context.Tenistas.FirstOrDefault(t => t.Id == jogo.TenistaBId);

            string msgRecusa= $"<h2>Desafio Recusado!</h2><br/><h4>{tenistaA.DisplayNome}   vs   {tenistaB.DisplayNome}</h4><p>{agenda.DisplayAgenda}</p>" +
                $"<p>O tenista defensor <b>{tenistaB.DisplayNome}</b> respondeu recusando o convite para este desafio.<br/> " +
                $"O desafio poderá ser recusado uma única vez. Em uma eventual segunda recusa o desafiante será declarado vencedor por W.O. " +
                $"e o defensor cairá uma posição no ranking.</p>";
            TempData["Mensagem"] = msgRecusa;

            string headerMsg = $"Desafio Recusado! - {agenda.DisplayAgenda}";
            EnviarEmailTenistasJogo(jogo, headerMsg, msgRecusa);

            return View("Mensagem");
        }

        // entrou resposta do convidado através de clique no link do email recusando o amistoso
        public IActionResult RecusarAmistoso(string code)
        {
            Jogo jogo = _context.Jogos.FirstOrDefault(j => j.TokenConfirmacao == code);

            //se não localizar o jogo pelo code quer dizer que o code já foi consumido por outra resposta
            if (jogo == null)
            {
                TempData["Mensagem"] = MontarMensagemConviteNaoLocalizado();
                return View("Mensagem");
            }

            //motivo 4 - Solicitação do desafiado 
            int idCancelamento = RegistrarCancelamentoBD(jogo.TenistaBId, 4, false, false);

            //cancela agenda
            Agenda agenda = _context.Agendas.FirstOrDefault(a => a.Id == jogo.AgendaId);
            agenda.FoiCancelada = true; //indica que a agenda foi cancelada, não será usada a quadra, pode liberar para outro desafio

            // atualiza jogo com resposta e cancelamento
            jogo.RespostaConviteId = (int)RespostaConvite.Recusado; // 2: recusado
            jogo.DataRespostaConvite = DateTime.Now;
            jogo.CancelamentoId = idCancelamento;
            jogo.TokenConfirmacao = ""; //exclui token por ser chave de passagem única

            _context.SaveChanges();


            Tenista tenistaA = _context.Tenistas.FirstOrDefault(t => t.Id == jogo.TenistaAId);
            Tenista tenistaB = _context.Tenistas.FirstOrDefault(t => t.Id == jogo.TenistaBId);

            string msgRecusa = $"<h2>Amistoso Recusado!</h2><br/><h4>{tenistaA.DisplayNome}   vs   {tenistaB.DisplayNome}</h4><p>{agenda.DisplayAgenda}</p>" +
                $"<p>O tenista convidado <b>{tenistaB.DisplayNome}</b> respondeu recusando o convite para este amistoso.<br/> ";
            TempData["Mensagem"] = msgRecusa;

            string headerMsg = $"Amistoso Recusado! - {agenda.DisplayAgenda}";
            EnviarEmailTenistasJogo(jogo, headerMsg, msgRecusa);

            return View("Mensagem");
        }

        // cria um registro de cancelamento no banco de dados para ser associado a um jogo
        private int RegistrarCancelamentoBD(int tenistaCancelandoId, int motivoCancelamentoId, bool gerouMulta, bool gerouWO)
        {
            // gera cancelamento
            Cancelamento cancelamento = new Cancelamento
            {
                CanceladoPorTenistaId = tenistaCancelandoId,
                DataCancelamento = DateTime.Now,
                GerouMulta = gerouMulta ,
                GerouWO = gerouWO,
                MotivoCancelamentoId = motivoCancelamentoId
            };
            _context.Cancelamentos.Add(cancelamento);
            _context.SaveChanges();

            return cancelamento.Id;
        }

        // entrou resposta do desafiado através de clique no link do email entregando a posição por WO
        public IActionResult EntregarDesafio(string code)
        {
            Jogo jogo = _context.Jogos.FirstOrDefault(j => j.TokenConfirmacao == code);
            //se não localizar o jogo pelo code quer dizer que o code já foi consumido por outra resposta
            if (jogo == null)
            {
                TempData["Mensagem"] = MontarMensagemConviteNaoLocalizado(); 
                return View("Mensagem");
            }
            //cancela agenda
            Agenda agenda = _context.Agendas.FirstOrDefault(a => a.Id == jogo.AgendaId);
            agenda.FoiCancelada = true; //indica que a agenda foi cancelada, não será usada a quadra, pode liberar para outro desafio
            agenda.Data = DateTime.Now; //muda a data para o dia que deu WO no jogo

            // atualiza jogo com resposta 
            jogo.RespostaConviteId = (int)RespostaConvite.EntregouPosicaoWO;  
            jogo.DataRespostaConvite = DateTime.Now;
            jogo.TenistaVencedorId = jogo.TenistaAId;
            jogo.TenistaDesistenteId = jogo.TenistaBId; 
            jogo.TokenConfirmacao = ""; //exclui token por ser chave de passagem única

            _context.SaveChanges();

            Tenista tenistaA = _context.Tenistas.FirstOrDefault(t => t.Id == jogo.TenistaAId);
            Tenista tenistaB = _context.Tenistas.FirstOrDefault(t => t.Id == jogo.TenistaBId);
            InverterPosicaoTenistasRanking(jogo.TenistaAId, jogo.TenistaBId);

            string msgWORegistrado = $"<h2>W.O. Registrado!</h2><br/><h4>{tenistaA.DisplayNome}   vs   {tenistaB.DisplayNome}</h4><p>{agenda.DisplayAgenda}</p>" +
                $"<p>O tenista defensor <b>{tenistaB.DisplayNome}</b> respondeu ao convite informando que não irá jogar este desafio e optou por ceder a sua posição " +
                $"no ranking para o desafiante <b>{tenistaA.DisplayNome}</b>, sendo desta forma o desafiante declarado vencedor por W.O.!<br/>" +
                $"O tenista defensor cai uma posição no raking, estando agora imediatamente abaixo da anterior.</p>";
            TempData["Mensagem"] = msgWORegistrado;

            string headerMsg = $"W.O. Registrado! - {agenda.DisplayAgenda}";
            EnviarEmailTenistasJogo(jogo, headerMsg, msgWORegistrado);

            return View("Mensagem");
        }

        private string MontarMensagemConviteNaoLocalizado()
        {
            return $"<h3>O-oh!</h3><h4>Não foi possível acessar este convite de jogo! Ele pode ter sido já respondido ou esta agenda não está mais disponível.<br/>Acesse o portal GTM para maiores informações.</h4>";
        }

        //
        public IActionResult Reagendar(int id)
        {
            // verifica se é amistoso ou desafio, reagenda de acordo 
            return RedirectToAction("ReagendarDesafio", new { id = id } );
        }

        // Cancela jogo amistoso ou desafio
        public IActionResult Cancelar(int id)
        {
            //verifica se é desafio ou se é amistoso e redireciona para a Action para cancelar segundo as regras de cada
            if (_context.Jogos.FirstOrDefault(j => j.Id == id).EhDesafio)
                return RedirectToAction("CancelarDesafio", new { id = id });
               
            return RedirectToAction("CancelarAmistoso", new { id = id });
        }

        // recebe id jogo e apresenta view com form para informar resultado
        public IActionResult InformarResultado(int id)
        {
            ResultadoVM resultadoVM = new ResultadoVM();
            resultadoVM.Jogo = _context.Jogos.Include(j => j.Agenda).FirstOrDefault(j => j.Id == id);
            resultadoVM.Placar = new Placar();
            resultadoVM.TenistaA = _context.Tenistas.FirstOrDefault(t => t.Id == resultadoVM.Jogo.TenistaAId);
            resultadoVM.TenistaB = _context.Tenistas.FirstOrDefault(t => t.Id == resultadoVM.Jogo.TenistaBId);
            resultadoVM.Tenistas = new List<Tenista> { resultadoVM.TenistaA, resultadoVM.TenistaB };
            return View(resultadoVM);
        }

        public IActionResult RegistrarResultado(ResultadoVM resultadoVM)
        {

            int tenistaVencedorId = 0;
            
            // testa se houve desistente ou ausência (wo), neste caso placar pode ter empate mas o outro tenista é o vencedor
            if (resultadoVM.Jogo.TenistaDesistenteId != 0)
            {
                tenistaVencedorId = (resultadoVM.Jogo.TenistaDesistenteId == resultadoVM.Jogo.TenistaAId) ? resultadoVM.Jogo.TenistaBId : resultadoVM.Jogo.TenistaAId;
            }
            else if (resultadoVM.Jogo.TenistaAusenteWOId != 0)
            {
                tenistaVencedorId = (resultadoVM.Jogo.TenistaAusenteWOId == resultadoVM.Jogo.TenistaAId) ? resultadoVM.Jogo.TenistaBId : resultadoVM.Jogo.TenistaAId;
            }
            else
            {
                // se não teve desistente então validar placar para que não tenha empate
                if (ValidarPlacarSemEmpates(resultadoVM.Placar) == false)
                    //informar que placar tem erro e pedir para corrigir, apresentando novamente a view form
                    return View("ErroPlacarEmpate"); 

                tenistaVencedorId = CalcularTenistaVencedor(resultadoVM);
            }

            // só registrar placar se não foi WO, se teve um tenista ausente então não registra
            if (resultadoVM.Jogo.TenistaAusenteWOId == 0)
            {
                // registrar no banco de dados
                _context.Placares.Add(resultadoVM.Placar);
                _context.SaveChanges();
            } else
            {
                resultadoVM.Placar.Id = 0;
            }

            Jogo jogoBD = _context.Jogos.FirstOrDefault(j => j.Id == resultadoVM.Jogo.Id);
            jogoBD.PlacarId = resultadoVM.Placar.Id;
            jogoBD.TenistaDesistenteId = resultadoVM.Jogo.TenistaDesistenteId;
            jogoBD.TenistaAusenteWOId = resultadoVM.Jogo.TenistaAusenteWOId; ;
            jogoBD.TenistaVencedorId = tenistaVencedorId; 
            _context.SaveChanges();

            // se foi vitoria do desafiante então inverte posição dos tenistas
            if (tenistaVencedorId == resultadoVM.Jogo.TenistaAId)
                InverterPosicaoTenistasRanking(resultadoVM.Jogo.TenistaAId, resultadoVM.Jogo.TenistaBId);

            TempData["Mensagem"] = $"<h3>Resultado Registrado!</h3><h4>O resultado informado foi registrado com sucesso e pode ser consultado no histórico de jogos em MEU PERFIL.</h4>";
            //enviar email confirmando a reserva, mudar de pré-reserva na agenda
            return View("Mensagem");
        }

        private bool ValidarPlacarSemEmpates(Placar placar)
        {
            // set 1
            // games
            if (placar.Set1GamesTenistaA == placar.Set1GamesTenistaB)
                return false;
            // tiebreak: se não for zerado então não pode ser igual
            if ( (placar.Set1TieBreakTenistaA != 0 || placar.Set1TieBreakTenistaB != 0) && (placar.Set1TieBreakTenistaA == placar.Set1TieBreakTenistaB) )
                return false;

            // set 2
            // games
            if (placar.Set2GamesTenistaA == placar.Set2GamesTenistaB)
                return false;
            // tiebreak: se não for zerado então não pode ser igual
            if ((placar.Set2TieBreakTenistaA != 0 || placar.Set2TieBreakTenistaB != 0) && (placar.Set2TieBreakTenistaA == placar.Set2TieBreakTenistaB))
                return false;

            // set 3
            // não valida games, só o tie break do terceiro set é informado
            // tiebreak: se não for zerado então não pode ser igual
            if ((placar.Set3TieBreakTenistaA != 0 || placar.Set3TieBreakTenistaB != 0) && (placar.Set3TieBreakTenistaA == placar.Set3TieBreakTenistaB))
                return false;

            return true;
        }

        private int CalcularTenistaVencedor(ResultadoVM resultadoVM)
        {
            int setsVencidosTenistaA = 0;

            bool desafianteVenceuSet1 = CalcularSeDesafianteVenceuSet(resultadoVM.Placar.Set1GamesTenistaA, resultadoVM.Placar.Set1GamesTenistaB, resultadoVM.Placar.Set1TieBreakTenistaA, resultadoVM.Placar.Set1TieBreakTenistaB);
            bool desafianteVenceuSet2 = CalcularSeDesafianteVenceuSet(resultadoVM.Placar.Set2GamesTenistaA, resultadoVM.Placar.Set2GamesTenistaB, resultadoVM.Placar.Set2TieBreakTenistaA, resultadoVM.Placar.Set2TieBreakTenistaB);
            bool desafianteVenceuSet3 = CalcularSeDesafianteVenceuSet(resultadoVM.Placar.Set3GamesTenistaA, resultadoVM.Placar.Set3GamesTenistaB, resultadoVM.Placar.Set3TieBreakTenistaA, resultadoVM.Placar.Set3TieBreakTenistaB);

            if (desafianteVenceuSet1)
                setsVencidosTenistaA++;

            if (desafianteVenceuSet2)
                setsVencidosTenistaA++;

            if (desafianteVenceuSet3)
                setsVencidosTenistaA++;

            if (setsVencidosTenistaA == 2)
                return resultadoVM.Jogo.TenistaAId;

            return resultadoVM.Jogo.TenistaBId;
        }

        private bool CalcularSeDesafianteVenceuSet(int gamesA, int gamesB, int tieBreakA, int tieBreakB)
        {
            //
            // valida vencedor set
            //
            // se jogou triebreak então vencedor do tiebrek venceu o set
            if (tieBreakA != 0 || tieBreakB != 0)
            {
                // quem tiver maior placar no tibrek venceu o set
                return (tieBreakA > tieBreakB);
            }
            else //como não jogou tiebreak vê quem fez mais games no set
            {
                // se foi informado empate no tiebreak então acusar erro
                if (gamesA == gamesB)
                {
                    return false; //TODO: erro por placar igual, voltar ao form informar placar, ter validação com annotations?
                }
                return (gamesA > gamesB);
            }
        }

        // recebe id do jogo
        public IActionResult CancelarDesafio(int id)
        {
            //TODO: adicionar motivo do cancelamento Cancelar(int idJogo, int idMotivoCancelamento)
            {
                // validar regras de cancelamento
                // verifica se é amistoso ou desafio, cancela de acordo 
                Jogo jogo = _context.Jogos.FirstOrDefault(j => j.Id == id);
                
                // busca tenista logado que será o responsável pelo cancelamento
                Tenista tenista = _context.Tenistas.FirstOrDefault(t => t.Email == User.Identity.Name);

                // TODO: testa se gera wo
                // desafio cancelado sempre gera wo quem está cancelando
                bool geraWO = false;
                // derrota por wo para o tenista logado que está cancelando 
                //se for desafiante quem cancelou não altera o ranking, se for o defensor desafiado quem cancelou ai w.o. altera o ranking
                // se ele for o desafiado e cancelou então inveter posição dos tenistas porque não defendeu a posição 
                if (tenista.Id == jogo.TenistaBId)
                {
                    InverterPosicaoTenistasRanking(jogo.TenistaAId, jogo.TenistaBId);
                    geraWO = true; //TODO: geraWO??
                }
                else
                {
                    //como é o tenista desafiante quem está cancelando, caso não havia ainda sido confirmado, não gera W.O.
                    if (jogo.RespostaConviteId == (int)RespostaConvite.Aceito)
                        geraWO = true;//TODO: geraWO??
                }

                // TODO: geraMulta? testa se gera multa e como irá anotar e cobrar a multa (bloquear usuário, informar por email da multa e como pagar)
                // se até 2h antes do jogo, não gera multa
                bool geraMulta = false;

                int motivoCancelamentoId;

                // testa se tenista logado que está cancelando é desafiante: motivo 5 - Solicitação do desafiante / 4 - Solicitação do defensor
                motivoCancelamentoId = (tenista.Id == jogo.TenistaAId) ? 5 : 4;

                int idCancelamento = RegistrarCancelamentoBD(tenista.Id, motivoCancelamentoId, geraMulta, geraWO);

                //cancela agenda
                Agenda agenda = _context.Agendas.FirstOrDefault(a => a.Id == jogo.AgendaId);
                agenda.FoiCancelada = true; //indica que a agenda foi cancelada, não será usada a quadra, pode liberar para outro desafio

                // atualiza jogo com resposta e cancelamento
                jogo.CancelamentoId = idCancelamento;
                jogo.TenistaDesistenteId = tenista.Id;
                jogo.TokenConfirmacao = ""; //exclui token por ser chave de passagem única
                jogo.TenistaVencedorId = (jogo.TenistaAId == tenista.Id ? jogo.TenistaBId : jogo.TenistaAId);
                _context.SaveChanges();

                string msgCancela = $"<h2>Desafio Cancelado!</h2><br/><h4>{agenda.DisplayAgenda}</h4><p>O tenista {tenista.DisplayNome} cancelou este desafio em {DateTime.Now}.<br/>";
                if (geraWO)
                    msgCancela += $"Como este desafio já havia sido confirmado será anotada derrota por W.O. para o tenista que solicitou o cancelamento do jogo.</p>";
                TempData["Mensagem"] = msgCancela;

                string headerMsg = $"Desafio Cancelado! - {agenda.DisplayAgenda}";
                EnviarEmailTenistasJogo(jogo, headerMsg, msgCancela);

                return View("Mensagem");
            }
        }

        //TODO: implementar cancelar amistoso com regras, hoje apenas cancela sem penalizar por WO ou por cancelar muito em cima
        public IActionResult CancelarAmistoso(int id)
        {
            //TODO: adicionar motivo do cancelamento Cancelar(int idJogo, int idMotivoCancelamento)
            {
                // TODO: validar regras de cancelamento AMISTOSO
                Jogo jogo = _context.Jogos.FirstOrDefault(j => j.Id == id);
                
                // busca tenista logado que será o responsável pelo cancelamento
                Tenista tenista = _context.Tenistas.FirstOrDefault(t => t.Email == User.Identity.Name);

                bool geraWO = false;
                //se convite havia sido confirmado gera WO
                if (jogo.RespostaConviteId == (int)RespostaConvite.Aceito)
                    geraWO = false; //TODO: mudar para TRUE?? geraWO?

                // TODO: geraMulta amistoso? testa se gera multa e como irá anotar e cobrar a multa (bloquear usuário, informar por email da multa e como pagar)
                // se até 2h antes do jogo, não gera multa
                bool geraMulta = false;

                int motivoCancelamentoId;

                // testa se tenista logado que está cancelando é desafiante: motivo 5 - Solicitação do desafiante / 4 - Solicitação do defensor
                motivoCancelamentoId = (tenista.Id == jogo.TenistaAId) ? 5 : 4;

                int idCancelamento = RegistrarCancelamentoBD(tenista.Id, motivoCancelamentoId, geraMulta, geraWO);

                //cancela agenda
                Agenda agenda = _context.Agendas.FirstOrDefault(a => a.Id == jogo.AgendaId);
                agenda.FoiCancelada = true; //indica que a agenda foi cancelada, não será usada a quadra, pode liberar para outro desafio

                // atualiza jogo com resposta e cancelamento
                jogo.CancelamentoId = idCancelamento;
                jogo.TenistaDesistenteId = tenista.Id;
                jogo.TokenConfirmacao = ""; //exclui token por ser chave de passagem única
                jogo.TenistaVencedorId = (jogo.TenistaAId == tenista.Id ? jogo.TenistaBId : jogo.TenistaAId);
                _context.SaveChanges();

                string msgCancela = $"<h2>Amistoso Cancelado!</h2><br/><h4>{agenda.DisplayAgenda}</h4><p>O tenista {tenista.DisplayNome} cancelou este amistoso em {DateTime.Now}.<br/>";
                if (geraWO)
                    msgCancela += $"Como este amistoso já havia sido confirmado será anotada derrota por W.O. para o tenista que solicitou o cancelamento do jogo.</p>";
                TempData["Mensagem"] = msgCancela;

                string headerMsg = $"Amistoso Cancelado! - {agenda.DisplayAgenda}";
                EnviarEmailTenistasJogo(jogo, headerMsg, msgCancela);

                return View("Mensagem");
            }
        }

        //reagendar jogo id cria uma nova agenda que poder ser para um jogo ou para uma aula
        public IActionResult ReagendarDesafio(int id)
        {
            //verifica se já tem um jogo anterior (jogoOriginal), 
            //se tem então não pode ser reagendado, só cancelado
            Jogo jogo = _context.Jogos.Include(j=>j.Agenda).FirstOrDefault(j => j.Id == id);
            List<Tenista> tenistas = _context.Tenistas.ToList();
            int tenistaLogadoId = tenistas.FirstOrDefault(t => t.Email == User.Identity.Name).Id;
            Tenista tenistaA = tenistas.FirstOrDefault(t => t.Id == jogo.TenistaAId);
            Tenista tenistaB = tenistas.FirstOrDefault(t => t.Id == jogo.TenistaBId);

            if (jogo.JogoOriginalId != 0)
            {
                string headerMsgErro = "<h3>Oops! Algo não deu certo aqui!</h3>";
                TempData["Mensagem"] = $"{headerMsgErro}<h4>Esta agenda já foi alterada uma primeira vez assim não será possível um novo reagendamento agora. <br/>" +
                    $"<p>Retornando a página anterior você terá a opção de cancelar este jogo, sendo anotada sua derrota por W.O.</p>";

                return View("Mensagem");
            }

            int limite = _context.RegrasGerais.First().PrazoMinutosReagendamentoSemWO;
            DateTime agora = DateTime.Now;
            //verifica se esta respeitando limite tempo para cancelamento, caso esteja não pode ser reagendado
            if (jogo.Agenda.Data.Date < agora.Date || (jogo.Agenda.Data.Date == agora.Date && jogo.Agenda.HoraInicial.TimeOfDay < agora.AddMinutes(limite).TimeOfDay) )
            {
                string headerMsgErro = "<h3>Oops! Algo não deu certo aqui!</h3>";
                TempData["Mensagem"] = $"{headerMsgErro}<h4>Não foi possível reagendar esta agenda pois ela já ultrapassou o limite para reagendamento que é de {limite} minutos antes do jogo.<br/>" +
                    $"<p>Retornando a página anterior você terá a opção de cancelar este jogo, sendo anotada sua derrota por W.O.</p>";

                return View("Mensagem");
            }

            //modificar agenda desafio
            Agenda agendaOriginal = _context.Agendas.FirstOrDefault(a => a.Id == jogo.AgendaId);
            agendaOriginal.FoiCancelada = true;

            //motivo 6 - Reagendado 
            int idCancelamento = RegistrarCancelamentoBD(tenistaLogadoId, 6, false, false);

            //cancela jogo originanl
            jogo.TokenConfirmacao = "";
            jogo.CancelamentoId = idCancelamento;
            _context.SaveChanges();

            // guardar id jogo original
            Jogo novoJogo = new Jogo();
            novoJogo.JogoOriginalId = jogo.Id;


            DesafioVM desafioVM = new DesafioVM
            {
                Jogo = novoJogo,
                TenistaA = tenistaA,
                TenistaB = tenistaB,
                AgendasPossiveis = CalcularDatasParaDesafio()
            };

            return View("Desafiar", desafioVM);
        }

        public IActionResult ReagendarAmistoso()
        {
            //reagendar jogo, validando regras de cancelamento
            return View();
        }

        // apresenta jogo agendado: amistoso ou desafio
        public IActionResult MinhaAgenda()
        {
            Tenista tenista = _context.Tenistas.FirstOrDefault(t => t.Email == User.Identity.Name);
            //busca jogos que o tenista logado aparece como desafiante ou defensor e que ainda não tenha TenistaVencedorId  ou não tenha sido cancelado, indicando que está agendado
            IEnumerable<Jogo> jogos = _context.Jogos.Include(j => j.Agenda).Where(j => (j.TenistaAId == tenista.Id || j.TenistaBId == tenista.Id)
                                       && (j.CancelamentoId == 0 && j.TenistaVencedorId == 0)).ToList();
                                        // && (j.Agenda.Data.Date >= DateTime.Now.Date)).ToList();

            List<JogoVM> jogoVMs = new List<JogoVM>();
            foreach (Jogo jogo in jogos)
            {
                JogoVM jogoVM = new JogoVM();
                jogoVM.TenistaA = _context.Tenistas.FirstOrDefault(t => t.Id == jogo.TenistaAId);
                jogoVM.TenistaB = _context.Tenistas.FirstOrDefault(t => t.Id == jogo.TenistaBId);
                jogoVM.Agenda = jogo.Agenda;
                jogoVM.Jogo = jogo;
                jogoVMs.Add(jogoVM);
            }
            return View(jogoVMs);
        }

        public IActionResult AgendarAmistoso()
        {
            AmistosoVM amistosoVM = new AmistosoVM(); 
            amistosoVM.AgendasPossiveis = CalcularDatasParaAmistoso();
            amistosoVM.TenistaA = _context.Tenistas.FirstOrDefault(t => t.Email == User.Identity.Name);
            amistosoVM.Tenistas = _context.Tenistas.Where(t => t.Id != amistosoVM.TenistaA.Id).ToList().OrderBy(t=>t.Sobrenome); //todos os tenistas menos o logado
            
            return View(amistosoVM);
        }

        public IActionResult HistoricoDesafios(int? id)
        {
            if (id==null)
                id = _context.Tenistas.FirstOrDefault(t => t.Email == User.Identity.Name).Id;

            // recupera lista dos últimos resultados de desafio do tenista id
            List<JogoVM> jogosVM = ListarUltimosResultadosJogos(true, null, id);

            ViewData["Tipo"] = "DESAFIOS";
            return View("Historico", jogosVM);
        }

        // TODO: estudar como montar um service para método ser usado por controller Jogo e Home (hoje está duplicado)
        // monta lista com ultimos x jogos de um tenista ou de qualquer tenista (desafio ou amistoso)
        // pode retornar todos os resultados ou os ultimos x jogos
        // pode retornar jogos de um tenista específico ou de qualquer
        private List<JogoVM> ListarUltimosResultadosJogos(bool ehDesafio, int? numeroJogos, int? idTenista)
        {
            List<JogoVM> jogosVM = new List<JogoVM>();
            List<Tenista> tenistas = _context.Tenistas.ToList();

            //recupera todos os jogos desafio ou amistosos, de acordo com parametro ehDesafio e que tenha um vencedor
            List<Jogo> jogos = _context.Jogos.Include(j => j.Agenda).Where(j => j.EhDesafio == ehDesafio && j.TenistaVencedorId != 0).OrderByDescending(j => j.Agenda.Data).ToList();

            // se foi especificado um tenista filtra jogos apenas dele
            if (idTenista != null)
                jogos = jogos.Where(j => j.TenistaAId == idTenista || j.TenistaBId == idTenista).ToList() ;

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

        // Calcula quais dias seriam possíveis de serem agendados segundo as regras gerais
        private IEnumerable<Agenda> CalcularDatasParaDesafio()
        {
            //carrega tabelas do BD para memória para agilizar
            List<Agenda> agendasBD = _context.Agendas.ToList();
            List<HorarioHabilitadoDesafio> horariosHabilitadosDesafio = _context.HorariosHabilitadoDesafio.ToList();

            List<Agenda> agendasPossiveis = new List<Agenda>();

            int antedecendiaMax = _context.RegrasGerais.First().AntecedenciaMaximaDias;
            FinalidadeUsoQuadra finalidadeUsoQuadra = _context.FinalidadeUsoQuadras.FirstOrDefault(f => f.Finalidade == "Ranking");
            int finalidadeId = finalidadeUsoQuadra.Id;
            int tempoJogoMinutos = finalidadeUsoQuadra.TempoReservaEmMinutos;

            DateTime dia = DateTime.Now;
            int diaSemana = 0; //1 dom - 2 seg ... 7 sab
            DateTime diaMaximo = dia.AddDays(antedecendiaMax);
            // faz um loop para verificar nos próximos dias do intervalo permitido quais dias são habilitados para ranking
            while (dia < diaMaximo)
            {   
                diaSemana = (int)dia.DayOfWeek + 1; //pro C# domingo é zero, sábado é 6, então tem que somar 1

                // verifica se para aquele dia da semana existem quadras habilitadas para jogos
                List<HorarioHabilitadoDesafio> horarios = horariosHabilitadosDesafio.Where(d => d.DiaSemana == diaSemana).ToList();

                foreach (HorarioHabilitadoDesafio horario in horarios)
                {
                    //faz um loop para adicionar todos os horários possíveis a partir do inicial, incrementando tempo de jogo, até o horário final
                    DateTime horaInicio = horario.HorarioInicial;
                    DateTime horaFim = horario.HorarioFinal;
                    // testa se o final do jogo não vai passar da hora limite final 
                    while (horaInicio.AddMinutes(tempoJogoMinutos).TimeOfDay <= horaFim.TimeOfDay)
                    {
                        Agenda agenda = new Agenda();
                        agenda.Id = agendasPossiveis.Count; //id temporário para auxiliar a identificar a agenda temporária quando for selecionada na view, depois será salva no bd com id definitivo
                        agenda.Data = dia.Date;
                        agenda.QuadraId = horario.QuadraId;
                        agenda.FinalidadeUsoQuadraId = finalidadeId;
                        agenda.HoraInicial = new DateTime(dia.Year, dia.Month, dia.Day, horaInicio.Hour, horaInicio.Minute, 00); 
                        DateTime horaFinal = horaInicio.AddMinutes(tempoJogoMinutos);
                        agenda.HoraFinal = new DateTime(dia.Year, dia.Month, dia.Day, horaFinal.Hour, horaFinal.Minute, 00);
                        //verifica se a hora início é futura (dia maior que hoje ou hora inicio maior que agora)
                        //e verifica se a agenda calculada já não foi reservada (e confirmada com pre-reserva == false)
                        //e se foi cancelada 
                        if ( (agenda.Data.Date > DateTime.Now.Date || agenda.HoraInicial.TimeOfDay > DateTime.Now.TimeOfDay) && 
                             (agendasBD.FirstOrDefault(a => a.Data.Date == agenda.Data.Date && a.HoraInicial.TimeOfDay == agenda.HoraInicial.TimeOfDay && a.QuadraId == agenda.QuadraId && a.FoiCancelada == false && a.EhPreReserva == false) == null))
                        { 
                            agendasPossiveis.Add(agenda);
                        }
                        horaInicio = agenda.HoraFinal;
                    }
                }
                dia = dia.AddDays(1);
            }
            return agendasPossiveis;
        }

        // Calcula quais dias seriam possíveis de serem agendados segundo as regras gerais
        private IEnumerable<Agenda> CalcularDatasParaAmistoso() 
        {
            //carrega tabelas do BD para memória para agilizar
            List<Agenda> agendasBD = _context.Agendas.ToList();
            List<HorarioHabilitadoAmistoso> horariosHabilitadosAmistoso= _context.HorariosHabilitadoAmistoso.ToList();
            RegrasAgendaAmistoso regrasAgendaAmistoso = _context.RegrasAgendaAmistoso.First();

            List<Agenda> agendasPossiveis = new List<Agenda>();

            int antedecendiaMax = regrasAgendaAmistoso.AntecedenciaMaximaDias;

            FinalidadeUsoQuadra finalidadeUsoQuadra = _context.FinalidadeUsoQuadras.FirstOrDefault(f => f.Finalidade == "Amistoso");
            int finalidadeId = finalidadeUsoQuadra.Id;
            int tempoJogoMinutos = finalidadeUsoQuadra.TempoReservaEmMinutos;

            DateTime dia = DateTime.Now;
            int diaSemana = 0; //1 dom - 2 seg ... 7 sab
            DateTime diaMaximo = dia.AddDays(antedecendiaMax);
            // faz um loop para verificar nos próximos dias do intervalo permitido quais dias são habilitados para ranking
            while (dia <= diaMaximo)
            {
                diaSemana = (int)dia.DayOfWeek + 1; //pro C# domingo é zero, sábado é 6, então tem que somar 1

                // verifica se para aquele dia da semana existem quadras habilitadas para jogos
                List<HorarioHabilitadoAmistoso> horarios = horariosHabilitadosAmistoso.Where(d => d.DiaSemana == diaSemana).ToList();

                foreach (HorarioHabilitadoAmistoso horario in horarios)
                {
                    //faz um loop para adicionar todos os horários possíveis a partir do inicial, incrementando tempo de jogo, até o horário final
                    DateTime horaInicio = horario.HorarioInicial;
                    DateTime horaFim = horario.HorarioFinal;
                    // testa se o final do jogo não vai passar da hora limite final 
                    while (horaInicio.AddMinutes(tempoJogoMinutos).TimeOfDay <= horaFim.TimeOfDay)
                    {
                        Agenda agenda = new Agenda();
                        agenda.Id = agendasPossiveis.Count; //id temporário para auxiliar a identificar a agenda temporária quando for selecionada na view, depois será salva no bd com id definitivo
                        agenda.Data = dia.Date;
                        agenda.QuadraId = horario.QuadraId;
                        agenda.FinalidadeUsoQuadraId = finalidadeId;
                        agenda.HoraInicial = new DateTime(dia.Year, dia.Month, dia.Day, horaInicio.Hour, horaInicio.Minute, 00);
                        DateTime horaFinal = horaInicio.AddMinutes(tempoJogoMinutos);
                        agenda.HoraFinal = new DateTime(dia.Year, dia.Month, dia.Day, horaFinal.Hour, horaFinal.Minute, 00);
                        //verifica se a hora início é futura (dia maior que hoje ou hora inicio maior que agora)
                        //e verifica se a agenda calculada já não foi reservada (e confirmada com pre-reserva == false)
                        //e se foi cancelada 
                        if ((agenda.Data.Date > DateTime.Now.Date || agenda.HoraInicial.TimeOfDay > DateTime.Now.TimeOfDay) &&
                             (agendasBD.FirstOrDefault(a => a.Data.Date == agenda.Data.Date && a.HoraInicial.TimeOfDay == agenda.HoraInicial.TimeOfDay && a.QuadraId == agenda.QuadraId && a.FoiCancelada == false && a.EhPreReserva == false) == null))
                        {
                            agendasPossiveis.Add(agenda);
                        }
                        horaInicio = agenda.HoraFinal;
                    }
                }
                dia = dia.AddDays(1);
            }
            return agendasPossiveis;
        }


        private async void EnviarEmailChamadaDesafio(DesafioVM desafioVM)
        {
            string tokenConfirmacao = desafioVM.Jogo.TokenConfirmacao;
            string callbackUrlConfirmarDesafio = GerarCallBackUrlDesafio(desafioVM, "ConfirmarDesafio", tokenConfirmacao);
            string callbackUrlRecusarDesafio = GerarCallBackUrlDesafio(desafioVM, "RecusarDesafio", tokenConfirmacao);
            string callbackUrlEntregarDesafio = GerarCallBackUrlDesafio(desafioVM, "EntregarDesafio", tokenConfirmacao);

            string desafiante = desafioVM.TenistaA.DisplayNome;

            // monta email
            await _emailSender.SendEmailAsync(
                                desafioVM.TenistaB.Email,
                                $"Desafio! - {desafioVM.Agenda.DisplayAgenda}",
                                $"<p>Olá <b>{desafioVM.TenistaB.Nome.Trim()}</b>!</p>" + 
                                $"<p>Sua posição no Ranking GTM está sendo desafiada ... prepare-se para defendê-la!</p>" +
                                $"<p>O tenista <b>{desafiante}</b> chamou o desafio com a seguinte agenda (pré-reserva):</p>" +
                                $"<h4><b>{desafioVM.Agenda.DisplayAgenda}</b></h4>" +
                                $"<p>Agora tudo que você precisa fazer é responder a este desafio selecionando uma das três opções abaixo:</p>" +
                                $"<ul>" +
                                $"<li><a href = '{HtmlEncoder.Default.Encode(callbackUrlConfirmarDesafio)}'>Confirmar o desafio</a > e ir pro jogo!</p>" +
                                $"<li><a href = '{HtmlEncoder.Default.Encode(callbackUrlRecusarDesafio)}'>Recusar este convite</a > - o desafio pode ser recusado uma única vez e uma nova agenda será indicada pelo desafiante. Em uma eventual segunda recusa o desafiante será declarado vencedor por W.O.</p>" +
                                $"<li><a href = '{HtmlEncoder.Default.Encode(callbackUrlEntregarDesafio)}'>Entregar minha posição no ranking</a > - escolha esta opção se não for jogar este desafio, o desafiante será declarado vencedor por W.O. e você irá cair uma posição no ranking.</p>" +
                                $"</ul>" +
                                $"<p>ATENÇÃO: RESPONDA RAPIDAMENTE PARA GARANTIR ESTA AGENDA!<BR/>Esta é uma <b>pré-reserva</b> e enquanto não for confirmada através do link acima existe a possibilidade de um outro desafio ocupar esta agenda caso seja confirmado primeiro. Então não perca tempo. Confirme já e garanta este jogo!</p>" +
                                $"<p>Ranking GTM</p>");
        }

        private async void EnviarEmailTenistasJogo(Jogo jogo, string subjectEmail, string mensagemEmail)
        {
            List<Tenista> tenistas = _context.Tenistas.ToList();
            Tenista tenistaA = tenistas.FirstOrDefault(t => t.Id == jogo.TenistaAId);
            Tenista tenistaB = tenistas.FirstOrDefault(t => t.Id == jogo.TenistaBId);

            // envia email para desafiante
            await _emailSender.SendEmailAsync( tenistaA.Email,  subjectEmail, mensagemEmail);
            // envia email para defensor
            await _emailSender.SendEmailAsync( tenistaB.Email,  subjectEmail, mensagemEmail);
        }


        private string GerarTokenConfirmacaoDesafio(DesafioVM desafioVM)
        {
            // monta uma string única para ser usada como token
            string tokenConfirmacao = $"{desafioVM.GetHashCode()} {DateTime.UtcNow.GetHashCode()}";
            tokenConfirmacao = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(tokenConfirmacao));

            return tokenConfirmacao; 
        }

        private string GerarCallBackUrlDesafio(DesafioVM desafioVM, string respostaDesafio, string tokenConfirmacao)
        {
            //respostaDesafio: ConfirmarDesafio, RecusarDesafio, EntregarDesafio
            string code = tokenConfirmacao;
            var callbackUrl = Url.Action($"{respostaDesafio}", "Jogo",  new { code }, Request.Scheme);

            return callbackUrl;
        }

        private string GerarCallBackUrlAmistoso(AmistosoVM amistosoVM, string respostaAmistoso, string tokenConfirmacao)
        {
            //respostaDesafio: ConfirmarDesafio, RecusarDesafio, EntregarDesafio
            string code = tokenConfirmacao;
            var callbackUrl = Url.Action($"{respostaAmistoso}", "Jogo", new { code }, Request.Scheme);

            return callbackUrl;
        }

        // inverte a posição de dois tenista no ranking, propagando a mudança para tenistas posicionados entre eles
        private void InverterPosicaoTenistasRanking(int tenistaAId, int tenistaBId)
        {
            // trabalhar com duas instâncias do objeto (uma original e uma bd) para na atualização não dar problema por alterar um valor (referência)
            // aparentemente em algum caso pode acontecer de por ser objeto por referência ao atribuir direto e depois atualizar, propaga a atualização
            RankingTenistas rankingTenistaA = _context.RankingTenistas.FirstOrDefault(r => r.TenistaId == tenistaAId);
            byte posicaoAtualOriginalTenistaA = rankingTenistaA.Posicao;
            DateTime dataPosicaoAtualOriginalTenistaA = rankingTenistaA.DataPosicaoAtual;
            byte posicaoAtualOriginalTenistaB = _context.RankingTenistas.FirstOrDefault(r => r.TenistaId == tenistaBId).Posicao;
            int distanciaEntrePosicoes = posicaoAtualOriginalTenistaA - posicaoAtualOriginalTenistaB;

            // vai propagando a queda no ranking para todos os tenistas desde um acima do desafiante até o desafiado: todos caem uma posição
            for (int i = 1; i<=distanciaEntrePosicoes; i++)
            {
                RankingTenistas rankingTenista = _context.RankingTenistas.FirstOrDefault(r => r.Posicao == posicaoAtualOriginalTenistaA - i);
                rankingTenista.PosicaoAnterior = rankingTenista.Posicao;
                rankingTenista.Posicao = (byte)(rankingTenista.Posicao + 1); 
                rankingTenista.DataPosicaoAnterior = rankingTenista.DataPosicaoAtual;
                rankingTenista.DataPosicaoAtual = DateTime.Now.Date;
                _context.SaveChanges();
            }
            //depois de atualizar as posições entre o desafiado e o desafiante, atualiza a posição do desafiante com a inicial do desafiado
            rankingTenistaA.PosicaoAnterior = rankingTenistaA.Posicao;
            rankingTenistaA.Posicao = posicaoAtualOriginalTenistaB;
            rankingTenistaA.DataPosicaoAnterior = rankingTenistaA.DataPosicaoAtual;
            rankingTenistaA.DataPosicaoAtual = DateTime.Now.Date;
            _context.SaveChanges();
        }

        // Derruba todos os outros jogos/agendas em pré-reserva que tinham esse mesmo horário já que agora foi confirmado
        private void CancelarPreAgendasConflitantesComJogoConfirmado(Jogo jogo)
        {
            // recupera a lista de jogos com a mesma agenda (data/hora/quadra) que estão em pré-reserva e que não tenham sido canceladas
            List<Jogo> jogosParaCancelar = _context.Jogos.Include(j => j.Agenda).Where(j => j.Agenda.EhPreReserva == true && j.Agenda.Data == jogo.Agenda.Data
                                && j.Agenda.HoraInicial == jogo.Agenda.HoraInicial && j.Agenda.QuadraId == jogo.Agenda.QuadraId && j.CancelamentoId == 0).ToList();

            List<Tenista> tenistas = _context.Tenistas.ToList();

            // cancelar os jogos, informando o motivo de cancelamento: data ocupada por outro desafio que foi confirmado antes
            foreach (Jogo jogoCancelando in jogosParaCancelar)
            {
                // gera cancelamento
                Cancelamento cancelamento = new Cancelamento
                {
                    CanceladoPorTenistaId = 0, //cancelado pelo sistema não por algum dos tenistas
                    DataCancelamento = DateTime.Now,
                    GerouMulta = false,
                    GerouWO = false,
                    MotivoCancelamentoId = 7 //Pré-agenda foi ocupada
                };
                _context.Cancelamentos.Add(cancelamento);
                _context.SaveChanges();

                jogoCancelando.CancelamentoId = cancelamento.Id;
                jogoCancelando.TokenConfirmacao = "";
                _context.SaveChanges();

                Tenista tenistaA = tenistas.FirstOrDefault(t => t.Id == jogoCancelando.TenistaAId);
                Tenista tenistaB = tenistas.FirstOrDefault(t => t.Id == jogoCancelando.TenistaBId);
                
                //enviar email para informar que a pré-reserva foi ocupada por outro desafio
                string msgEmail= $"<h2>Pré-Agenda cancelada!</h2><br/><h4>{tenistaA.DisplayNome}   vs   {tenistaB.DisplayNome}</h4><p>{jogoCancelando.Agenda.DisplayAgenda}</p>" +
                    $"<p>Infelizmente esta agenda foi ocupada por um outro jogo que teve resposta de confirmação antes que este convite fosse confirmado.</p>" +
                    $"<p>Este jogo foi cancelado automaticamente e você poderá refazer o convite escolhendo uma nova agenda disponível.</p>";

                string headerMsg = $"Pré-Agenda Cancelada! - {jogoCancelando.Agenda.DisplayAgenda}";
                //enviar email confirmando a reserva, mudar de pré-reserva na agenda
                EnviarEmailTenistasJogo(jogoCancelando, headerMsg, msgEmail);
            }
        }


    }
}
