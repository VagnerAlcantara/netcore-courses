using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.API
{
    public class AppSettings
    {
        public string Secret { get; set; } // chave de cript
        public int ExpiracaoHoras { get; set; }//quanto tempo em horas pra perder a validade
        public string Emissor { get; set; }//quem emite (nesse caso uma aplicação)
        public string ValidoEm { get; set; }//em quais urls esse token é válido
    }
}
