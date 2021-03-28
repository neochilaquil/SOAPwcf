using Pacagroup.Comercial.Creditos.Dominio;
using Pacagroup.Comercial.Creditos.ContratoRepositorio;
using Pacagroup.Comercial.Creditos.SqlRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacagroup.Comercial.Creditos.Fachada
{
    public class ClienteFachada:IDisposable
    {

        public Cliente ObtenerCliente(string numeroDocumento)
        {
            IClienteRepositorio instancia = new ClienteRepositorio();
            return instancia.ObtenerCliente(numeroDocumento);
        }

        public IEnumerable<Cliente> ListarCliente()
        {
            IClienteRepositorio instancia = new ClienteRepositorio();
            return instancia.ListarCliente();
        }

        //Este metodo salío de las sugerencias de visual studio al escribir IDisposable
        //Y este metodo es para liberar nuestros recursos
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
