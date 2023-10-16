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
    public partial class frmCargaClientes : Form
    {
        public frmCargaClientes()
        {
            InitializeComponent();
        }

        clsArchivo Archivo = new clsArchivo();

        private void btnCargar_Click(object sender, EventArgs e)
        {
            Archivo.Grabar(txtCodigo.Text, txtNombre.Text, txtDeuda.Text, txtLimite.Text);
        }
    }
}
