﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Entrega
    {
        public int IdEntrega { get; set; }
        public ML.Paquete Paqute { get; set; }
        public ML.Repartidor Repartidor { get; set; }
        public DateTime FechaEntrega { get; set; }
        public ML.EstatusEntrega Estatus { get; set; }

        public object Entregas { get; set; }
    }
}
