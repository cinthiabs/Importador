using _3_Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Business.Interface
{
    interface IService
    {
        public void ExecutaServico();
        public List<Dados>ConsultaDados();
        public string BuscaArquivos(Dados dados);  
    }
}
