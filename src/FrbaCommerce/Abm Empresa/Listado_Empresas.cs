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

namespace FrbaCommerce.Abm_Empresa
{
    public partial class Listado_Empresas : Form1
    {
        public Listado_Empresas()
        {
            InitializeComponent();
            string select = "SELECT usuario_user, emp_rsocial, emp_cuit, emp_mail FROM BE_SHARPS.Usuarios right join BE_SHARPS.Empresas on u_emp_id = emp_id"; //where usuario_habilitado=1";
            SqlConnection conexion = this.crearConexion();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion);

            DataSet ds = new DataSet();
            conexion.Open();
            dataAdapter.Fill(ds, "Usuarios");
            conexion.Close();

            Lista_Empresas.DataSource = ds.Tables[0];
            //Lista_Empresas.DataMember = "Usuarios";
        }

        private void button_Seleccionar_Click(object sender, EventArgs e)
        {
            textBox_Empresa.Text = Lista_Empresas["usuario_user",Lista_Empresas.CurrentRow.Index].Value.ToString();
            //textBox_Empresa.Text = Lista_Empresas.CurrentCell.Value.ToString();
        }

        private void button_Atras_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_Modificar_Click(object sender, EventArgs e)
        {
            if (this.existe_Empresa(textBox_Empresa.Text) == true)
            {
                ArrayList datos_Empresa = this.obtener_Datos_Empresa(textBox_Empresa.Text);
                Modificar_Empresa M_E = new Modificar_Empresa(datos_Empresa);
                this.Hide();
                M_E.ShowDialog();
                this.Show();

            }
            else
            {
                MessageBox.Show("No existe la empresa");
            }
        }

        private void button_Eliminar_Click(object sender, EventArgs e)
        {
            if (this.existe_Empresa(textBox_Empresa.Text) == true)
            {
                DialogResult advertencia =
                    MessageBox.Show("¿Está seguro que desea eliminar la empresa '" + textBox_Empresa.Text + "'?",
                    "Advertencia", MessageBoxButtons.YesNo); // Botonera de advertencia que se va a eliminar
                if (advertencia == DialogResult.Yes)
                {
                    //elimino usuario
                    this.eliminar_Empresa(textBox_Empresa.Text);
                    //muestro mensaje que fue eliminado
                    this.Hide();
                    MessageBox.Show("La empresa ha sido eliminada.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                //En otro caso dejo todo como está

            }
            else
            {
                MessageBox.Show("No existe la empresa");
            }
        }

        private void button_Filtrar_Click(object sender, EventArgs e)
        {
            string empresa, cuit, mail = "";
            empresa = textBox_FiltroEmpresa.Text + '%';
            cuit = textBox_FiltroCUIT.Text + '%';
            mail = textBox_FiltroMail.Text + '%';

            string select = "SELECT usuario_user, emp_rsocial, emp_cuit, emp_mail FROM BE_SHARPS.Usuarios right join BE_SHARPS.Empresas on u_emp_id = emp_id "
            + " where emp_rsocial like @empresa AND emp_cuit like @cuit AND emp_mail like @mail";
            SqlConnection conexion = this.crearConexion();
            SqlCommand comando = new SqlCommand(select, conexion);
            comando.Parameters.AddWithValue("@empresa", empresa);
            comando.Parameters.AddWithValue("@cuit", cuit);
            comando.Parameters.AddWithValue("@mail", mail);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);

            DataSet ds = new DataSet();
            conexion.Open();
            dataAdapter.Fill(ds, "Usuarios");
            conexion.Close();

            Lista_Empresas.DataSource = ds;
            Lista_Empresas.DataMember = "Usuarios";
        
        }


    }
}
