using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceProcess;
using Pacagroup.Comercial.Creditos.Contrato; //No lo utilizamos
using Pacagroup.Comercial.Creditos.Implementacion;
namespace Pacagroup.Comercial.Creditos.InstaladorWinService
{
    //Esta se creó como una clase 'cualquiera', solo que se ha heredado de ServiceBase
    public class WCFClienteWindowsService : ServiceBase
    {
        //Constructor para asignar el nombre de nuestro sericio
        private WCFClienteWindowsService()
        {
            ServiceName = "WCFServicioCliente";
        }

        public static void Main()
        {
            ServiceBase.Run(new WCFClienteWindowsService());
        }

        //Las variables de tipo ServiceHost nos permite exponer el servicio para que los clientes puedan
        //consumir 
        private ServiceHost _serviceHost = null;

        /*
         Ahora camiaremos los procedimientos de los comportamientos onStart y onStop de un servicio de Windows
             */
        protected override void OnStart(string[] args)
        {
            //si es diferente a null cerramos el objeto
            _serviceHost?.Close();
            //Cuando se solicite un tipo, indicamos que será de tipo ClienteService
            _serviceHost = new ServiceHost(typeof(ClienteService));
            //Abrimos para que neustro servicio pueda ser consumido por os clientes
            _serviceHost.Open();
        }

        protected override void OnStop()
        { //Procedemos a cerrar si el objeto viene null y cerramos para que no ae pueda consumir el servicio
            if (_serviceHost == null) return;
            _serviceHost.Close();
            _serviceHost = null;

        }





    }
}
