using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase3_Debate2.pry
{
    public partial class frmListadoClientes : Form
    {
        public frmListadoClientes()
        {
            InitializeComponent();
        }
        clsArchivo Archivo = new clsArchivo();
        private void btnListar_Click(object sender, EventArgs e)
        {
            Archivo.Listar(dgvClientes);
            // cargamos la funcion de cantidad de clientes y lo convertimos a string
            lblCantidadClientes.Text = Archivo.CantidadClientes().ToString();

            lblTotalDeuda.Text = Archivo.TotalDeuda().ToString();
            lblPromedioDeuda.Text = Archivo.PromedioDeuda().ToString();
        }

        private void btnListarDeudores_Click(object sender, EventArgs e)
        {
            Archivo.ListarDeudores(dgvClientes);

            lblCantidadClientes.Text = Archivo.CantidadClientesDeudores().ToString();
            lblTotalDeuda.Text = Archivo.TotalDeuda().ToString();
            lblPromedioDeuda.Text = Archivo.PromedioDeudaDeudores().ToString();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Archivo.GenerarReporte();
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            Archivo.OrdenarDatos();
            Archivo.Listar(dgvClientes);
        }
    }
}
