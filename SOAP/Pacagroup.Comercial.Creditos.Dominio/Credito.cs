using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Pacagroup.Comercial.Creditos.Dominio
{
    //Creamos contrato de datos:
    [DataContract]
    public class Credito
    {
        //También agregamos [DataMember] ya quue cada atributo es un tipo complejo y que pueda ser serializado
        [DataMember]
        public int IdCredito { get; set; }
        [DataMember]
        public int TipoCredito { get; set; }
        [DataMember]
        public int IdCliente { get; set; }
        [DataMember]
        public DateTime fecha { get; set; }
        [DataMember]
        public Decimal monto { get; set; }
        [DataMember]
        public DateTime DiaPago { get; set; }
        [DataMember]
        public Decimal tasa { get; set; }
        [DataMember]
        public Decimal Comision { get; set; }
    }
}
