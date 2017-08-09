using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class Abm_Visibilidad : Form
    {
        public Abm_Visibilidad()
        {
            InitializeComponent();
        }

        private void Modificar_Visib_Click(object sender, EventArgs e)
        {
            //string que_hago = "modificar";
            //Ingresar_Visibilidad I_V = new Ingresar_Visibilidad(que_hago);
            Modificar_Visibilidad M_V = new Modificar_Visibilidad();
            this.Hide();
            //I_V.ShowDialog();
            M_V.ShowDialog();
            this.Show();

        }
        
        private void Crear_Visib_Click(object sender, EventArgs e)
        {
            Nueva_Visibilidad N_V = new Nueva_Visibilidad();
            this.Hide();
            N_V.ShowDialog();
            this.Show();
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

