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
                                ProcessaArquivo(item, arquivo[c]);
                            }


                        }
                        _Query.AtualizaHorarioIntegracao(item);
                    }
                }
            }
            catch (Exception Ex)
            {
                //  _Query.LogErro(0,"Business - Executa", Ex.Message, "", 0);
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
                //  _Query.LogErro(0, "Business - ConsultaDadosIntegracoes", Ex.Message, "", 0);
            }

            return consulta;
        }
        public string[] BuscaArquivos(string file)
        {
            string[] arquivos = Directory.GetFiles(file);

            return arquivos;
        }
        public void ProcessaArquivo(Dados config, string arquivos)
        {
            try
            {
                Pedidos ped = new Pedidos();
                XmlDocument doc = new XmlDocument();
                doc.Load(arquivos);

                XmlNodeList ide = doc.GetElementsByTagName("ide");
                for(int i = 0; i< ide.Count; i++)
                {
                    ped.serieNFE  = ide[i]["serie"].InnerText;
                    ped.numeroNF =  ide[i]["nNF"].InnerText;
                    ped.dataNF =    ide[i]["dhEmi"].InnerText;
              //      ped.chave_NFE = ide[i]["refNFe"].InnerText;
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
                    ped.remetenteNumero = enderEmit[i]["nro"].InnerText;
                    ped.remetenteBairro = enderEmit[i]["xBairro"].InnerText;
                    ped.remetenteMunicipio = enderEmit[i]["xMun"].InnerText;
                    ped.remetenteUF = enderEmit[i]["UF"].InnerText;
                    ped.remetenteCEP = enderEmit[i]["CEP"].InnerText;
                }

                XmlNodeList dest = doc.GetElementsByTagName("dest");
                for (int i = 0; i < dest.Count; i++)
                {
                    ped.destinatarioCNPJ = dest[i]["CPF"].InnerText;
                    ped.destinatarioRazaoSocial = dest[i]["xNome"].InnerText;
                    ped.remetenteMunicipio = dest[i]["xMun"].InnerText;
                    ped.remetenteUF = dest[i]["UF"].InnerText;
                    ped.remetenteCEP = dest[i]["CEP"].InnerText;
                }


                //  string TagName = "";
                //  Pedidos ped = new Pedidos();
                //
                //  XmlTextReader xmlReader = new XmlTextReader(arquivos);
                //  while (xmlReader.Read())
                //  {
                //      if (xmlReader.LocalName != "")
                //      {
                //          TagName = xmlReader.LocalName;
                //      }
                //       
                //      else
                //          {
                //              if (TagName == "serie")
                //              {
                //                  ped.serieNFE = xmlReader.Value;
                //              }
                //              else if (TagName == "nNF")
                //              {
                //                  ped.numeroNF = xmlReader.Value;
                //              }
                //              else if (TagName == "dhEmi")
                //              {
                //                  ped.dataNF = xmlReader.Value;
                //              }
                //              else if (TagName == "refNFe")
                //              {
                //                  ped.chave_NFE = xmlReader.Value;
                //              }
                //        
                //
                //        
                //               else if (TagName == "CNPJ")
                //              {
                //                  ped.remetenteCNPJ = xmlReader.Value;
                //              }
                //              else if (TagName == "xNome")
                //              {
                //                  ped.remetenteRazaoSocial = xmlReader.Value;
                //              }
                //              else if (TagName == "xLgr")
                //              {
                //                  ped.remetenteEndereco = xmlReader.Value;
                //              }
                //              else if (TagName == "nro")
                //              {
                //                  ped.remetenteNumero = xmlReader.Value;
                //              }
                //              else if (TagName == "xBairro")
                //              {
                //                  ped.remetenteBairro = xmlReader.Value;
                //              }
                //              else if (TagName == "xMun")
                //              {
                //                  ped.remetenteMunicipio = xmlReader.Value;
                //              }
                //              else if (TagName == "UF")
                //              {
                //                  ped.remetenteNumero = xmlReader.Value;
                //              }
                //              else if (TagName == "nro")
                //              {
                //                  ped.remetenteNumero = xmlReader.Value;
                //              }
                //              else if (TagName == "nro")
                //              {
                //                  ped.remetenteNumero = xmlReader.Value;
                //              }
                //              else if (TagName == "nro")
                //              {
                //                  ped.remetenteNumero = xmlReader.Value;
                //              }
                //              else if (TagName == "nro")
                //              {
                //                  ped.remetenteNumero = xmlReader.Value;
                //              }
                //          }
                //        
                //      
                //
                //  }
                //
            }
            catch (Exception Ex)
            {
                //_Query.LogErro(int.Parse(config.Clienteid), "Business - ExportaIMG", Ex.Message, "Foreach de exportação de imagem", int.Parse(config.IdImportacao));
            }

        }

        public bool GravaLog(Log log)
        {
            var retorno = _Query.GravaLog(log);
            return retorno;
        }



    }
}
