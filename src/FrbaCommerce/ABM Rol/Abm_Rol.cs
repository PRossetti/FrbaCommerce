using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.ABM_Rol
{
    public partial class Abm_Rol : Form
    {
        public Abm_Rol()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            Nuevo_Rol N_R = new Nuevo_Rol();
            this.Hide();
            N_R.ShowDialog();
            this.Show();
            
        }

        private void btn_permisos_Click(object sender, EventArgs e)
        {
            Permisos N_P = new Permisos();
            this.Hide();
            N_P.ShowDialog();
            this.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string que_hago = "modificar";
            Ingresar_Rol M_R = new Ingresar_Rol(que_hago);
            this.Hide();
            M_R.ShowDialog();
            this.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string que_hago = "eliminar";
            Ingresar_Rol E_R = new Ingresar_Rol(que_hago);
            this.Hide();
            E_R.ShowDialog();
            this.Show();
        }
    }
}
