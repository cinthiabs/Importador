using Entities.Entidades;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dados
{
    public class Querys:Conexao,IQuerys
    {
        public List<Entities.Entidades.Dados> Dados()
        {
            var retorno = new List<Entities.Entidades.Dados>();
            var Data = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                string sqlQuery = $@"select * from dados WITH(NOLOCK) where integracao = '{Setting.TipoIntegracao}' and ativo = 1;";
                retorno = ExecutaSelectLista<Entities.Entidades.Dados>(sqlQuery);
            }
            catch (Exception Ex)
            {
                LogErro(0,"Infrastructure - DadosIntegracoes", Ex.Message,"",0);
            }

            return retorno;
        }
        public bool LogErro(int clienteID, string metodo, string erro, string observacao, int idImportacao)
        {
            var data = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string sqlQuery = $@"Insert into logerrointegracoes values('{data}',{clienteID},'{Setting.TipoIntegracao}', '{metodo}','{erro}',{observacao},{idImportacao});";
            var retorno = ExecutaComando(sqlQuery);
            return retorno;
        }
        //public List<Pedidos> BuscaArquivos(Entities.Entidades.Dados config)
        //{
        //    var retorno = new List<Pedidos>();
        //    string query = "";
        //    try
        //    {
        //        query = $@"{config.Informacaoadicional5 } {int.Parse(config.Clienteid)} ,'{Setting.TipoIntegracao}'";
        //        retorno = ExecutaSelectLista<Pedidos>(query);
        //    }
        //    catch (Exception Ex)
        //    {
        //      //  LogErro(int.Parse(config.Clienteid), "Infrastructure - BuscaPedidos", Ex.Message, query, int.Parse(config.IdImportacao));
        //    }
        //    return retorno;
        //}
        public bool GravaLog(Log log)
        {
            var retorno = false;
            string sqlQuery = "";
            try
            {
                var data = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                sqlQuery = $@"Insert into logStatusWS (nrt,status,xml,retorno,data,sucesso,clienteid,chaveNF,nf,serieNF,Documento,aplicacao,CodigoMensagem,Doc_envio) 
                Values({log.nrt},'{log.xml}', '{log.retorno}','{data}',{log.sucesso},{log.clienteid},'{log.chavenf}','{log.nf}','{log.Documento}','{log.aplicacao}','{log.CodigoMensagem}','{log.Doc_envio}');";
                retorno = ExecutaComando(sqlQuery);
            }
            catch (Exception Ex)
            {
                LogErro(log.clienteid, "Infrastructure - GravaLog", Ex.Message, sqlQuery, 0);
            }

            return retorno;
        }
        public bool AtualizaHorarioIntegracao(Entities.Entidades.Dados config)
        {
            var DataProxima = DateTime.Now.AddMinutes(int.Parse(config.Integracao)).ToString("yyyy-MM-dd HH:mm:ss");
            var DataUltima = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            bool r = false;
            try
            {
                var sqlQuery = $@"update Dados set ProximaExecucao = '{DataProxima}', UltimaExecucao ='{DataUltima}' where idimportacao = {config.id};";
                r = ExecutaComando(sqlQuery);
            }
            catch (Exception Ex)
            {
                //LogErro(int.Parse(config.Clienteid), "Infrastructure - AtualizaHorarioIntegracao", Ex.Message, "", int.Parse(config.id));
            }
            return r;
        }

    }
}
