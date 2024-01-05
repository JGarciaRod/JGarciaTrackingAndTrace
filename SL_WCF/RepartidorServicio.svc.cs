using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "RepartidorServicio" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione RepartidorServicio.svc o RepartidorServicio.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class RepartidorServicio : IRepartidorServicio
    {
        public Result Add(ML.Repartidor repartidor)
        {
            bool result = BL.Repartidor.Add(repartidor);

            return new Result
            {
                Correct = result
            };
        }

        public Result Delete(int idRepartidor)
        {
            bool result = BL.Repartidor.Delete(idRepartidor);

            return new Result
            {
                Correct = result
            };
        }

        public Result Update(ML.Repartidor repartidor)
        {
            bool result = BL.Repartidor.Update(repartidor);

            return new Result
            {
                Correct = result
            };
        }

        public Result GetAll()
        {
            var list = new List<object>();

            list = BL.Repartidor.GetAll();

            if (list != null)
            {
                return new Result
                {
                    Correct = true,
                    Objects = list
                };
            }
            else
            {
                return new Result
                { 
                    Correct = false 
                };

            }
        }

        public Result GetById(int idRepartidor)
        {
            ML.Repartidor repartidor = BL.Repartidor.GetById(idRepartidor);
            
            if(repartidor != null)
            {
                return new Result { 
                    Correct = true,
                    Object = repartidor
                };
            }
            else
            {
                return new Result { Correct = false };
            }
        }
    }
}
