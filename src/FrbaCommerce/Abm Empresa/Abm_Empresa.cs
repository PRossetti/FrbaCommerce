using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Abm_Empresa
{
    public partial class Abm_Empresa : Form
    {
        public Abm_Empresa()
        {
            InitializeComponent();
        }

        private void button_Crear_Emp_Click(object sender, EventArgs e)
        {
            Registro_de_Usuario.Nuevo_Empresa N_E = new Registro_de_Usuario.Nuevo_Empresa("administrador");
            this.Hide();
            N_E.ShowDialog();
            this.Show();
        }

        private void button_Modificar_Emp_Click(object sender, EventArgs e)
        {
            string que_hago = "modificar";
            Ingresar_Empresa I_E = new Ingresar_Empresa(que_hago);
            this.Hide();
            I_E.ShowDialog();
            this.Show();
        }

        private void button_Dar_Baja_Emp_Click(object sender, EventArgs e)
        {
            string que_hago = "eliminar";
            Ingresar_Empresa I_E = new Ingresar_Empresa(que_hago);
            this.Hide();
            I_E.ShowDialog();
            this.Show();
        }

        private void button_Listar_Emp_Click(object sender, EventArgs e)
        {
            Listado_Empresas L_E = new Listado_Empresas();
            this.Hide();
            L_E.ShowDialog();
            this.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
