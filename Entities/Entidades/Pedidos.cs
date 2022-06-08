using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    public class Pedidos
    {
        public string Pedido { get; set; }
        public string chave_NFE { get; set; }
        public string numeroNF { get; set; }
        public string serieNFE { get; set; }
        public string tpNF { get; set; }
        public string cod_Mun { get; set; }
        public string dataNF { get; set; }
        public string data_Inclusao { get; set; }
        public string Documento { get; set; }
        public string remetenteCNPJ { get; set; }
        public string remetenteIE { get; set; }
        public string remetenteRazaoSocial { get; set; }
        public string remetenteEndereco { get; set; }
        public string remetenteNumero { get; set; }
        public string remetenteBairro { get; set; }
        public string remetenteMunicipio { get; set; }
        public string remetenteCEP { get; set; }
        public string remetenteUF { get; set; }
        public string destinatarioIE { get; set; }
        public string destinatarioCPF { get; set; }
        public string destinatarioCNPJ { get; set; }
        public string destinatarioRazaoSocial { get; set; }
        public string destinatarioEndereco { get; set; }
        public string destinatarioBairro { get; set; }
        public string destinatarioMunicipioID { get; set; }
        public string destinatarioMunicipio { get; set; }
        public string destinatarioCEP { get; set; }
        public string destinatarioUF { get; set; }
        public string InformacaoAdicional { get; set; }
        public string valor { get; set; }
        public string volume { get; set; }
        public string peso { get; set; }

    }
}
