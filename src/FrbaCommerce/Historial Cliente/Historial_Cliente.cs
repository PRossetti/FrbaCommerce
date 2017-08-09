using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Historial_Cliente
{
    public partial class Historial_Cliente : Form
    {
        private string usuario_actual;
        public Historial_Cliente(string usuario)
        {
            InitializeComponent();
            usuario_actual = usuario;
        }

        private void button_HistorialCompras_Click(object sender, EventArgs e)
        {
            Historial_Listar H_L = new Historial_Listar(usuario_actual, "compras");
            this.Hide();
            H_L.ShowDialog();
            this.Show();
        }

        private void button_HistorialOfertas_Click(object sender, EventArgs e)
        {
            Historial_Listar H_L = new Historial_Listar(usuario_actual, "ofertas");
            this.Hide();
            H_L.ShowDialog();
            this.Show();
        }

        private void button_HistorialCalificaciones_Click(object sender, EventArgs e)
        {
            Historial_Listar H_L = new Historial_Listar(usuario_actual, "calificaciones");
            this.Hide();
            H_L.ShowDialog();
            this.Show();
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
