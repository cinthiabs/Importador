using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    public class Log
    {
        public Int64 nrt { get; set; }
        public string status { get; set; }
        public string xml { get; set; }
        public string retorno { get; set; }
        public DateTime data { get; set; }
        public int sucesso { get; set; }
        public int clienteid { get; set; }
        public string chavenf { get; set; }
        public string nf { get; set; }
        public string serienf { get; set; }
        public string Documento { get; set; }
        public string aplicacao { get; set; }
        public string CodigoMensagem { get; set; }
        public string Doc_envio { get; set; }
    }
}
