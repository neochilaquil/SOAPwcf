using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacagroup.Comercial.Creditos.Dominio;

namespace Pacagroup.Comercial.Creditos.ContratoRepositorio
{
   public interface ICreditoRepositorio
   {
        IEnumerable<Credito> ListarCredito();
        Credito RegistrarCredito(Credito credito);
        Credito ActualizarCredito(Credito credito);
        bool EliminarCredito(string idCredito);
    }
}
