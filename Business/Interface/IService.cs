﻿using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IService
    {
        public void Executa();
        public List<Dados> ConsultaDados();
        public string[] BuscaArquivos(string file);
        public bool GravaLog(Log log);
    }
}
