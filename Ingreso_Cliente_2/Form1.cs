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
            Array arraySexo = typeof(Sexo).GetEnumValues();
            Array arrayEstado = typeof(EstadoCivil).GetEnumValues();
            //this.comboSexo.DataSource = arraySexo;
            //this.comboSexo.DataSource = arraySexo;
            this.comboSexo.Items.Add("Seleccione sexo");
            foreach (object obj in arraySexo)
            {
                this.comboSexo.Items.Add(obj);
            }
            this.comboEstado.Items.Add("Seleccione estado");
                foreach (object obj in arrayEstado)
                {
                    this.comboEstado.Items.Add(obj);
                }
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
            cliente.Sexo = (Sexo)this.comboSexo.SelectedIndex;
            cliente.Estado_civil = (EstadoCivil)this.comboEstado.SelectedIndex;
            lc.Add(cliente);
            tabla.DataSource = null;
            tabla.DataSource = lc;

            btnLimpiar_Click(sender, e);

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
            //comboSexo.SelectedIndex = cli.S;
            //comboSexo.SelectedIndex = string form.ToString(cli.S);
            //comboSexo.SelectedIndex = cli.comboSexo;
            //comboSexo.SelectedItem = cli.S;
            List<Cliente> ccl = new List<Cliente>();
            comboSexo.SelectedItem = cli.Sexo;
            comboEstado.SelectedItem = cli.Estado_civil;

            ccl.Add(cli);
            tabla.DataSource = null;
            tabla.DataSource = ccl;




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
            DialogResult mod = MessageBox.Show(this, "Esta seguro de querer modificar a cliente", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (mod == DialogResult.No)
                return;
            foreach (Cliente cli in lc)
            {
                if (cli.Rut == txtRut.Text)
                {
                    cli.Nombre = txtNombre.Text;
                    cli.Apellido = txtApellido.Text;
                    cli.F_nacimiento = comboDate.Value;
                    cli.Sexo = (Sexo)this.comboSexo.SelectedIndex;
                    cli.Estado_civil = (EstadoCivil)this.comboEstado.SelectedIndex;
                    break;
                }
            }
            btnLimpiar_Click(sender, e);
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

        private void btnActualiizar_Click(object sender, EventArgs e)
        {
            tabla.DataSource = null;
            tabla.DataSource = lc;

        }
    }
}

