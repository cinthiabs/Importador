using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    public class Dados
    {
        public string id { get; set; }
        public string Integracao { get; set; }
        public string webservice { get; set; }
        public string token { get; set; }
        public string diretorioEntrada { get; set; }
        public string diretorioSaida { get; set; }
        public string TabelaLog { get; set; }
        public string ativo { get; set; }
        public string informacao1 { get; set; }
        public string informacao2 { get; set; }
        public string informacao3 { get; set; }
        public string informacao4 { get; set; }
        public string Intervalo { get; set; }
        public string UltimaExecucao { get; set; }
        public string ProximaExecucao { get; set; }
        public string diretorioErro { get; set; }
    }
}
