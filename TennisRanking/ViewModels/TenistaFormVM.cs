using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TennisRanking.Models;

namespace TennisRanking.ViewModels
{
    public class TenistaFormVM
    {
        public Tenista Tenista { get; set; }

        public IEnumerable<Cidade> Cidades { get; set; }

        [Display(Name = "Foto do Perfil")]
        public IFormFile ProfileImage { get; set; }

    }
}
