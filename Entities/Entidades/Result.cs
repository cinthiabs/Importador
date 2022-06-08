using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    public class Result
    {
        public string ChaveNFe { get; set; }
        public int NumeroNFe { get; set; }
        public string SerieNFe { get; set; }
        public string NumeroPreNota { get; set; }
        public string SeriePreNota { get; set; }
        public string CnpjEmissor { get; set; }
        public string OcorrenciaTransportadora { get; set; }
        public string OcorrenciaEmpresa { get; set; }
        public string Mensagem { get; set; }
        public DateTime Data { get; set; }
        public DateTime Prazo { get; set; }
        public string Rastreio { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int PedidoId { get; set; }
        public int ClienteId { get; set; }
        public string cnpjEmissorCTE { get; set; }
        public string Ocorrencia { get; set; }
        public string cnpjSequoia { get; set; }
        public string DescOcorCli { get; set; }
        public string DescOcorSeq { get; set; }


    }
}
