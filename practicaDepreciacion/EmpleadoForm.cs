using AppCore.IServices;
using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practicaDepreciacion
{
    public partial class EmpleadoForm : Form
    {
        IEmpleadoServices empleado;
        IActivoServices activoServices;
        public EmpleadoForm(IEmpleadoServices empleadoServices, IActivoServices ActivoServices)
        {
            this.activoServices = ActivoServices;
            empleado = empleadoServices;
            InitializeComponent();
        }
        private void Limpiar()
        {
            txtApellidos.Text = "";
            txtCedula.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtNombres.Text = "";
            txtTelefono.Text = "";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //int a = cmbEstado.SelectedIndex;
            Empleado empleado1 = new Empleado()
            {
                Nombres = txtNombres.Text,
                Cedula = txtCedula.Text,
                Apellidos = txtApellidos.Text,
                Direccion=txtDireccion.Text,
                Telefono=txtTelefono.Text,
                Email=txtEmail.Text,
                Estado=(Estado)cmbEstado.SelectedIndex
                
            };
            empleado.Add(empleado1);
            dgvView.DataSource = null;
            Limpiar();
            dgvView.DataSource = empleado.Read();
        }

        private void EmpleadoForm_Load(object sender, EventArgs e)
        {
            dgvView.DataSource = empleado.Read();
        }

        private void dgvView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Form1 activo = new Form1(activoServices,empleado.GetById(1));
                activo.ShowDialog();
            }
        }
    }
}
