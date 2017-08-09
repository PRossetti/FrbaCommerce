using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient; 
using System.Text.RegularExpressions;

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class Preguntar : Form1
    {
        private int pub_cod;
        private int usuario_id;

        public Preguntar(int pub_cod2, int usuario_id2)
        {
            InitializeComponent();
            labelRemaining.Text = "255";
            pub_cod = pub_cod2;
            usuario_id = usuario_id2;
        }

    
        private void Preguntar_Load(object sender, EventArgs e)
        {

        }

        private void btn_Atras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void btn_Preguntar_Click(object sender, EventArgs e)
        {

           
            string pregunta = "insert INTO BE_SHARPS.Preguntas (preg_pub_cod, preg_usuario_id, preg_desc) VALUES (" + pub_cod + ", "+ usuario_id + ", '" + txtBx_Pregunta.Text + "')";
                
             
            SqlConnection con = this.crearConexion();
            SqlCommand cmd = new SqlCommand(pregunta, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

              
            //MessageBox.Show(""+txtBx_Pregunta.Text);
            
            MessageBox.Show("Tu pregunta ha sido enviada. Para visualizar la respuesta, entra al Gestor de Preguntas que a la brevedad te responderán. Muchas gracias.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtBx_Pregunta_TextChanged(object sender, EventArgs e)
        {         
           
            labelRemaining.Text = (txtBx_Pregunta.MaxLength - txtBx_Pregunta.TextLength).ToString();
            
        }

    }
}
