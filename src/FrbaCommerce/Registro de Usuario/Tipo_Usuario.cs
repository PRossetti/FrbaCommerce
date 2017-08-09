using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Registro_de_Usuario
{
    public partial class Tipo_Usuario : Form
    {
        public Tipo_Usuario()
        {
            InitializeComponent();
        }

        private void button_Atras_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            this.Close(); //Aca hay un problema: si hago muchas veces atras en alguna se cierra

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_Siguiente_Click(object sender, EventArgs e)
        {
            string selectedString = comboBox1.SelectedText;
            int selectedIndex = comboBox1.SelectedIndex;
            if (selectedIndex == 0)
            {
                Registro_de_Usuario.Nuevo_Cliente N_C = new Registro_de_Usuario.Nuevo_Cliente("cliente");
                //N_C.Show();
                this.Hide();
                N_C.ShowDialog();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            if (selectedIndex == 1)
            {
                Registro_de_Usuario.Nuevo_Empresa N_E = new Registro_de_Usuario.Nuevo_Empresa("empresa");
                this.Hide();
                N_E.ShowDialog();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
