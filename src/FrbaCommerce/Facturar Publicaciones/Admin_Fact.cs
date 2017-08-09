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

namespace FrbaCommerce.Facturar_Publicaciones
{
    public partial class Admin_Fact : Form1
    {
        public Admin_Fact()
        {
            InitializeComponent();

            string select = "SELECT usuario_user FROM BE_SHARPS.Usuarios";
            SqlConnection conexion1 = this.crearConexion();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion1);

            DataSet ds = new DataSet();
            conexion1.Open();
            dataAdapter.Fill(ds, "Usuarios");
            conexion1.Close();
            textBox_FiltroMail.Hide();
            textBox_FiltroNombre.Hide();
            Lista_Usuarios.DataSource = ds;
            Lista_Usuarios.DataMember = "Usuarios";


        }
        private void Lista_Usuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button_Seleccionar_Click(object sender, EventArgs e)
        {
            textBox_Usuario.Text = Lista_Usuarios.CurrentCell.Value.ToString();
        }

        private void button_Atras_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


       

        private void button_Filtrar_Click(object sender, EventArgs e)
        {            
            string usuario, nombre, mail = "";
            usuario = textBox_FiltroUsuario.Text +'%';
            nombre = textBox_FiltroNombre.Text +'%';
            mail = textBox_FiltroMail.Text +'%';

            if (textBox_FiltroUsuario.Text == "")
            {
                MessageBox.Show("Error en el campo de filtro");
            }

            string select = "SELECT usuario_user FROM BE_SHARPS.Usuarios "
            + " where usuario_user like '%"+textBox_FiltroUsuario.Text+"%'";// AND cli_nombre like @nombre AND cli_mail like @mail";
            SqlConnection conexion1 = this.crearConexion();
            SqlCommand comando = new SqlCommand(select,conexion1);
            comando.Parameters.AddWithValue("@usuario",usuario);
            //comando.Parameters.AddWithValue("@nombre", nombre);
            //comando.Parameters.AddWithValue("@mail", mail);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);

            DataSet ds = new DataSet();
            conexion1.Open();
            dataAdapter.Fill(ds, "Usuarios");
            conexion1.Close();

            Lista_Usuarios.DataSource = ds;
            Lista_Usuarios.DataMember = "Usuarios";
        }

        private void btn_Facturar_Click(object sender, EventArgs e)
        {

            if (textBox_Usuario.Text != "")
            {
                //MessageBox.Show(textBox_Usuario.Text);
                Facturar_Publicaciones.Ventas_Realizadas F_P = new Facturar_Publicaciones.Ventas_Realizadas(textBox_Usuario.Text);
                this.Hide();
                F_P.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario.");
            }


        }

    }
}
