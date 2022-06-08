using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    public class Logerrointegracoes
    {
        public DateTime Data { get; set; }
        public int ClienteID { get; set; }
        public string Aplicacao { get; set; }
        public string Metodo { get; set; }
        public string Erro { get; set; }
        public string Observacao { get; set; }
        public int IdImportacao { get; set; }
        public string Query { get; set; }
        public string Arquivo { get; set; }
    }
}
