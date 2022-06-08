using Business.Interface;
using Infrastructure.Dados;
using Infrastructure.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Servico
{
    public class Worker : BackgroundService
    {
        private readonly IService _Service;
        public Worker(IService Service, IConfiguration Configuration)
        {
            Setting.ConnectionStringDefault = Configuration.GetConnectionString("DefaultConnection");
            Setting.TipoIntegracao          = Configuration.GetSection("Especiais").GetSection("TipoIntegracao").Value;
            Setting.DelayService            = int.Parse(Configuration.GetSection("Especiais").GetSection("DelayService").Value);
            _Service = Service;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //_Service.Executa();
                await Task.Run(() => _Service.Executa(), stoppingToken);
                await Task.Delay(Setting.DelayService, stoppingToken);
            }
        }
    }
}
