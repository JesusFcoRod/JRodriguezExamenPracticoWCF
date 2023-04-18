using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILibroService" in both code and config file together.
    [ServiceContract]
    public interface ILibroService
    {
        [OperationContract]
        ML.Result Add(ML.Libro libro);
        [OperationContract]
        ML.Result Update(ML.Libro libro);

        [OperationContract]
        ML.Result Delete(int IdLibro);


        [OperationContract]
        [ServiceKnownType(typeof(ML.Libro))]
        ML.Result GetAll();

        [OperationContract]
        [ServiceKnownType(typeof(ML.Libro))]
        ML.Result GetById(int IdLibro);
    }
}
