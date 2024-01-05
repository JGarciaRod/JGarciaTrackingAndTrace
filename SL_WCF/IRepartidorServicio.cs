using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IRepartidorServicio" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IRepartidorServicio
    {
        [OperationContract]
        Result Add(ML.Repartidor repartidor);


        [OperationContract]
        Result Delete(int idRepartidor);


        [OperationContract]
        Result Update(ML.Repartidor repartidor);


        [OperationContract]
        [ServiceKnownType(typeof(ML.Repartidor))]
        Result GetAll();


        [OperationContract]
        [ServiceKnownType(typeof(ML.Repartidor))]
        Result GetById(int id);

    }
}
