using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class UnidadEntrega
    {
        public int IdUnidad { get; set; }
        public string NumeroPlaca { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Fabricacion { get; set; }
        public ML.EstatusUnidad Estatus { get; set; }

        public List<object> Unidades { get; set; }

    }
}
