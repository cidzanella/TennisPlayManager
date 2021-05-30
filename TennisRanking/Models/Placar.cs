using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TennisRanking.Models
{
    public class Placar
    {
        [Key, Required]
        public int Id { get; set; }
        
        
        public byte Set1GamesTenistaA { get; set; }
        
        public byte Set1GamesTenistaB { get; set; }
        
        public byte Set1TieBreakTenistaA { get; set; }
        
        public byte Set1TieBreakTenistaB { get; set; }

        public byte Set2GamesTenistaA { get; set; }
        
        public byte Set2GamesTenistaB { get; set; }
        
        public byte Set2TieBreakTenistaA { get; set; }
        
        public byte Set2TieBreakTenistaB { get; set; }

        public byte Set3GamesTenistaA { get; set; }
        
        public byte Set3GamesTenistaB { get; set; }
        
        public byte Set3TieBreakTenistaA { get; set; }
        
        public byte Set3TieBreakTenistaB { get; set; }

    }
}
