using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacagroup.Comercial.Creditos.Dominio;
using System.ServiceModel.Web; //Rest
using System.ServiceModel;
using System.ComponentModel; //Esta nos permitirá agregar el tag Descriptiona nuestras operaciones

namespace Pacagroup.Comercial.Creditos.Contrato
{
    //En esta clase probaremos los verbos que utiliza REST
    [ServiceContract]
   public interface ICreditoService
   {
        [OperationContract]
        [Description("Servicio REST que lista toda la información de los creditos")]
        [WebGet (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/ListarCredito", BodyStyle = WebMessageBodyStyle.Bare)]
        IEnumerable<Credito> ListarCredito();

        //Como esto es una operación, ahora utilizaremos WebInvoke
   //En los casos de POST y PUT no se especifican los parametros en la URL porque la clase Credito es una entidad, es decir, un tipo complejo
        [OperationContract]
        [Description("Servicio REST que registra creditos")]
        [WebInvoke (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "/RegistrarCredito", BodyStyle = WebMessageBodyStyle.Bare)]
        Credito RegistrarCredito(Credito credito);

        [OperationContract]
        [Description("Servicio REST que actualiza creditos")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "PUT", UriTemplate = "/ActualizarCredito", BodyStyle = WebMessageBodyStyle.Bare)]
        Credito ActualizarCredito(Credito credito);

        [OperationContract]
        [Description("Servicio REST que elimina creditos")]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "DELETE", UriTemplate = "/EliminarCredito/{idCredito}", BodyStyle = WebMessageBodyStyle.Bare)]
        //En REST los parametros siemple tienen que ser de tipo string
        bool EliminarCredito(string idCredito);

   }
}
