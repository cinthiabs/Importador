using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IQuerys
    {
        public List<Entities.Entidades.Dados> Dados();
        public bool InsertPedido(Pedidos ped);
        public bool GravaLog(Logintegracoes log);
        public bool AtualizaHorarioIntegracao(Entities.Entidades.Dados config);
        public bool BuscaPedido(Pedidos ped);
        public bool LogErro(int id, int sucesso, string erro);


    }
}
