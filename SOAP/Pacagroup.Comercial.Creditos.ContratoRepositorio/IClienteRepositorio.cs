using Pacagroup.Comercial.Creditos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacagroup.Comercial.Creditos.ContratoRepositorio
{
   public interface IClienteRepositorio
    {
        //Esta solo es una interfaz dentro del patrón o repositorio, por lo tanto no se colocan de la siguiente manera:
        Cliente ObtenerCliente(string numeroDocumento);


        IEnumerable<Cliente> ListarCliente();
        
    }
}
