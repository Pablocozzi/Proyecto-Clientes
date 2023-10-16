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

    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void cargarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCargaClientes ventana = new frmCargaClientes();
            ventana.Show();
        }

        private void listarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListadoClientes ventana = new frmListadoClientes();
            ventana.Show();
        }
    }
}
