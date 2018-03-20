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
                if (Repetido(txtRut.Text))
            {
                errorProvider1.SetError(txtRut, "Rut ya Existe");
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

            txtRut.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            comboSexo.SelectedIndex = 0;
            comboEstado.SelectedIndex = 0;
            txtRut.Focus();


        }

        private bool Repetido(string rut)
        {
            foreach(Cliente cli in lc)
            {
                if (cli.Rut == rut) return true;
            }
            return false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtRut.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            comboSexo.SelectedIndex = 0;
            comboEstado.SelectedIndex = 0;
            txtRut.Focus();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtRut.Text == "")
            {
                errorProvider1.SetError(txtRut, "Debe Ingresar Rut");
                txtRut.Focus();
                return;
            }
            Cliente cli = getCliente(txtRut.Text);
            if (cli == null)
            {
                errorProvider1.SetError(txtRut, "Rut no Existe");
                txtRut.Focus();
                return;
            }
            txtRut.Text = cli.Rut;
            txtNombre.Text = cli.Nombre;
            txtApellido.Text = cli.Apellido;
            comboDate.Value = cli.F_nacimiento;
            comboSexo.SelectedItem = cli.S;
            comboEstado.SelectedItem = cli.E;
            //lc.Add(cli);
            //tabla.DataSource = null;
            //tabla.DataSource = lc;


        }
        private Cliente getCliente(String rut)
        {
            foreach (Cliente cli in lc)
            {
                if (cli.Rut == rut)
                    return cli;
            }
            return null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            foreach (Cliente cli in lc)
            {
                if (cli.Rut == txtRut.Text)
                {
                    cli.Nombre = txtNombre.Text;
                    cli.Apellido = txtApellido.Text;
                    cli.F_nacimiento = comboDate.Value;
                    cli.S = (Cliente.Sexo)this.comboSexo.SelectedIndex;
                    cli.E = (Cliente.EstadoCivil)this.comboEstado.SelectedIndex;
                    break;
                }
            }
            tabla.DataSource = null;
            tabla.DataSource = lc;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult eli = MessageBox.Show(this, "Esta seguro de querer borrar al cliente", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (eli == DialogResult.No)
                return;

            Cliente cli = getCliente(txtRut.Text);
            if (cli == null)
            {
                errorProvider1.SetError(txtRut, "Rut no Existe");
                txtRut.Focus();
                return;
            }
            foreach (Cliente client in lc)
            {
                if (client.Rut== txtRut.Text)
                {
                    lc.Remove(client);
                    break;
                }
            }
            btnLimpiar_Click(sender, e);
            tabla.DataSource = null;
            tabla.DataSource = lc;
        }
    }
}

