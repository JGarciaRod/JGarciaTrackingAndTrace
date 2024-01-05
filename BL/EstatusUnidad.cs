using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EstatusUnidad
    {
        public static List<object> GetAllEstatusUnidad()
        {
            var list = new List<object>();
            try
            {
                using (DL.JGarciaTrakingAndTraceEntities context = new DL.JGarciaTrakingAndTraceEntities())
                {
                    var query = context.GetAllEstatusUnidad().ToList();

                    if (query!= null)
                    {
                        foreach (var item in query)
                        {
                            ML.EstatusUnidad estatus = new ML.EstatusUnidad();
                            estatus.IdEstatusUnidad = item.IdEstatus;
                            estatus.Estatus = item.Estatus;

                            list.Add(estatus);
                        }
                    }
                }
            }
            catch
            {
                list.Add(null);
            }
            return list;
        }

    }
}
