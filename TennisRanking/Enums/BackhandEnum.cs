using System.ComponentModel.DataAnnotations;

namespace TennisRanking
{
    public enum Backhand
    {
        [Display(Name = "Com uma mão")] Simples = 1,
        [Display(Name = "Com duas mãos")] Duplo = 2
    }
}