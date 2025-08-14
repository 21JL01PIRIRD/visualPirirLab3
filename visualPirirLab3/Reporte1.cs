using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visualPirirLab3
{
    public partial class Reporte1 : Form
    {
        public Reporte1()
        {
            InitializeComponent();
        }

        private void Reporte1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'productosConexion.tienda' Puede moverla o quitarla según sea necesario.
            this.tiendaTableAdapter.Fill(this.productosConexion.tienda);

            this.reportViewer1.RefreshReport();
        }
    }
}
