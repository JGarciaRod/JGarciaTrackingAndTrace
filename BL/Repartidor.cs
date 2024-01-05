using DL;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace BL
{
    public class Repartidor
    {
        public static bool Add(ML.Repartidor repartidor) //funciona
        {
            bool result = false;

            try
            {
                using (DL.JGarciaTrakingAndTraceEntities context = new DL.JGarciaTrakingAndTraceEntities())
                {
                    DL.Repartidor repartidor1 = new DL.Repartidor();
                    repartidor1.Nombre = repartidor.Nombre;
                    repartidor1.ApellidoPaterno = repartidor.ApellidoPaterno;
                    repartidor1.ApellidoMaterno = repartidor.ApellidoMaterno;
                    repartidor1.IdUnidadAsignada = repartidor.UnidadEntrega.IdUnidad;
                    repartidor1.Telefono = repartidor.Telefono;
                    repartidor1.FechaIngreso = repartidor.FechaIngreso;
                    repartidor1.Fotografia = repartidor.Fotografia;

                    context.Repartidors.Add(repartidor1);

                    int rowAffected = context.SaveChanges();
                    
                    if (rowAffected > 0)
                    {
                        result = true;
                    }
                    else
                    {
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

        public static bool Delete(int idRepartidor) //no lo probe pero si 4 funcionan 5 tambien
        {
            bool result = false;
            try
            {
                using (DL.JGarciaTrakingAndTraceEntities context = new DL.JGarciaTrakingAndTraceEntities())
                {
                    var query = (from a in context.Repartidors
                                 where a.IdRepartidor == idRepartidor
                                 select a).First();
                    context.Repartidors.Remove(query);
                    int rowAffected = context.SaveChanges();
                    if (rowAffected > 0)
                    {
                        result = true;
                    }
                    else
                    {
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

        public static bool Update(ML.Repartidor repartidor) //funciona
        {
            bool result = false;
            try
            {
                using (DL.JGarciaTrakingAndTraceEntities context = new DL.JGarciaTrakingAndTraceEntities())
                {
                    var query = (from a in context.Repartidors
                                 where a.IdRepartidor == repartidor.IdRepartidor
                                 select a).SingleOrDefault();
                    if (query != null)
                    {
                        query.Nombre = repartidor.Nombre;
                        query.ApellidoPaterno = repartidor.ApellidoPaterno;
                        query.ApellidoMaterno = repartidor.ApellidoMaterno;
                        query.IdUnidadAsignada = repartidor.UnidadEntrega.IdUnidad;
                        query.Telefono = repartidor.Telefono;
                        query.FechaIngreso = repartidor.FechaIngreso;
                        query.Fotografia = repartidor.Fotografia;

                        int rowAffected = context.SaveChanges();
                        if(rowAffected > 0)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static ML.Repartidor GetById(int IdRepartidor) //funciona
        {
            ML.Repartidor repartidor = new ML.Repartidor();
            try
            {
                using (DL.JGarciaTrakingAndTraceEntities context = new DL.JGarciaTrakingAndTraceEntities())
                {
                    var query = (from Repar in context.Repartidors
                                 join unidad in context.UnidadEntregas on Repar.IdUnidadAsignada equals unidad.IdUnidad
                                 join idRepar in context.Repartidors on Repar.IdRepartidor equals idRepar.IdRepartidor
                                 where Repar.IdRepartidor == IdRepartidor
                                 select new
                                 {
                                     Nombre = Repar.Nombre,
                                     ApellidoPaterno = Repar.ApellidoPaterno,
                                     ApellidoMaterno = Repar.ApellidoMaterno,
                                     IdUnidadAsignada = Repar.IdUnidadAsignada,
                                     NombreUnidad = unidad.Marca,
                                     Telefono = Repar.Telefono,
                                     FechaIngreso = Repar.FechaIngreso,
                                     Fotografia = Repar.Fotografia,
                                 }).SingleOrDefault();
                    if (query != null)
                    {
                        repartidor.Nombre = query.Nombre;
                        repartidor.ApellidoPaterno = query.ApellidoPaterno;
                        repartidor.ApellidoMaterno = query.ApellidoMaterno;
                        repartidor.UnidadEntrega = new ML.UnidadEntrega();
                        repartidor.UnidadEntrega.IdUnidad = query.IdUnidadAsignada.Value;
                        repartidor.UnidadEntrega.Marca = query.NombreUnidad;
                        repartidor.Telefono = query.Telefono;
                        repartidor.FechaIngreso = query.FechaIngreso.Value;
                        repartidor.Fotografia = query.Fotografia;
                    }
                }
            }
            catch
            {

            }
            return repartidor;
        }

        public static List<object> GetAll() //funciona
        {
            var list = new List<object>();
            try
            {
                using (DL.JGarciaTrakingAndTraceEntities context = new DL.JGarciaTrakingAndTraceEntities())
                {
                    var query = (from Repar in context.Repartidors
                                 join Unidad in context.UnidadEntregas on Repar.IdUnidadAsignada equals Unidad.IdUnidad
                                 select new
                                 {
                                     IdRepartidor = Repar.IdRepartidor,
                                     Nombre = Repar.Nombre,
                                     ApellidoPaterno = Repar.ApellidoPaterno,
                                     ApellidoMaterno = Repar.ApellidoMaterno,
                                     IdUnidadAsignada = Repar.IdUnidadAsignada,
                                     NombreUnidad = Unidad.NumeroPlaca,
                                     Telefono = Repar.Telefono,
                                     FechaIngreso = Repar.FechaIngreso,
                                     Fotografia = Repar.Fotografia,
                                 });
                    if (query != null)
                    {
                        foreach(var registro in query)
                        {
                            ML.Repartidor repartidor = new ML.Repartidor();
                            repartidor.IdRepartidor = registro.IdRepartidor;
                            repartidor.Nombre = registro.Nombre;
                            repartidor.ApellidoPaterno = registro.ApellidoPaterno;
                            repartidor.ApellidoMaterno = registro.ApellidoMaterno;
                            repartidor.UnidadEntrega = new ML.UnidadEntrega();
                            repartidor.UnidadEntrega.IdUnidad = registro.IdUnidadAsignada.Value;
                            repartidor.UnidadEntrega.NumeroPlaca = registro.NombreUnidad;
                            repartidor.Telefono = registro.Telefono;
                            repartidor.FechaIngreso = registro.FechaIngreso.Value;
                            repartidor.Fotografia = registro.Fotografia;

                            list.Add(repartidor);
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
