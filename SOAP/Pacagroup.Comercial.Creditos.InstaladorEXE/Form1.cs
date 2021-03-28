using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using Pacagroup.Comercial.Creditos.Contrato;
using Pacagroup.Comercial.Creditos.Implementacion;

namespace Pacagroup.Comercial.Creditos.InstaladorEXE
{
    public partial class frmServerWCF : Form
    {
        public frmServerWCF()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private ServiceHost _serviceHost = null;
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            //Si esta null lo cerramos y abrimos
            _serviceHost?.Close();
            _serviceHost = new ServiceHost(typeof(ClienteService));
            _serviceHost.Open();

        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            if (_serviceHost == null) return;

            _serviceHost.Close();
            _serviceHost = null;
        }
    }
}
