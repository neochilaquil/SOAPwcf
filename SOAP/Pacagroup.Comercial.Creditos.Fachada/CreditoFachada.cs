using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacagroup.Comercial.Creditos.ContratoRepositorio;
using Pacagroup.Comercial.Creditos.SqlRepositorio;
using Pacagroup.Comercial.Creditos.Dominio;



namespace Pacagroup.Comercial.Creditos.Fachada
{
    public class CreditoFachada : IDisposable
    {
       
        public IEnumerable<Credito> ListarCredito()
        {
            ICreditoRepositorio instancia = new CreditoRepositorio();
            return instancia.ListarCredito();

        }
        public Credito RegistrarCredito(Credito credito)
        {
            ICreditoRepositorio instancia = new CreditoRepositorio();
            return instancia.RegistrarCredito(credito);

        }
        public Credito ActualizarCredito(Credito credito)
        {
            ICreditoRepositorio instancia = new CreditoRepositorio();
            return instancia.ActualizarCredito(credito);
        }
        public bool EliminarCredito(string idCredito)
        {
            ICreditoRepositorio instancia = new CreditoRepositorio();
            return instancia.EliminarCredito(idCredito);
        }

        //Este metodo se agrega al heredar IDisposable y elegir la opciond e agregar el metodo de manera explicito
        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
}
