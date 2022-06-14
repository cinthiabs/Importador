using Business.Interface;
using Entities.Entidades;
using Infrastructure.Interface;
using Newtonsoft.Json;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Business.Service
{
    public class Service : IService
    {
        private readonly IQuerys _Query;
        public Service(IQuerys Querys)
        {
            _Query = Querys;
        }
        public void Executa()
        {
            try
            {
                var config = ConsultaDados();
                if (config.Count > 0)
                {
                    foreach (var item in config)
                    {
                        var arquivo = BuscaArquivos(item.diretorioEntrada.ToString());
                        if (arquivo != null)
                        {
                            for (var c = 0; c < arquivo.Length; c++)
                            {
                               var pedido =  ProcessaArquivo(arquivo[c]);
                                bool retorno = ValidaPedido(pedido);
                                if(retorno == false)
                                {
                                    bool insert = InsertPedido(pedido);
                                    if(insert == true)
                                    {
                                        GravaLog(pedido, arquivo[c], 1);
                                        MoveArquivo(arquivo[c], item, 1);
                                    }
                                    else
                                    {
                                        GravaLog(pedido, arquivo[c], 0);
                                        MoveArquivo(arquivo[c], item, 0);

                                    }

                                }

                            }
                        }
                        _Query.AtualizaHorarioIntegracao(item);
                    }
                }
            }
            catch (Exception Ex)
            {
                _Query.LogErro(0, Ex.Message);
            }
        }
        public List<Dados> ConsultaDados()
        {
            var consulta = new List<Dados>();
            try
            {
                consulta = _Query.Dados();
            }
            catch (Exception Ex)
            {
                _Query.LogErro(0, Ex.Message);
            }

            return consulta;
        }
        public void MoveArquivo(string arquivo, Dados dados, int sucesso)
        {
            string dadosConfig = "";
            var filename = arquivo.Split('\\');
            string name = filename[filename.Length - 1];

            if (sucesso == 1)
            {
                dadosConfig = dados.diretorioSaida;
            }
            else
            {
                dadosConfig = dados.diretorioErro;
            }
           Directory.Move(dados.diretorioEntrada + name, dadosConfig + name);
        }

        public bool InsertPedido(Pedidos ped)
        {
            var retorno = _Query.InsertPedido(ped);
            return retorno;
        }
        public string[] BuscaArquivos(string file)
        {
            string[] arquivos = Directory.GetFiles(file);

            return arquivos;
        }
        public Pedidos ProcessaArquivo(string arquivos)
        {
           Pedidos ped = new Pedidos();
            try
            {
                XmlDocument doc = new XmlDocument();

                doc.Load(arquivos);

                XmlNodeList ide = doc.GetElementsByTagName("ide");
                for(int i = 0; i< ide.Count; i++)
                {
                    ped.serieNFE  = ide[i]["serie"].InnerText;
                    ped.numeroNF  = ide[i]["nNF"].InnerText;
                    ped.Documento = ide[i]["nNF"].InnerText;
                    ped.dataNF    = ide[i]["dhEmi"].InnerText;
                    ped.tpNF      = ide[i]["tpNF"].InnerText;
                    ped.cod_Mun   = ide[i]["cMunFG"].InnerText;
                }
                XmlNodeList emit = doc.GetElementsByTagName("emit");
                for (int i = 0; i < emit.Count; i++)
                {
                    ped.remetenteCNPJ = emit[i]["CNPJ"].InnerText;
                    ped.remetenteRazaoSocial = emit[i]["xNome"].InnerText;
                    ped.remetenteIE = emit[i]["IE"].InnerText;

                }
                XmlNodeList enderEmit = doc.GetElementsByTagName("enderEmit");
                for (int i = 0; i < enderEmit.Count; i++)
                {
                    ped.remetenteEndereco = enderEmit[i]["xLgr"].InnerText;
                    ped.remetenteNumero = enderEmit[i]["nro"].InnerText;
                    ped.remetenteBairro = enderEmit[i]["xBairro"].InnerText;
                    ped.remetenteMunicipio = enderEmit[i]["xMun"].InnerText;
                    ped.remetenteUF = enderEmit[i]["UF"].InnerText;
                    ped.remetenteCEP = enderEmit[i]["CEP"].InnerText;
                }

                XmlNodeList dest = doc.GetElementsByTagName("dest");
                for (int i = 0; i < dest.Count; i++)
                {
                    ped.destinatarioCPF = dest[i]["CPF"].InnerText;
                    ped.destinatarioRazaoSocial = dest[i]["xNome"].InnerText;
             
                }
                XmlNodeList enderDest = doc.GetElementsByTagName("enderDest");
                for (int i = 0; i < enderDest.Count; i++)
                {
                    ped.destinatarioEndereco = enderDest[i]["xLgr"].InnerText + " " +enderDest[i]["nro"].InnerText;
                    ped.destinatarioBairro = enderDest[i]["xBairro"].InnerText;
                    ped.destinatarioMunicipio = enderDest[i]["xMun"].InnerText;
                    ped.destinatarioUF = enderDest[i]["UF"].InnerText;
                    ped.destinatarioCEP = enderDest[i]["CEP"].InnerText;
                }
                XmlNodeList prod = doc.GetElementsByTagName("prod");
                for (int i = 0; i < prod.Count; i++)
                {
                    ped.InformacaoAdicional = prod[i]["xProd"].InnerText;

                }
                XmlNodeList ICMSTot = doc.GetElementsByTagName("ICMSTot");
                for (int i = 0; i < ICMSTot.Count; i++)
                {
                    ped.valor = ICMSTot[i]["vNF"].InnerText;

                }
                XmlNodeList vol = doc.GetElementsByTagName("vol");
                for (int i = 0; i < vol.Count; i++)
                {
                    ped.volume = vol[i]["qVol"].InnerText;
                    ped.peso = vol[i]["pesoB"].InnerText;
                }

                XmlNodeList infProt = doc.GetElementsByTagName("infProt");
                for (int i = 0; i < infProt.Count; i++)
                {
                    ped.chave_NFE = infProt[i]["chNFe"].InnerText; 
                }

            }
            catch (Exception Ex)
            {
                _Query.LogErro(0, Ex.Message);
            }
            return ped;
        }
        public bool ValidaPedido(Pedidos ped)
        {
            var retorno = _Query.BuscaPedido(ped);
            return retorno;
        }

        public bool GravaLog(Pedidos ped, string arquivo, int sucesso )
        {
            Logintegracoes log = new Logintegracoes();
            var data = DateTime.Now.ToString("yyyy-dd-MM HH:mm:ss");

            log.arquivo = arquivo;
            log.documento = ped.Documento;
            log.data = data;
            log.sucesso = sucesso.ToString();
            if(sucesso == 1)
            {
                log.obs = "Arquivo importado com sucesso";
            }
            else
            {
                log.obs = "Erro na importação";
            }
            var retorno = _Query.GravaLog(log);
            return retorno;
        }

    }
}
