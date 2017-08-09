using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class Abm_Cliente : Form
    {
        public Abm_Cliente()
        {
            InitializeComponent();
        }

        private void button_Crear_Cli_Click(object sender, EventArgs e)
        {
            Registro_de_Usuario.Nuevo_Cliente N_C = new Registro_de_Usuario.Nuevo_Cliente("administrador");
            //N_C.Show();
            this.Hide();
            N_C.ShowDialog();
            this.Show();
        }

        private void button_Modificar_Cli_Click(object sender, EventArgs e)
        {
            string que_hago = "modificar";
            Ingresar_Cliente I_C = new Ingresar_Cliente(que_hago);
            this.Hide();
            I_C.ShowDialog();
            this.Show();

        }

        private void button_Dar_Baja_Cli_Click(object sender, EventArgs e)
        {
            string que_hago = "eliminar";
            Ingresar_Cliente I_C = new Ingresar_Cliente(que_hago);
            this.Hide();
            I_C.ShowDialog();
            this.Show();
        }

        private void button_Listar_Cli_Click(object sender, EventArgs e)
        {
            Listado_Clientes L_C = new Listado_Clientes();
            this.Hide();
            L_C.ShowDialog();
            this.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
