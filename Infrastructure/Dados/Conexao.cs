using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Infrastructure.Dados
{
    public class Conexao
    {
        private readonly SqlConnection con = new();
        private readonly int timeOut = 0;
        public Conexao()
        {
            con.ConnectionString = Setting.ConnectionStringDefault;
        }
        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                if (String.IsNullOrEmpty(con.ConnectionString))
                {
                    con.ConnectionString = Setting.ConnectionStringDefault;
                }
                con.Open();
            }
            return con;
        }
      
        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
        protected List<T> ExecutaSelectLista<T>(string query)
        {
            using var connection = Conectar();
            return connection.Query<T>(query, commandTimeout: timeOut).AsList();
        }
        protected T ExecutaSelect<T>(string sqlQuery)
        {
            using var connection = Conectar();
            return connection.QueryFirstOrDefault<T>(sqlQuery, commandTimeout: timeOut);
        }
        protected bool ExecutaComando(string sqlQuery)
        {
            using var connection = Conectar();
            return connection.Execute(sqlQuery, commandTimeout: timeOut) > 0;
        }
        protected T EXECUTAPROC<T>(string sqlQuery)
        {
            using var connection = Conectar();
            return connection.QueryFirstOrDefault<T>(sqlQuery, commandTimeout: timeOut);
        }
     
    }
}
