using Pacagroup.Comercial.Creditos.Contrato;
using Pacagroup.Comercial.Creditos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacagroup.Comercial.Creditos.Fachada;

namespace Pacagroup.Comercial.Creditos.Implementacion
{
    public class CreditoService : ICreditoService
    {
       public Credito ActualizarCredito(Credito credito)
        {
            using (var instancia = new CreditoFachada())
            {
                return instancia.ActualizarCredito(credito);
            }
        }

      public  bool EliminarCredito(string idCredito)
        {
            using (var instancia = new CreditoFachada())
            {
                return instancia.EliminarCredito(idCredito);
            }
        }

       public IEnumerable<Credito> ListarCredito()
        {
          using(var instancia = new CreditoFachada())
          {
                return instancia.ListarCredito();
          }
        }

       public Credito RegistrarCredito(Credito credito)
        {
            using (var instancia = new CreditoFachada())
            {
                return instancia.RegistrarCredito(credito);
            }
        }
    }
}
