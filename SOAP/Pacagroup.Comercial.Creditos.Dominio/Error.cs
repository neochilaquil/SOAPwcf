using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Pacagroup.Comercial.Creditos.Dominio
{
    [DataContract]
     public class Error
     { //Realizaremos atributos que se van a intercambiar a trves del servicio, por ello colocamos [DataContract]
        [DataMember]
        public string CodigoError { get; set; }
        [DataMember]
        public string Mensaje { get; set; }

        [DataMember]
        public string Descripcion { get; set; }





    }




}
