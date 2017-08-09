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
    public partial class IndexPreguntas : Form1
    {
        private int user_id;
        private DataTable dt;
        public IndexPreguntas(int usuario_id)
        {
            InitializeComponent();            
            user_id = usuario_id;

            //string preguntas = "select COUNT(pub_cod)FROM BE_SHARPS.Publicaciones, BE_SHARPS.Preguntas WHERE preg_pub_cod = pub_cod and pub_id_usuario = "+ usuario_id;
            //string cantPreguntas = "select COUNT(pub_cod)FROM BE_SHARPS.Publicaciones, BE_SHARPS.Preguntas WHERE preg_pub_cod = pub_cod and pub_id_usuario = "+ usuario_id;
           
            //string preguntas = "select pub_cod as Publicacion, pub_id_usuario as Publicador, pub_desc, preg_cod, preg_usuario_id as Preguntador, preg_desc, preg_resp FROM	Publicaciones, BE_SHARPS.Preguntas WHERE	preg_pub_cod = pub_cod and pub_id_usuario = "+ usuario_id;
            string preguntas = "select pub_cod as Publicacion, pub_desc as Descripcion, preg_usuario_id as Usuario, preg_cod as CodigoPreg, preg_desc as Pregunta FROM BE_SHARPS.Publicaciones, BE_SHARPS.Preguntas WHERE preg_resp IS NULL and preg_pub_cod = pub_cod and pub_id_usuario = " + usuario_id;

            SqlConnection con = this.crearConexion();
            
            con.Open();
                        
            SqlDataAdapter adapter1 = new SqlDataAdapter(preguntas, con);   
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1, "Preguntas");
            dataGridView1.DataSource = ds1.Tables[0];
            txtBx_cantPreguntas.Text = ds1.Tables[0].Rows.Count.ToString();
            con.Close();
            dt = new DataTable();
            dt = ds1.Tables[0];
           
        }

        private void IndexPreguntas_Load(object sender, EventArgs e)
        {

        }

        private void btm_Responder_Click(object sender, EventArgs e)
        {
            //&& dataGridView1.SelectedRows.Count > 0
            if ( dt.Rows.Count>0 )
            {
                int preg_cod = int.Parse(dataGridView1["CodigoPreg", dataGridView1.CurrentRow.Index].Value.ToString());

                Gestion_de_Preguntas.Responder R = new Gestion_de_Preguntas.Responder(preg_cod);
                R.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una pregunta primero.");
            }
        }

        private void btn_verResp_Click(object sender, EventArgs e)
        {
            Gestion_de_Preguntas.Respuestas_Ant R_A = new Gestion_de_Preguntas.Respuestas_Ant(user_id);
            R_A.ShowDialog();
            this.Show();
        }

        private void btn_Atras_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_verPreg_Click(object sender, EventArgs e)
        {
            Gestion_de_Preguntas.Preguntas_Ant P_A = new Gestion_de_Preguntas.Preguntas_Ant(user_id);
            P_A.ShowDialog();
            this.Show();
        }
    }
}
