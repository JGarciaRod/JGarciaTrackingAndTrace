using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Entrega
    {
        public static ML.Entrega GetBy(string codigoRastreo)
        {
            ML.Entrega entrega = new ML.Entrega();
            try
            {
                using (DL.JGarciaTrakingAndTraceEntities context =  new DL.JGarciaTrakingAndTraceEntities())
                {
                    var query = context.SeguimientoPaquete(codigoRastreo).SingleOrDefault();

                    if (query != null)
                    {
                        entrega.IdEntrega = query.IdEntrega;
                        entrega.FechaEntrega = query.FechaEntrega.Value;

                        entrega.Paqute = new ML.Paquete();
                        entrega.Paqute.IdPaquete = query.IdPaquete;
                        entrega.Paqute.Detalle = query.Detalle;
                        entrega.Paqute.DireccionOrigen = query.DireccionOrigen;
                        entrega.Paqute.DireccionEntrega = query.DireccionEntrega;
                        entrega.Paqute.CodigoRastreo = query.CodigoRastreo;

                        entrega.Repartidor = new ML.Repartidor();
                        entrega.Repartidor.IdRepartidor = query.IdRepartidor;
                        entrega.Repartidor.Nombre = query.Nombre;
                        entrega.Repartidor.ApellidoPaterno = query.ApellidoPaterno;
                        entrega.Repartidor.ApellidoMaterno = query.ApellidoMaterno;

                        entrega.Repartidor.UnidadEntrega = new ML.UnidadEntrega();
                        entrega.Repartidor.UnidadEntrega.IdUnidad = query.IdUnidadAsignada.Value;
                        entrega.Repartidor.UnidadEntrega.NumeroPlaca = query.NumeroPlaca;

                        entrega.Estatus = new ML.EstatusEntrega();
                        entrega.Estatus.IdEstatus = query.IdEstatusEntrega.Value;
                        entrega.Estatus.Estatus = query.Estatus;

                    }
                }
            }
            catch
            {
                entrega = null;
            }
            return entrega;
        }
    }
}
