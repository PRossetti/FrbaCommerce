using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient; // agregada

namespace FrbaCommerce.Registro_de_Usuario
{
    public partial class Cambiar_Pass : Form1
    {
        private int usuario_id;
        public Cambiar_Pass(int user_id)
        {
            InitializeComponent();
            txtBx_pass1.PasswordChar = '*';
            txtBx_pass2.PasswordChar = '*';
            usuario_id = user_id;
            label3.Text = "Este es su primer logueo.\nActualice su contraseña o su usuario será deshabilitado \ny no podrá volver a loguearse.";
        }

        private void btn_Volver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();            
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            
            if (txtBx_pass1.Text != "" && (txtBx_pass1.Text == txtBx_pass2.Text))
            {
                string update = "UPDATE BE_SHARPS.Usuarios set usuario_pass='" + SHA256Encripta(txtBx_pass1.Text) + "', usuario_last_login=convert(datetime,'" + obtenerFecha() + "',103)"
                    + ",usuario_habilitado=1 where usuario_id =" + usuario_id;
                SqlConnection con = this.crearConexion();
                SqlCommand cmd = new SqlCommand(update, con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("La contraseña de modificó correctamente");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    
                }
                catch (SqlException ex)
                {
                    SqlError err = ex.Errors[0];
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                MessageBox.Show("Error. Asegurese de completar ambos campos y que contenga el mismo valor");
            }
        }
    }
}
