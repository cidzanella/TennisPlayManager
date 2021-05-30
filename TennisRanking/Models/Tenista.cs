using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TennisRanking.Services;

namespace TennisRanking.Models
{
    public class Tenista
    {
        private string _nome;
        private string _sobrenome;
        private string _apelido;

        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Informe o primeiro nome.")]
        [MaxLength(50)]
        public string Nome
        {
            get { return _nome; }
            set { _nome = FirstLetterUpper(value); }
        }

        [Required(ErrorMessage = "Informe o sobrenome.")]
        public string Sobrenome
        {
            get { return _sobrenome; }
            set { _sobrenome = value.ToUpper(); }
        }
        
        [Display(Name = "Apelido (opcional)")]
        public string? Apelido 
        {
            get { return _apelido; }
            set { _apelido = FirstLetterUpper(value); }
        }

        [DOBDateValidation]
        [Required(ErrorMessage = "Informe a data de nascimento.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Nascimento (dd/mm/aaaa)")]
        public DateTime Nascimento { get; set; }

        [Required(ErrorMessage = "Informe o sexo para designação do ranking.")]
        public byte? Sexo { get; set; }

        [Range(100, byte.MaxValue, ErrorMessage = "Informe a altura em centímetros, sem vírgula ou ponto - Ex: para 1.80m informe 180")]
        [Display(Name ="Altura (cm)")]
        public byte AlturaCm { get; set; }

        [Required(ErrorMessage = "Informe sua empunhadura, se você é destro ou canhoto.")]
        public byte? Empunhadura { get; set; }

        [Required(ErrorMessage = "Informe se você joga com backhand de uma ou duas mãos.")]
        public byte? Backhand { get; set; }
        
        [Display(Name = "Foto do Perfil")]
        public string? Foto{ get; set; }
        
        [Required(ErrorMessage = "Informe o número do celular com dois dígitos do DDD e nove digitos do telefone - Ex: 45988776655")]
        [Display(Name = "Celular (DDD + 9 digitos)")]
        [StringLength(11, ErrorMessage = "O campo Celular deve conter dois dígitos do DDD e nove digitos do telefone - Ex: 45988776655", MinimumLength = 11)]
        [Phone]
        public string Celular { get; set; }

        [Required(ErrorMessage = "O email deve ser informado.", AllowEmptyStrings = false)]
        public string Email { get; set; } 

        [Required(ErrorMessage = "Selecione sua cidade.")]
        [Display(Name = "Cidade")]
        public int? CidadeId { get; set; }

        [Display(Name = "Motivo do Bloqueio")]
        public int MotivoBloqueioId { get; set; }

        // [Required(ErrorMessage = "Selecione o tipo de participação no GTM.")]
        // [Display(Name = "Participação")]
        public byte? TipoTenista { get; set; } = 3; //tenista
        
        public bool JogaRanking { get; set; }

        public string Idade ()
        {
            DateTime now = DateTime.Today;
            int age = now.Year - Nascimento.Year;
            if (now < Nascimento.AddYears(age)) age--;

            return age.ToString();
        }

        private string FirstLetterUpper(string originalString)
        {
            string modifiedString = "";
            if (!String.IsNullOrWhiteSpace(originalString))
            {
                TextInfo textInfo = new CultureInfo("pr-BR", false).TextInfo;
                modifiedString = textInfo.ToTitleCase(originalString.ToLower()); 
            }
            return modifiedString;
        }

        public string DisplayNome
        {
            get
            {
                if (string.IsNullOrEmpty(Sobrenome) ||string.IsNullOrEmpty(Nome))
                        return "";

                //monta nome do tenista com apelido
                string nomeTenistaDisplay = $"{Sobrenome.Trim()}, {Nome.Trim()}";
                if (!String.IsNullOrWhiteSpace(Apelido))
                    nomeTenistaDisplay += $" '{Apelido.Trim()}'";
                return nomeTenistaDisplay;

            }
        }

        public string DisplayNomePlacar
        {
            get
            {
                if (string.IsNullOrEmpty(Sobrenome) || string.IsNullOrEmpty(Nome))
                    return "";

                //monta nome do tenista com apelido
                string nomeTenistaDisplay = $"{Sobrenome.Trim()}, {Nome.Trim().Substring(0, 1)}";
                if (!String.IsNullOrWhiteSpace(Apelido))
                    nomeTenistaDisplay += $" '{Apelido.Trim()}'";
                return nomeTenistaDisplay;

            }
        }

    }
}
