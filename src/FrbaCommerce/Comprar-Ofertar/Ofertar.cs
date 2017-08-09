using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient; //agregada

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class Ofertar : Form1
    {
        private int pub_codigo;
        private decimal pub_precio;
        private int usuario_id;
        public Ofertar(int pub_cod, decimal pub_pre, int user_id)
        {
            InitializeComponent();

            pub_precio = pub_pre;
            pub_codigo = pub_cod;
            usuario_id = user_id;

            txtBx_PujaActual.Text = pub_precio.ToString();

            label_MsjRevisar.Text = "";
            label_Error.Text = "";
            label_MensajeOK.Text = "";
        }

        private void btn_Pujar_Click(object sender, EventArgs e)
        {         
            int ret;
            bool datos_ok = true;

            if (int.TryParse(txtBx_Puja.Text, out ret) == true &&(decimal.Parse(txtBx_Puja.Text) > decimal.Parse(txtBx_PujaActual.Text)))
            {
                int puja = int.Parse(txtBx_Puja.Text); 
                //string update = "UPDATE BE_SHARPS.Publicaciones SET pub_precio=@puja where pub_cod=" + pub_codigo;
                SqlConnection con = this.crearConexion();
                SqlCommand cmd = new SqlCommand("BE_SHARPS.ofertar", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@pub_codigo", pub_codigo);
                cmd.Parameters.AddWithValue("@cli_id", usuario_id); //ahora se pasa el usuario_id
                cmd.Parameters.AddWithValue("@puja", puja);
                cmd.Parameters.AddWithValue("@fecha", obtenerFecha()); // se agrego el convert en el sp

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                label_Error.Text = "";
                label_MensajeOK.Text = " La puja se realizó satisfactoriamente";
                txtBx_PujaActual.Text = txtBx_Puja.Text;
                label_Error.Text = "";
                label_MsjRevisar.Text = "";
            }
            else
            {
                datos_ok = false;
            }
            if (datos_ok == false)
            {
                label_Error.Text = "(*)";
                label_MsjRevisar.Text = "(*) Ingrese un valor entero más alto que el actual.";
            }

        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
