using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace FrbaCommerce.Calificar_Vendedor
{
    public partial class CalificarCompra : Form1
    {
        private int compra;
        public CalificarCompra(int id_compra)
        {
            InitializeComponent();
            compra = id_compra;
            label_ErrorM.Hide();
            label_ErrorMensaje.Hide();
            labelRemaining.Text = "140";


            comboBox1.Items.Add(1);
            comboBox1.Items.Add(2);
            comboBox1.Items.Add(3);
            comboBox1.Items.Add(4);
            comboBox1.Items.Add(5);
            comboBox1.Items.Add(6);
            comboBox1.Items.Add(7);
            comboBox1.Items.Add(8);
            comboBox1.Items.Add(9);
            comboBox1.Items.Add(10);


        }


        private void btn_Atras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_Calificar_Click(object sender, EventArgs e)
        {
            label_ErrorM.Hide();
            bool datos_ok = true;

            if (comboBox1.SelectedIndex == -1)
            {
                datos_ok = false;
            }
            else
            {
                int calif;
                calif = int.Parse(comboBox1.SelectedIndex.ToString()) + 1;
                //string calificacion = "INSERT into BE_SHARPS.Calificaciones VALUES (" + calif + ", '" + txtBx_Calificacion.Text + "')";
                

                SqlConnection con = this.crearConexion();
                //SqlCommand cmd = new SqlCommand(calificacion, con);
                SqlCommand cmd = new SqlCommand("BE_SHARPS.calificar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@compra_id", compra);
                cmd.Parameters.AddWithValue("@estrellas",calif);
                cmd.Parameters.AddWithValue("@desc",txtBx_Calificacion.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close(); 

                /*
                if (txtBx_Calificacion.Text != "")
                {
                    string calificacion2 = "INSERT into BE_SHARPS.Calificaciones () VALUES (calif_desc = '" + txtBx_Calificacion.Text + "' where compra_id = " + compra;
                    SqlCommand cmd2 = new SqlCommand(calificacion2, con);
                    cmd2.ExecuteNonQuery();

                }
                */  
            }           

            if (datos_ok == true)
            {
                label_ErrorMensaje.Text = "";
                MessageBox.Show("Tu calificación ha sido enviada. Muchas gracias.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                label_ErrorMensaje.Text = "(*) Es necesario ingresar una calificación.";
                label_ErrorMensaje.Show();
                label_ErrorM.Show();
            }



        }

        private void txtBx_Calificacion_TextChanged(object sender, EventArgs e)
        {
            labelRemaining.Text = (txtBx_Calificacion.MaxLength - txtBx_Calificacion.TextLength).ToString();
        }



    }
}
