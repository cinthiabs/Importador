using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    public class RetornoEnvio
    {
            public Retorno retorno { get; set; }
     }

        public class Retorno
        {
            public string status_processamento { get; set; }
            public string status { get; set; }
            public string codigo_erro { get; set; }
            public Erro[] erros { get; set; }
        }

        public class Erro
        {
            public string erro { get; set; }
        }

    }

