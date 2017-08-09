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

namespace FrbaCommerce.Abm_Cliente
{
    public partial class Listado_Clientes : Form1
    {
        public Listado_Clientes()
        {
            InitializeComponent();

            string select = "SELECT usuario_user, cli_nombre, cli_apellido, cli_mail, cli_doc_tipo, "
            + " cli_doc_nro, cli_telefono FROM BE_SHARPS.Usuarios right join BE_SHARPS.Clientes on u_cli_id = cli_id"; // where usuario_habilitado=1";
            SqlConnection conexion1 = this.crearConexion();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion1);

            DataSet ds = new DataSet();
            conexion1.Open();
            dataAdapter.Fill(ds, "Usuarios");
            conexion1.Close();

            dataGridView_Usuarios.DataSource = ds.Tables[0];
            //dataGridView_Usuarios.DataMember = "Usuarios";


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

        private void button_Seleccionar_Click(object sender, EventArgs e)
        {
            textBox_Usuario.Text = dataGridView_Usuarios["usuario_user", dataGridView_Usuarios.CurrentRow.Index].Value.ToString();
            //textBox_Usuario.Text = dataGridView_Usuarios.CurrentCell.Value.ToString();
        }

        private void button_Atras_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_Modificar_Click(object sender, EventArgs e)
        {
            if (this.existe_Usuario(textBox_Usuario.Text) == true)
            {
                ArrayList datos_Usuario = this.obtener_Datos_Usuario(textBox_Usuario.Text);
                Modificar_Cliente M_C = new Modificar_Cliente(datos_Usuario);
                this.Hide();
                M_C.ShowDialog();
                this.Show();

            }
            else
            {
                MessageBox.Show("No existe el usuario");
            }
        }

        private void button_Eliminar_Click(object sender, EventArgs e)
        {
            if (this.existe_Usuario(textBox_Usuario.Text) == true)
            {
                DialogResult advertencia =
                    MessageBox.Show("¿Está seguro que desea eliminar el Usuario '" + textBox_Usuario.Text + "'?",
                    "Advertencia", MessageBoxButtons.YesNo); // Botonera de advertencia que se va a eliminar
                if (advertencia == DialogResult.Yes)
                {
                    //elimino usuario
                    this.eliminar_Cliente(textBox_Usuario.Text);
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
        }

        private void button_Filtrar_Click(object sender, EventArgs e)
        {
            string nombre, apellido, mail, tipoDoc, numDoc, tel = "";
            apellido = textBox_FiltroApellido.Text +'%';
            nombre = textBox_FiltroNombre.Text +'%';
            mail = textBox_FiltroMail.Text +'%';
            if (comboBox_FiltroTipoDoc.SelectedItem == null) tipoDoc = "%";
            else tipoDoc = comboBox_FiltroTipoDoc.SelectedItem.ToString() + '%';
            numDoc = textBox_FiltroNumDoc.Text + '%';
            tel = textBox_FiltroTelefono.Text + '%';

            string select = "SELECT usuario_user, cli_nombre, cli_apellido, cli_mail, cli_doc_tipo, "
            + " cli_doc_nro, cli_telefono FROM BE_SHARPS.Usuarios right join BE_SHARPS.Clientes on u_cli_id = cli_id "
            + " where cli_apellido like @apellido AND cli_nombre like @nombre AND cli_mail like @mail "
            + " AND cli_doc_tipo like @tipoDoc AND cli_doc_nro like @numDoc AND cli_telefono like @tel";
            SqlConnection conexion1 = this.crearConexion();
            SqlCommand comando = new SqlCommand(select,conexion1);
            
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@apellido", apellido);
            comando.Parameters.AddWithValue("@mail", mail);
            comando.Parameters.AddWithValue("@tipoDoc", tipoDoc);
            comando.Parameters.AddWithValue("@numDoc", numDoc);
            comando.Parameters.AddWithValue("@tel", tel);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);

            DataSet ds = new DataSet();
            conexion1.Open();
            dataAdapter.Fill(ds, "Usuarios");
            conexion1.Close();

            dataGridView_Usuarios.DataSource = ds.Tables[0];
            //Lista_Usuarios.DataMember = "Usuarios";
        }

    }
}
