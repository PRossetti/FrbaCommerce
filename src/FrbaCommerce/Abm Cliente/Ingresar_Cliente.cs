using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using FrbaCommerce.Calificar_Vendedor;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class Ingresar_Cliente : Form1
    {
        string que_hago; //esto es porque lo puede llamar Eliminar o Modificar

        public Ingresar_Cliente(string modo)
        {
            InitializeComponent();
            que_hago = modo;
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        
        private void button_Siguiente_Click(object sender, EventArgs e)
        {

            switch (que_hago.ToLower())
            {
                case "modificar":

                    if (this.existe_Usuario(textBox_Usuario.Text) == true)
                    {
                        ArrayList datos_Usuario = this.obtener_Datos_Usuario(textBox_Usuario.Text);
                        Modificar_Cliente M_C = new Modificar_Cliente(datos_Usuario);
                        this.Hide();
                        M_C.ShowDialog();
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("No existe el usuario");
                    }


                    break;
                case "eliminar":
                    if (this.existe_Usuario(textBox_Usuario.Text) == true)
                    {
                        DialogResult advertencia =
                            MessageBox.Show("¿Está seguro que desea eliminar el Usuario '" + textBox_Usuario.Text + "'?",
                            "Advertencia", MessageBoxButtons.YesNo); // Botonera de advertencia que se va a eliminar
                        if (advertencia == DialogResult.Yes)
                        {
                            //elimino usuario
                            this.eliminar_Cliente(textBox_Usuario.Text);
                            //muestro mensaje que fue eliminado
                            this.Hide();
                            MessageBox.Show("El Usuario ha sido eliminado.");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        //En otro caso dejo todo como está

                    }
                    else
                    {
                        MessageBox.Show("No existe el usuario");
                    }
                    break;
            }


        }
        
    }
}
