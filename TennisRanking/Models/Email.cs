using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisRanking.Models
{
    public class Email
    {
        public string FromAdress { get; set; } = "ranking@gtmtennis.com.br";
        
        public string FromName { get; set; } = "Ranking GTM";
        
        public string ToAdress { get; set; }
        
        public string ToName { get; set; }
        
        public string Subject { get; set; }
        
        public string BodyPlainText { get; set; }

        public string BodyHtml { get; set; }

        public string Footer { get; set; } = "[ Não responda este email. Acesse o portal do Ranking GTM. ]";
    }
}
