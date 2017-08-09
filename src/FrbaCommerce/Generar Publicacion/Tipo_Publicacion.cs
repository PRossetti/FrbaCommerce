using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.Generar_Publicacion
{
    public partial class Tipo_Publicacion : Form1
    {
        private string usuario_actual;

        //Tipo_Publicacion() recibe el nombre de usuario que llamo al procedimiento generar publicacion!!!
        public Tipo_Publicacion(string usuario)
        {
            InitializeComponent();
            usuario_actual = usuario;
            
            string select = "select tipo_id, tipo_nombre from be_sharps.tipo_pub where tipo_habilitado = 1";
            SqlConnection conexion = this.crearConexion();
            SqlDataAdapter dataadapter = new SqlDataAdapter(select, conexion);
            
            DataSet dataset = new DataSet();
            conexion.Open();
            dataadapter.Fill(dataset);
            conexion.Close();

            comboBox1.DataSource = dataset.Tables[0];
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.ValueMember = "tipo_nombre";
            comboBox1.SelectedIndex = 0;
        }

        private void button_Atras_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_Siguiente_Click(object sender, EventArgs e)
        {
            //Controlo que el combobox tenga alguno de los elementos seleccionados!!!

            if (comboBox1.Items.Contains(comboBox1.SelectedItem))
            {
                Generar_Publicacion G_P = new Generar_Publicacion(comboBox1.Text, usuario_actual);
                this.Hide();
                G_P.ShowDialog();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else MessageBox.Show("Tipo de publicación erronea");
        }

      
    }
}
