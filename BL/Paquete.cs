using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Paquete
    {

        public static List<object> GetAll()
        {
            List<object> list = new List<object>();

            try
            {
                using (DL.JGarciaTrakingAndTraceEntities context = new DL.JGarciaTrakingAndTraceEntities())
                {
                    var query = context.PaqueteGetAll().ToList();

                    if(query!=null)
                    {
                        foreach (var item in query)
                        {
                            ML.Paquete paquete =  new ML.Paquete();
                            paquete.IdPaquete = item.IdPaquete;
                            paquete.Detalle = item.Detalle;
                            paquete.Peso = float.Parse(item.Peso.ToString());
                            paquete.DireccionOrigen = item.DireccionOrigen;
                            paquete.DireccionEntrega = item.DireccionEntrega;
                            paquete.FechaEstimadaEntrega = item.FechaEstimadaEntrega.Value;
                            paquete.CodigoRastreo = item.CodigoRastreo;

                            list.Add(paquete);
                        }
                    }
                    else
                    {
                        list.Add(null);
                    }
                }
            }
            catch
            {

            }
            return list;
        }
        public static ML.Paquete GetById(int IdPaquete)
        {
            ML.Paquete paquete = new ML.Paquete();
            try
            {
                using (DL.JGarciaTrakingAndTraceEntities context = new DL.JGarciaTrakingAndTraceEntities())
                {
                    var query = context.PaqueteGetById(IdPaquete).SingleOrDefault();
                    
                    if (query != null)
                    {
                        paquete.IdPaquete = query.IdPaquete;
                        paquete.Detalle = query.Detalle;
                        paquete.Peso = float.Parse(query.Peso.ToString());
                        paquete.DireccionOrigen = query.DireccionOrigen;
                        paquete.DireccionEntrega = query.DireccionEntrega;
                        paquete.FechaEstimadaEntrega = query.FechaEstimadaEntrega.Value;
                        paquete.CodigoRastreo = query.CodigoRastreo;
                    }
                }
            }
            catch
            {
                paquete = null;
            }
            return paquete;
        }
        public static bool Add(ML.Paquete paquete)
        {
            bool result = new bool();
            try
            {
                using (DL.JGarciaTrakingAndTraceEntities context = new DL.JGarciaTrakingAndTraceEntities())
                {
                    int rowAffected = context.PaqueteAdd(
                        paquete.Detalle,
                        paquete.Peso,
                        paquete.DireccionOrigen,
                        paquete.DireccionEntrega
                        );

                    if (rowAffected > 0)
                    {
                        result = true;
                    }
                    else{
                        result = false;
                    }
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public static ML.Paquete Ultimoañadido()
        {
            ML.Paquete paquete = new ML.Paquete();
            try
            {
                using (DL.JGarciaTrakingAndTraceEntities context = new DL.JGarciaTrakingAndTraceEntities())
                {
                    var query = context.UltimoAñadido().SingleOrDefault();

                    if( query != null)
                    {
                        paquete.IdPaquete = query.IdPaquete;
                        paquete.CodigoRastreo = query.CodigoRastreo;
                    }
                }
            }
            catch (Exception e)
            {
                paquete = null;
            }
            return paquete;
        }

    }
}
