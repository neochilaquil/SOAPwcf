using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration.Install;
using System.ServiceProcess;
using System.ComponentModel;

namespace Pacagroup.Comercial.Creditos.InstaladorWinService
{ //Esta clase es para desplegar nuestro servicio, dentro de la consola de administración de servicios de Windows
    //Para ello es la referencia de System.ConfigurationInstaller

    [RunInstaller(true)]/*-> Quí indicamos que nuestra clase puede ser instalada utilizando la herramienta de
    Visual Studio o la misma ventana de comandos del S.O. de Windows para instalar el servicio dentro de 
    su consola de servicios, sin este atributo no podrémos instalar*/
    public class ProjectInstaller: Installer
    {
        public ProjectInstaller()
        {
            var process = new ServiceProcessInstaller();
            //Con que cuenta se ejecutará neustro servicio, la cual se puede cambiar
            process.Account = ServiceAccount.LocalSystem;

            var service = new ServiceInstaller();
            service.ServiceName = "WCFServicioCliente";

            //Agregamos neustros procesos y servicios con ayuda del objeto Installers
            Installers.Add(process);
            Installers.Add(service);

        }
      


    }
}
