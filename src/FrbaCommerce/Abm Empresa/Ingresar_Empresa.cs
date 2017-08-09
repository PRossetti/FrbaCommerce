using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace FrbaCommerce.Abm_Empresa
{
    public partial class Ingresar_Empresa : Form1
    {
        string que_hago;

        public Ingresar_Empresa(string modo)
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
                    if (this.existe_Empresa(textBox_Empresa.Text) == true)
                    {
                        ArrayList datos_Empresa = this.obtener_Datos_Empresa(textBox_Empresa.Text);
                        Modificar_Empresa M_E = new Modificar_Empresa(datos_Empresa);
                        this.Hide();
                        M_E.ShowDialog();
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("No existe el usuario");
                    }


                    break;
                case "eliminar":
                    if (this.existe_Empresa(textBox_Empresa.Text) == true)
                    {
                        DialogResult advertencia =
                            MessageBox.Show("¿Está seguro que desea eliminar el Usuario '" + textBox_Empresa.Text + "'?",
                            "Advertencia", MessageBoxButtons.YesNo); // Botonera de advertencia que se va a eliminar
                        if (advertencia == DialogResult.Yes)
                        {
                            //elimino usuario
                            this.eliminar_Empresa(textBox_Empresa.Text);
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
