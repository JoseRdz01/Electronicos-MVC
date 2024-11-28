using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;



namespace Electronicos_MVC.Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IProductosService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IProductosService
    {
        [OperationContract]
        void DoWork();

    }
}
