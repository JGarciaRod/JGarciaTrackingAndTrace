using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static List<object> GetAll()
        {
            var list = new List<object>();
            try
            {
                using (DL.JGarciaTrakingAndTraceEntities context = new JGarciaTrakingAndTraceEntities())
                {
                    var query  = context.GetAllRol().ToList();

                    if(query != null)
                    {
                        foreach(var item in query)
                        {
                            ML.Rol rol = new ML.Rol();
                            rol.IdRol = item.IdRol;
                            rol.Tipo = item.Tipo;

                            list.Add(rol);
                        }
                    }
                }
            }
            catch
            {
                list = null;
            }
            return list;
        }
    }
}
