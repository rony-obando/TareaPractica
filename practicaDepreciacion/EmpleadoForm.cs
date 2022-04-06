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
        IDetalleSE Detalle;
        char l = 'E';
        public EmpleadoForm(IEmpleadoServices empleadoServices, IActivoServices ActivoServices,IDetalleSE detalle)
        {
            this.activoServices = ActivoServices;
            empleado = empleadoServices;
            Detalle = detalle;
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
            int id = 0;
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
            if (nudIdAct.Value != 0)
            {
                DetalleAE detalle = new DetalleAE()
                {
                    IdActivo = activoServices.GetById((int)nudIdAct.Value),
                    IdEmpleado = empleado.GetById(dgvView.Rows.Count),
                    DateStart = 0
                };
                Detalle.Add(detalle);
                if (empleado1.activos == null)
                {
                    empleado1.activos = new List<int>();
                    empleado1.activos.Add((int)nudIdAct.Value);
                }
                else
                {
                    empleado1.activos.Add((int)nudIdAct.Value);
                }
            }
            
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
            int SelecionarId = (int)dgvView.Rows[e.RowIndex].Cells[0].Value;
            dgvView.DataSource = Detalle.GetActivos(SelecionarId);
            int c= Detalle.GetActivos(SelecionarId).Count;
            int b = 0;

        }

        private void btnAcivo_Click(object sender, EventArgs e)
        {
            Form1 activo = new Form1(activoServices,Detalle);
            activo.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HistorialForm historial = new HistorialForm(Detalle);
            historial.ShowDialog();
        }
    }
}
