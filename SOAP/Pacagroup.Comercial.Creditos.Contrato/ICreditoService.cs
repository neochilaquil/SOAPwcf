using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacagroup.Comercial.Creditos.Dominio;
using System.ServiceModel.Web; //Rest
using System.ServiceModel;

namespace Pacagroup.Comercial.Creditos.Contrato
{
    //En esta clase probaremos los verbos que utiliza REST
    [ServiceContract]
   public interface ICreditoService
   {
        [OperationContract]
        [WebGet (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ListarCredito", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Credito> ListarCredito();

        //Como esto es una operación, ahora utilizaremos WebInvoke
   //En los casos de POST y PUT no se especifican los parametros en la URL porque la clase Credito es una entidad, es decir, un tipo complejo
        [OperationContract]
        [WebInvoke (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "/RegistrarCredito", BodyStyle = WebMessageBodyStyle.Bare)]
        Credito RegistrarCredito(Credito credito);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "PUT", UriTemplate = "/ActualizarCredito", BodyStyle = WebMessageBodyStyle.Bare)]
        Credito ActualizarCredito(Credito credito);

        [OperationContract]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "DELETE", UriTemplate = "/EliminarCredito/{idCredito}", BodyStyle = WebMessageBodyStyle.Bare)]
        //En REST los parametros siemple tienen que ser de tipo string
        bool EliminarCredito(string idCredito);

   }
}
