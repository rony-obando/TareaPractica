using AppCore.IServices;
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
    public partial class HistorialForm : Form
    {
        IDetalleSE Detalle;
        public HistorialForm(IDetalleSE Detalle)
        {
            this.Detalle = Detalle;
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void HistorialForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Detalle.Read();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
