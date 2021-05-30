using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TennisRanking.Models;

namespace TennisRanking.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Cancelamento> Cancelamentos { get; set; }
        public DbSet<FinalidadeUsoQuadra> FinalidadeUsoQuadras { get; set; }
        public DbSet<HorarioHabilitadoDesafio> HorariosHabilitadoDesafio { get; set; }
        public DbSet<HorarioHabilitadoAmistoso> HorariosHabilitadoAmistoso { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<MotivoBloqueio> MotivosBloqueio { get; set; }
        public DbSet<MotivoCancelamento> MotivosCancelamento { get; set; }
        public DbSet<Placar> Placares { get; set; }
        public DbSet<Quadra> Quadras { get; set; }
        public DbSet<RankingTenistas> RankingTenistas { get; set; }
        public DbSet<RegrasGerais> RegrasGerais { get; set; }
        public DbSet<RegrasAgendaAmistoso> RegrasAgendaAmistoso { get; set; }
        public DbSet<Tenista> Tenistas { get; set; }
        public DbSet<Cidade> Cidades { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed Cidade
            builder.Entity<Cidade>().HasData(new Cidade { Id = 1, Nome = "Medianeira" });
            builder.Entity<Cidade>().HasData(new Cidade { Id = 2, Nome = "Matelândia" });
            builder.Entity<Cidade>().HasData(new Cidade { Id = 3, Nome = "São Miguel do Iguaçu" });
            builder.Entity<Cidade>().HasData(new Cidade { Id = 4, Nome = "Foz do Iguaçu" });
            builder.Entity<Cidade>().HasData(new Cidade { Id = 5, Nome = "Missal" });
            builder.Entity<Cidade>().HasData(new Cidade { Id = 6, Nome = "Itaipulândia" });
            builder.Entity<Cidade>().HasData(new Cidade { Id = 7, Nome = "Serranópolis do Iguaçu" });
            builder.Entity<Cidade>().HasData(new Cidade { Id = 8, Nome = "Cascavel" });

            // Seed Motivo Cancelamento
            builder.Entity<MotivoCancelamento>().HasData(new MotivoCancelamento { Id = 1, Motivo = "Chuva" });
            builder.Entity<MotivoCancelamento>().HasData(new MotivoCancelamento { Id = 2, Motivo = "Manutenção" });
            builder.Entity<MotivoCancelamento>().HasData(new MotivoCancelamento { Id = 3, Motivo = "Falta de luz" });
            builder.Entity<MotivoCancelamento>().HasData(new MotivoCancelamento { Id = 4, Motivo = "Solicitação do desafiado" });
            builder.Entity<MotivoCancelamento>().HasData(new MotivoCancelamento { Id = 5, Motivo = "Solicitação do desafiante" });
            builder.Entity<MotivoCancelamento>().HasData(new MotivoCancelamento { Id = 6, Motivo = "Reagendado" });
            builder.Entity<MotivoCancelamento>().HasData(new MotivoCancelamento { Id = 7, Motivo = "Pré-agenda foi ocupada" });

            // Seed Motivo Bloqueio
            builder.Entity<MotivoBloqueio>().HasData(new MotivoBloqueio { Id=1, Motivo="Pendência Mensalidade"});
            builder.Entity<MotivoBloqueio>().HasData(new MotivoBloqueio { Id=2, Motivo="Pendência Multa"});
            builder.Entity<MotivoBloqueio>().HasData(new MotivoBloqueio { Id=3, Motivo="Decisão CCO"});

            // Seed FinalidadeUsoQuadra
            builder.Entity<FinalidadeUsoQuadra>().HasData(new FinalidadeUsoQuadra { Id = 1, Finalidade = "Aula", TempoReservaEmMinutos = 30 });
            builder.Entity<FinalidadeUsoQuadra>().HasData(new FinalidadeUsoQuadra { Id = 2, Finalidade = "Ranking", TempoReservaEmMinutos = 120 });
            builder.Entity<FinalidadeUsoQuadra>().HasData(new FinalidadeUsoQuadra { Id = 3, Finalidade = "Amistoso", TempoReservaEmMinutos = 60 });
            builder.Entity<FinalidadeUsoQuadra>().HasData(new FinalidadeUsoQuadra { Id = 4, Finalidade = "Ranking, Amistoso", TempoReservaEmMinutos = 0 });
            builder.Entity<FinalidadeUsoQuadra>().HasData(new FinalidadeUsoQuadra { Id = 5, Finalidade = "Todas", TempoReservaEmMinutos = 0 });

            // Seed Quadra
            builder.Entity<Quadra>().HasData(new Quadra { Id = 1, Nome="Quadra #1", FinalidadeUsoQuadraId = 1 });
            builder.Entity<Quadra>().HasData(new Quadra { Id = 2, Nome = "Quadra #2", FinalidadeUsoQuadraId = 2 });
            builder.Entity<Quadra>().HasData(new Quadra { Id = 3, Nome = "Quadra #3", FinalidadeUsoQuadraId = 3 });

            // Seed HorarioHabilitadoDesafio
            DateTime HoraInicialSemanaDesafio = Convert.ToDateTime("19:00:00");
            DateTime HoraFinalSemanaDesafio = Convert.ToDateTime("22:00:00");
            DateTime HoraInicialSabadoDesafio = Convert.ToDateTime("15:00:00");
            DateTime HoraFinalSabadoDesafio = Convert.ToDateTime("20:00:00");
            DateTime HoraInicialDomingoDesafio = Convert.ToDateTime("09:00:00");
            DateTime HoraFinalDomingoDesafio = Convert.ToDateTime("12:00:00");
            // horario quadra 1
            builder.Entity<HorarioHabilitadoDesafio>().HasData(new HorarioHabilitadoDesafio { Id = 1, DiaSemana = 4, HorarioInicial = HoraInicialSemanaDesafio, HorarioFinal = HoraFinalSemanaDesafio, QuadraId = 1 });
            builder.Entity<HorarioHabilitadoDesafio>().HasData(new HorarioHabilitadoDesafio { Id = 2, DiaSemana = 6, HorarioInicial = HoraInicialSemanaDesafio, HorarioFinal = HoraFinalSemanaDesafio, QuadraId = 1 });
            builder.Entity<HorarioHabilitadoDesafio>().HasData(new HorarioHabilitadoDesafio { Id = 3, DiaSemana = 7, HorarioInicial = HoraInicialSabadoDesafio, HorarioFinal = HoraFinalSabadoDesafio, QuadraId = 1 });
            builder.Entity<HorarioHabilitadoDesafio>().HasData(new HorarioHabilitadoDesafio { Id = 4, DiaSemana = 1, HorarioInicial = HoraInicialDomingoDesafio, HorarioFinal = HoraFinalDomingoDesafio, QuadraId = 1 });
            // horario quadra 3
            builder.Entity<HorarioHabilitadoDesafio>().HasData(new HorarioHabilitadoDesafio { Id = 9, DiaSemana = 4, HorarioInicial = HoraInicialSemanaDesafio, HorarioFinal = HoraFinalSemanaDesafio, QuadraId = 3 });
            builder.Entity<HorarioHabilitadoDesafio>().HasData(new HorarioHabilitadoDesafio { Id = 10, DiaSemana = 6, HorarioInicial = HoraInicialSemanaDesafio, HorarioFinal = HoraFinalSemanaDesafio, QuadraId = 3 });

            // Seed HorarioHabilitadoAmistoso
            DateTime HoraInicialSemanaAmistoso = Convert.ToDateTime("08:00:00");
            DateTime HoraFinalSemanaAmistoso = Convert.ToDateTime("22:00:00");
            DateTime HoraInicialSabadoAmistoso = Convert.ToDateTime("15:00:00");
            DateTime HoraFinalSabadoAmistoso = Convert.ToDateTime("20:00:00");
            DateTime HoraInicialDomingoAmistoso = Convert.ToDateTime("09:00:00");
            DateTime HoraFinalDomingoAmistoso = Convert.ToDateTime("12:00:00");
            // horario quadra 1
            /*
            builder.Entity<HorarioHabilitadoAmistoso>().HasData(new HorarioHabilitadoAmistoso { Id = 1, DiaSemana = 1, HorarioInicial = HoraInicialSemanaAmistoso, HorarioFinal = HoraFinalSemanaAmistoso, QuadraId = 1 });
            builder.Entity<HorarioHabilitadoAmistoso>().HasData(new HorarioHabilitadoAmistoso { Id = 2, DiaSemana = 2, HorarioInicial = HoraInicialSemanaAmistoso, HorarioFinal = HoraFinalSemanaAmistoso, QuadraId = 1 });
            builder.Entity<HorarioHabilitadoAmistoso>().HasData(new HorarioHabilitadoAmistoso { Id = 3, DiaSemana = 3, HorarioInicial = HoraInicialSabadoAmistoso, HorarioFinal = HoraFinalSabadoAmistoso, QuadraId = 1 });
            builder.Entity<HorarioHabilitadoAmistoso>().HasData(new HorarioHabilitadoAmistoso { Id = 4, DiaSemana = 4, HorarioInicial = HoraInicialDomingoAmistoso, HorarioFinal = HoraFinalDomingoAmistoso, QuadraId = 1 });
            builder.Entity<HorarioHabilitadoAmistoso>().HasData(new HorarioHabilitadoAmistoso { Id = 5, DiaSemana = 5, HorarioInicial = HoraInicialDomingoAmistoso, HorarioFinal = HoraFinalDomingoAmistoso, QuadraId = 1 });
            builder.Entity<HorarioHabilitadoAmistoso>().HasData(new HorarioHabilitadoAmistoso { Id = 6, DiaSemana = 6, HorarioInicial = HoraInicialDomingoAmistoso, HorarioFinal = HoraFinalDomingoAmistoso, QuadraId = 1 });
            */
            // Seed RegrasGerais
            builder.Entity<RegrasGerais>().HasData(new RegrasGerais
            {
                Id = 1,
                PosicoesAcima = 2,
                MinimoDiasEntreDesafios = 7,
                MaximoDiasEntreDesafios = 30,
                MaximoRecusas = 2,
                MultaWO = 20,
                PrazoMinutosCancelamentoSemMulta = 120,
                PrazoMinutosReagendamentoSemWO = 120,
                PrazoHorasRespostaDesafio = 24,
                MinimoDiasParaRevanche = 15,
                JogosNoAd = true,
                NumeroJogadoresTorneioFinalsFeminino = 4,
                NumeroJogadoresTorneioFinalsMasculino = 8,
                ToleranciaMinutosWO = 15,
                AquecimentoMinutos = 10
            });

            // Seed RegrasGerais
            builder.Entity<RegrasAgendaAmistoso>().HasData(new RegrasAgendaAmistoso
            {
                Id = 1,
                AntecedenciaMaximaDias = 2,
                HorarioLiberarAgendamento = Convert.ToDateTime("13:00:00"),
                PrazoMinutosCancelamentoSemMulta = 120,
                PrazoMinutosReagendamentoSemWO = 120,
                MinimoDiasEntreAmistosos=2,
                MultaWO=20
            });

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
