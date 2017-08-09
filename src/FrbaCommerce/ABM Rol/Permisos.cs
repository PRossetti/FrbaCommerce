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

namespace FrbaCommerce.ABM_Rol
{
    public partial class Permisos : Form1
    {
        public Permisos()
        {
            InitializeComponent();

            label_Error.Text = "";
            label_MsjRevisar.Text = "";

            string select = "SELECT usuario_id FROM BE_SHARPS.Usuarios";
            SqlConnection conexion1 = this.crearConexion();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion1);

            DataSet ds = new DataSet();
            conexion1.Open();
            dataAdapter.Fill(ds, "Usuarios");
            conexion1.Close();

            Lista_Usuarios.DataSource = ds;
            Lista_Usuarios.DataMember = "Usuarios";


        }
        private void Lista_Usuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //¡¡QUE ME CHUPE LA PIJA PROGRAMA DE MIERDA!!
            //textBox_Usuario.Text = Lista_Usuarios.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            /*int indexfila = Lista_Usuarios.CurrentCell.RowIndex;
            int indexcolumna = Lista_Usuarios.CurrentCell.ColumnIndex;

            textBox_Usuario.Text = Lista_Usuarios.Rows[indexfila].Cells[indexcolumna].Value.ToString();*/
            //textBox_Usuario.Text = Lista_Usuarios.CurrentCell.Value.ToString();
        }


        private void button_Seleccionar_Click_1(object sender, EventArgs e)
        {
            textBox_Usuario.Text = Lista_Usuarios.CurrentCell.Value.ToString();
        }

        private void button_Modificar_Click_1(object sender, EventArgs e)
        {
            if (textBox_Usuario.Text == "")
            {
                label_Error.Text = "(*)";
                label_MsjRevisar.Text = "(*) LOS CAMPOS TIENEN INFORMACIÓN NO VÁLIDA";
            }
            else
            {
                Cambiar_Permisos C_P = new Cambiar_Permisos(int.Parse(textBox_Usuario.Text));
                this.Hide();
                C_P.ShowDialog();
                this.Show();
            }
        }

        private void button_Atras_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        /*
        private void button_Filtrar_Click(object sender, EventArgs e)
        {
            string usuario, nombre, mail = "";
            usuario = textBox_FiltroUsuario.Text + '%';
            nombre = textBox_FiltroNombre.Text + '%';
            mail = textBox_FiltroMail.Text + '%';

            string select = "SELECT cliente_usuario FROM "
            + "Cliente_Prueba where cliente_usuario like "
            + "@usuario AND cliente_nombre like @nombre AND cliente_mail like @mail";
            SqlConnection conexion1 = this.crearConexion();
            SqlCommand comando = new SqlCommand(select, conexion1);
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@mail", mail);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);

            DataSet ds = new DataSet();
            conexion1.Open();
            dataAdapter.Fill(ds, "Usuarios");
            conexion1.Close();

            Lista_Usuarios.DataSource = ds;
            Lista_Usuarios.DataMember = "Usuarios";
        }*/

    }
}
