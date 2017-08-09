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
    public partial class Preguntas_Ant : Form1
    {
        public Preguntas_Ant(int usuario_id)
        {
            InitializeComponent();

            string respuestas = "SELECT pub_cod, pub_desc, preg_desc, preg_resp FROM BE_SHARPS.Publicaciones, BE_SHARPS.Preguntas WHERE pub_cod = preg_pub_cod and preg_resp is NOT NULL and preg_usuario_id = " + usuario_id;

            SqlConnection con = this.crearConexion();

            con.Open();

            SqlDataAdapter adapter1 = new SqlDataAdapter(respuestas, con);
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1, "Preguntas");
            dataGridView1.DataSource = ds1.Tables[0];

            con.Close();
        }

        private void btn_Atras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
