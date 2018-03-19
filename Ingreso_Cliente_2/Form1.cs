using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ingreso_Cliente_2
{
    public partial class Form1 : Form
    {
        private List<Cliente> lc = new List<Cliente>();

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtRut.Text == "")
            {
                errorProvider1.SetError(txtRut, "Debe Ingresar Rut");
                txtRut.Focus();
                return;

            }
            if (txtNombre.Text == "")
            {
                errorProvider1.SetError(txtNombre, "Debe Ingresar Nombre");
                txtNombre.Focus();
                return;

            }
            if (txtApellido.Text == "")
            {
                errorProvider1.SetError(txtApellido, "Debe Ingresar Apellido");
                txtApellido.Focus();
                return;

            }
            if (comboSexo.Text == "")
            {
                errorProvider1.SetError(comboSexo, "Debe Ingresar sexo");
                comboSexo.Focus();
                return;

            }
            if (comboEstado.Text == "")
            {
                errorProvider1.SetError(comboEstado, "Debe Ingresar Estado Civil");
                comboEstado.Focus();
                return;
            }
            Cliente cliente = new Cliente();
            cliente.Rut = txtRut.Text;
            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.F_nacimiento = comboDate.Value;
            cliente.S = (Cliente.Sexo)this.comboSexo.SelectedIndex;
            cliente.E = (Cliente.EstadoCivil)this.comboEstado.SelectedIndex;
            lc.Add(cliente);
            tabla.DataSource = null;
            tabla.DataSource = lc;



        }




    }
}

