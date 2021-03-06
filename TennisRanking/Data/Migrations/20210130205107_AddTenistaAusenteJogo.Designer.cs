// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TennisRanking.Data;

namespace TennisRanking.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210130205107_AddTenistaAusenteJogo")]
    partial class AddTenistaAusenteJogo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TennisRanking.Models.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EhPreReserva")
                        .HasColumnType("bit");

                    b.Property<int>("FinalidadeUsoQuadraId")
                        .HasColumnType("int");

                    b.Property<bool>("FoiCancelada")
                        .HasColumnType("bit");

                    b.Property<DateTime>("HoraFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraInicial")
                        .HasColumnType("datetime2");

                    b.Property<int>("QuadraId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("TennisRanking.Models.Cancelamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CanceladoPorTenistaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCancelamento")
                        .HasColumnType("datetime2");

                    b.Property<bool>("GerouMulta")
                        .HasColumnType("bit");

                    b.Property<bool>("GerouWO")
                        .HasColumnType("bit");

                    b.Property<int>("MotivoCancelamentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cancelamentos");
                });

            modelBuilder.Entity("TennisRanking.Models.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cidades");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Medianeira"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Matelândia"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "São Miguel do Iguaçu"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Foz do Iguaçu"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Missal"
                        },
                        new
                        {
                            Id = 6,
                            Nome = "Itaipulândia"
                        },
                        new
                        {
                            Id = 7,
                            Nome = "Serranópolis do Iguaçu"
                        },
                        new
                        {
                            Id = 8,
                            Nome = "Cascavel"
                        });
                });

            modelBuilder.Entity("TennisRanking.Models.FinalidadeUsoQuadra", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("Finalidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TempoReservaEmMinutos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FinalidadeUsoQuadras");

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            Finalidade = "Aula",
                            TempoReservaEmMinutos = 30
                        },
                        new
                        {
                            Id = (byte)2,
                            Finalidade = "Ranking",
                            TempoReservaEmMinutos = 120
                        },
                        new
                        {
                            Id = (byte)3,
                            Finalidade = "Amistoso",
                            TempoReservaEmMinutos = 60
                        },
                        new
                        {
                            Id = (byte)4,
                            Finalidade = "Ranking, Amistoso",
                            TempoReservaEmMinutos = 0
                        },
                        new
                        {
                            Id = (byte)5,
                            Finalidade = "Todas",
                            TempoReservaEmMinutos = 0
                        });
                });

            modelBuilder.Entity("TennisRanking.Models.HorarioHabilitadoDesafio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("DiaSemana")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("HorarioFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HorarioInicial")
                        .HasColumnType("datetime2");

                    b.Property<int>("QuadraId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HorariosHabilitadoDesafio");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DiaSemana = (byte)4,
                            HorarioFinal = new DateTime(2021, 1, 30, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            HorarioInicial = new DateTime(2021, 1, 30, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            QuadraId = 1
                        },
                        new
                        {
                            Id = 2,
                            DiaSemana = (byte)6,
                            HorarioFinal = new DateTime(2021, 1, 30, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            HorarioInicial = new DateTime(2021, 1, 30, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            QuadraId = 1
                        },
                        new
                        {
                            Id = 3,
                            DiaSemana = (byte)7,
                            HorarioFinal = new DateTime(2021, 1, 30, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            HorarioInicial = new DateTime(2021, 1, 30, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            QuadraId = 1
                        },
                        new
                        {
                            Id = 4,
                            DiaSemana = (byte)1,
                            HorarioFinal = new DateTime(2021, 1, 30, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            HorarioInicial = new DateTime(2021, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            QuadraId = 1
                        },
                        new
                        {
                            Id = 6,
                            DiaSemana = (byte)6,
                            HorarioFinal = new DateTime(2021, 1, 30, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            HorarioInicial = new DateTime(2021, 1, 30, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            QuadraId = 2
                        },
                        new
                        {
                            Id = 7,
                            DiaSemana = (byte)7,
                            HorarioFinal = new DateTime(2021, 1, 30, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            HorarioInicial = new DateTime(2021, 1, 30, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            QuadraId = 2
                        },
                        new
                        {
                            Id = 8,
                            DiaSemana = (byte)1,
                            HorarioFinal = new DateTime(2021, 1, 30, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            HorarioInicial = new DateTime(2021, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            QuadraId = 2
                        },
                        new
                        {
                            Id = 9,
                            DiaSemana = (byte)4,
                            HorarioFinal = new DateTime(2021, 1, 30, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            HorarioInicial = new DateTime(2021, 1, 30, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            QuadraId = 3
                        },
                        new
                        {
                            Id = 10,
                            DiaSemana = (byte)6,
                            HorarioFinal = new DateTime(2021, 1, 30, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            HorarioInicial = new DateTime(2021, 1, 30, 19, 0, 0, 0, DateTimeKind.Unspecified),
                            QuadraId = 3
                        },
                        new
                        {
                            Id = 11,
                            DiaSemana = (byte)7,
                            HorarioFinal = new DateTime(2021, 1, 30, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            HorarioInicial = new DateTime(2021, 1, 30, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            QuadraId = 3
                        },
                        new
                        {
                            Id = 12,
                            DiaSemana = (byte)1,
                            HorarioFinal = new DateTime(2021, 1, 30, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            HorarioInicial = new DateTime(2021, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            QuadraId = 3
                        });
                });

            modelBuilder.Entity("TennisRanking.Models.Jogo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgendaId")
                        .HasColumnType("int");

                    b.Property<int>("CancelamentoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataConvite")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataRespostaConvite")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EhDesafio")
                        .HasColumnType("bit");

                    b.Property<int>("JogoOriginalId")
                        .HasColumnType("int");

                    b.Property<int>("PlacarId")
                        .HasColumnType("int");

                    b.Property<int>("RespostaConviteId")
                        .HasColumnType("int");

                    b.Property<int>("TenistaAId")
                        .HasColumnType("int");

                    b.Property<int>("TenistaAusenteWOId")
                        .HasColumnType("int");

                    b.Property<int>("TenistaBId")
                        .HasColumnType("int");

                    b.Property<int>("TenistaDesistenteId")
                        .HasColumnType("int");

                    b.Property<int>("TenistaVencedorId")
                        .HasColumnType("int");

                    b.Property<string>("TokenConfirmacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AgendaId");

                    b.ToTable("Jogos");
                });

            modelBuilder.Entity("TennisRanking.Models.MotivoBloqueio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MotivosBloqueio");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Motivo = "Pendência Mensalidade"
                        },
                        new
                        {
                            Id = 2,
                            Motivo = "Pendência Multa"
                        },
                        new
                        {
                            Id = 3,
                            Motivo = "Decisão CCO"
                        });
                });

            modelBuilder.Entity("TennisRanking.Models.MotivoCancelamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MotivosCancelamento");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Motivo = "Chuva"
                        },
                        new
                        {
                            Id = 2,
                            Motivo = "Manutenção"
                        },
                        new
                        {
                            Id = 3,
                            Motivo = "Falta de luz"
                        },
                        new
                        {
                            Id = 4,
                            Motivo = "Solicitação do desafiado"
                        },
                        new
                        {
                            Id = 5,
                            Motivo = "Solicitação do desafiante"
                        },
                        new
                        {
                            Id = 6,
                            Motivo = "Reagendado"
                        },
                        new
                        {
                            Id = 7,
                            Motivo = "Pré-agenda foi ocupada"
                        });
                });

            modelBuilder.Entity("TennisRanking.Models.Placar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Set1GamesTenistaA")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Set1GamesTenistaB")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Set1TieBreakTenistaA")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Set1TieBreakTenistaB")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Set2GamesTenistaA")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Set2GamesTenistaB")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Set2TieBreakTenistaA")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Set2TieBreakTenistaB")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Set3GamesTenistaA")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Set3GamesTenistaB")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Set3TieBreakTenistaA")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Set3TieBreakTenistaB")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Placares");
                });

            modelBuilder.Entity("TennisRanking.Models.Quadra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FinalidadeUsoQuadraId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Quadras");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FinalidadeUsoQuadraId = 1,
                            Nome = "Quadra #1"
                        },
                        new
                        {
                            Id = 2,
                            FinalidadeUsoQuadraId = 2,
                            Nome = "Quadra #2"
                        },
                        new
                        {
                            Id = 3,
                            FinalidadeUsoQuadraId = 3,
                            Nome = "Quadra #3"
                        });
                });

            modelBuilder.Entity("TennisRanking.Models.RankingTenistas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataPosicaoAnterior")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPosicaoAtual")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPosicaoInicial")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Posicao")
                        .HasColumnType("tinyint");

                    b.Property<byte>("PosicaoAnterior")
                        .HasColumnType("tinyint");

                    b.Property<byte>("PosicaoInicial")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Sexo")
                        .HasColumnType("tinyint");

                    b.Property<int>("TenistaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TenistaId");

                    b.ToTable("RankingTenistas");
                });

            modelBuilder.Entity("TennisRanking.Models.RegrasGerais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("AntecedenciaMaximaDias")
                        .HasColumnType("tinyint");

                    b.Property<byte>("AquecimentoMinutos")
                        .HasColumnType("tinyint");

                    b.Property<bool>("JogosNoAd")
                        .HasColumnType("bit");

                    b.Property<byte>("MaximoDiasEntreDesafios")
                        .HasColumnType("tinyint");

                    b.Property<byte>("MaximoRecusas")
                        .HasColumnType("tinyint");

                    b.Property<byte>("MinimoDiasEntreDesafios")
                        .HasColumnType("tinyint");

                    b.Property<byte>("MinimoDiasParaRevanche")
                        .HasColumnType("tinyint");

                    b.Property<byte>("MultaWO")
                        .HasColumnType("tinyint");

                    b.Property<byte>("NumeroJogadoresTorneioFinalsFeminino")
                        .HasColumnType("tinyint");

                    b.Property<byte>("NumeroJogadoresTorneioFinalsMasculino")
                        .HasColumnType("tinyint");

                    b.Property<byte>("PosicoesAcima")
                        .HasColumnType("tinyint");

                    b.Property<byte>("PrazoHorasCancelamentoSemMulta")
                        .HasColumnType("tinyint");

                    b.Property<byte>("PrazoHorasRespostaDesafio")
                        .HasColumnType("tinyint");

                    b.Property<byte>("ToleranciaMinutosWO")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("RegrasGerais");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AntecedenciaMaximaDias = (byte)0,
                            AquecimentoMinutos = (byte)10,
                            JogosNoAd = true,
                            MaximoDiasEntreDesafios = (byte)30,
                            MaximoRecusas = (byte)2,
                            MinimoDiasEntreDesafios = (byte)7,
                            MinimoDiasParaRevanche = (byte)15,
                            MultaWO = (byte)20,
                            NumeroJogadoresTorneioFinalsFeminino = (byte)4,
                            NumeroJogadoresTorneioFinalsMasculino = (byte)8,
                            PosicoesAcima = (byte)2,
                            PrazoHorasCancelamentoSemMulta = (byte)4,
                            PrazoHorasRespostaDesafio = (byte)12,
                            ToleranciaMinutosWO = (byte)15
                        });
                });

            modelBuilder.Entity("TennisRanking.Models.Tenista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("AlturaCm")
                        .HasColumnType("tinyint");

                    b.Property<string>("Apelido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte?>("Backhand")
                        .IsRequired()
                        .HasColumnType("tinyint");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<int?>("CidadeId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte?>("Empunhadura")
                        .IsRequired()
                        .HasColumnType("tinyint");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("JogaRanking")
                        .HasColumnType("bit");

                    b.Property<int>("MotivoBloqueioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte?>("Sexo")
                        .IsRequired()
                        .HasColumnType("tinyint");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte?>("TipoTenista")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Tenistas");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TennisRanking.Models.Jogo", b =>
                {
                    b.HasOne("TennisRanking.Models.Agenda", "Agenda")
                        .WithMany()
                        .HasForeignKey("AgendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TennisRanking.Models.RankingTenistas", b =>
                {
                    b.HasOne("TennisRanking.Models.Tenista", "Tenista")
                        .WithMany()
                        .HasForeignKey("TenistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
