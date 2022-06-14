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
                LogErro(0, Ex.Message);
            }

            return retorno;
        }
        public bool LogErro(int sucesso, string erro)
        {
            var data = DateTime.Now.ToString("yyyy-dd-MM HH:mm:ss");
            string sqlQuery = $@"Insert into LogIntegracao (sucesso,data,obs) values({sucesso},'{data}','{erro}');";
            var retorno = ExecutaComando(sqlQuery);
            return retorno;
        }
        public bool BuscaPedido(Pedidos ped)
        {
            var retorno = false;
       
            try
            {
                string query = $@"select top 1 * from PEDIDO where chave_nfe='{ped.chave_NFE}' and documento ='{ped.Documento}'";
                retorno = ExecutaComando(query);
            }
            catch (Exception Ex)
            {
                LogErro( 0, Ex.Message);
            }
            return retorno;
        }
        public bool GravaLog(Logintegracoes log)
        {
            var retorno = false;
            string sqlQuery = "";
            try
            {
                sqlQuery = $@"Insert into LogIntegracao (documento,pedido,sucesso,data,arquivo) 
                Values('{log.documento}','{log.pedido}', '{log.sucesso}','{log.data}','{log.arquivo}');";
                retorno = ExecutaComando(sqlQuery);
            }
            catch (Exception Ex)
            {

                LogErro(0, Ex.Message);
            }

            return retorno;
        }
        public bool InsertPedido(Pedidos ped)
        {
            var retorno = false;
            string sqlQuery = "";
            var data = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                sqlQuery = $@"Insert into pedido 
                Values('{ped.chave_NFE}',
                       '{ped.numeroNF}',
                       '{ped.serieNFE}',
                       '{ped.tpNF}',
                       '{ped.cod_Mun}',
                       '{ped.dataNF}',
                       '{data}',
                       '{ped.dataNF}',
                       '{ped.Documento}',
                       '{ped.remetenteCNPJ}',
                       '{ped.remetenteIE}',
                       '{ped.remetenteRazaoSocial}',
                       '{ped.remetenteNumero}',
                       '{ped.remetenteBairro}',
                       '{ped.remetenteMunicipio}',
                       '{ped.remetenteCEP}',
                       '{ped.remetenteUF}',
                       '{ped.destinatarioIE}',
                       '{ped.destinatarioCNPJ}',
                       '{ped.destinatarioRazaoSocial}',
                       '{ped.destinatarioEndereco}',
                       '{ped.destinatarioMunicipio}',
                       '{ped.destinatarioMunicipioID}',
                       '{ped.destinatarioCEP}',
                       '{ped.destinatarioUF}',
                       '{ped.InformacaoAdicional}',
                       '{ped.valor}',
                       '{ped.volume}',
                       '{ped.peso}',
                       '{ped.destinatarioBairro}');";
                retorno = ExecutaComando(sqlQuery);
            }
            catch (Exception Ex)
            {
                LogErro(0, Ex.Message);
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
                LogErro(0, Ex.Message);
            }
            return r;
        }

    }
}
