using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TennisRanking.Models
{
    public class RegrasGerais
    {
        [Key, Required]
        public int Id { get; set; }
        public byte PosicoesAcima { get; set; }
        public byte MaximoDiasEntreDesafios { get; set; }
        public byte MinimoDiasEntreDesafios { get; set; }
        public byte MinimoDiasParaRevanche { get; set; }
        public byte MaximoRecusas { get; set; }
        public byte MultaWO { get; set; }
        public byte PrazoMinutosCancelamentoSemMulta { get; set; }
        public byte PrazoMinutosReagendamentoSemWO { get; set; }
        public byte PrazoHorasRespostaDesafio { get; set; }
        public bool JogosNoAd { get; set; }
        public byte NumeroJogadoresTorneioFinalsMasculino { get; set; }
        public byte NumeroJogadoresTorneioFinalsFeminino { get; set; }
        public byte ToleranciaMinutosWO { get; set; }
        public byte AquecimentoMinutos { get; set; }
        public byte AntecedenciaMaximaDias { get; set; }

    }
}
