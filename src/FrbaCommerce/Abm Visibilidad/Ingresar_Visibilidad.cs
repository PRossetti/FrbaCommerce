using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class Ingresar_Visibilidad : Form1
    {
        string que_hago; //esto es porque lo puede llamar Eliminar o Modificar

        public Ingresar_Visibilidad(string modo)
        {
            InitializeComponent();
            que_hago = modo;
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void button_aceptar_Click(object sender, EventArgs e)
        {

            switch (que_hago.ToLower())
            {
                case "modificar":
                    /*
                    if (this.existe_Visibilidad(Convert.ToInt32(textBox_cod.Text)) == true)
                    {
                        ArrayList datos_Visibilidad = this.obtener_Datos_Visibilidad(Convert.ToInt32(textBox_cod.Text));
                        Modificar_Visibilidad M_C = new Modificar_Visibilidad();
                        this.Hide();
                        M_C.ShowDialog();
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("No existe la visibilidad");
                    }
                    */
                    break;
                case "eliminar":
                    if (this.existe_Visibilidad(Convert.ToInt32(textBox_cod.Text)) == true)
                    {
                        DialogResult advertencia =
                            MessageBox.Show("¿Está seguro que desea eliminar la Visibilidad '" + textBox_cod.Text + "'?",
                            "Advertencia", MessageBoxButtons.YesNo); // Botonera de advertencia que se va a eliminar
                        if (advertencia == DialogResult.Yes)
                        {
                            //elimino usuario
                            this.eliminar_Visibilidad(Convert.ToInt32(textBox_cod.Text));
                            //muestro mensaje que fue eliminado
                            this.Hide();
                            MessageBox.Show("La Visibilidad ha sido eliminado.");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        //En otro caso dejo todo como está

                    }
                    else
                    {
                        MessageBox.Show("No existe la Visibilidad");
                    }
                    break;
            }


        }

        private void button_cancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
