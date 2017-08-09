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
using System.Collections;

namespace FrbaCommerce.Gestion_de_Preguntas
{
    public partial class Responder : Form1
    {
        int preg_cod2;
        public Responder(int preg_cod)
        {
            InitializeComponent();
            preg_cod2 = preg_cod;
            labelRemaining.Text = "255";

            string pregunta = "select preg_desc FROM BE_SHARPS.Publicaciones, BE_SHARPS.Preguntas WHERE preg_pub_cod = pub_cod and preg_cod = " + preg_cod;

            SqlConnection con = this.crearConexion();

            con.Open();

            SqlDataAdapter adapter1 = new SqlDataAdapter(pregunta, con);
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1, "Pregunta");
            lbl_Pregunta.Text = ds1.Tables[0].Rows[0][0].ToString();
            //dataGridView1.DataSource = ds1.Tables[0];
            //txtBx_cantPreguntas.Text = ds1.Tables[0].Rows.Count.ToString();

            con.Close();
        }

        private void txtBx_Respuesta_TextChanged(object sender, EventArgs e)
        {
            labelRemaining.Text = (txtBx_Respuesta.MaxLength - txtBx_Respuesta.TextLength).ToString();
        }

        private void btn_Responder_Click(object sender, EventArgs e)
        {
            string respuesta = "update BE_SHARPS.Preguntas set preg_resp = '" + txtBx_Respuesta.Text + "' where preg_cod = " + preg_cod2;

            SqlConnection con = this.crearConexion();
            SqlCommand cmd = new SqlCommand(respuesta, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Tu respuesta ha sido enviada.");
            this.DialogResult = DialogResult.OK;
            this.Close();            

        }

        private void btn_Atras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
