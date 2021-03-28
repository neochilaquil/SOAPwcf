using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacagroup.Comercial.Creditos.Dominio;
using System.ServiceModel;
using System.ServiceModel.Web; //Esta referencia para REST

namespace Pacagroup.Comercial.Creditos.Contrato
{
    [ServiceContract]
  public interface IClienteService
    {
        //Para que nuestras operaciones sean accesibles y visibles por los clientes necesitamos [OperationContract]
        //WebGet es para REST con toda y su configuración
        [OperationContract]
        [WebGet (RequestFormat = WebMessageFormat.Json, ResponseFormat =WebMessageFormat.Json, UriTemplate = "/ObtenerCliente/{numeroDocumento}", BodyStyle =WebMessageBodyStyle.Bare)]
        [FaultContract(typeof(Error))]
        Cliente ObtenerCliente(string numeroDocumento);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ListarCliente", BodyStyle = WebMessageBodyStyle.Bare)]

        IEnumerable<Cliente> ListarCliente();

    }
}
