using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dados
{
    public class Setting
    {
        public static string ConnectionStringDefault { get; set; }
        public static string ConnectionStringImage { get; set; }
        public static string TipoIntegracao { get; set; }
        public static int DelayService { get; set; }
    }
}
