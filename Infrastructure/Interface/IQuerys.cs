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
      //  public List<Pedidos> BuscaArquivos(Entities.Entidades.Dados config);
        public bool GravaLog(Log log);
        public bool AtualizaHorarioIntegracao(Entities.Entidades.Dados config);
       
    }
}
