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

namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class Modificar_Visibilidad : Form1
    {

        //public Modificar_Visibilidad(ArrayList datos_Visibilidad)
        public Modificar_Visibilidad()
        {
            InitializeComponent();

            label_ErrorDesc.Text = "";            
            label_ErrorPrecio.Text = "";
            label_ErrorPorcentaje.Text = "";
            label_ErrorMensaje.Text = "";
            label_ErrorDias.Text = "";

            //Completo los campos:
            //textBox_cod.Text = datos_Visibilidad[0].ToString();

            string consulta = "SELECT * FROM BE_SHARPS.Visibilidad where visib_habilitada=1";
            SqlConnection con = this.crearConexion();
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Visibilidad");
            DataTable dt = ds.Tables[0];

            listBox1.DataSource = dt;
            listBox1.ValueMember = "visib_cod";
            listBox1.DisplayMember = "visib_desc";

            //nombre_visibilidad_original = datos_Visibilidad[0].ToString();
            //cod_visibilidad = Convert.ToInt32(datos_Visibilidad[0]);                
        }

 
        private void button_aceptar_Click(object sender, EventArgs e)
        {
            //CHECKEAR QUE TODOS LOS DATOS ESTAN BIEN (MISMO METODO PARA AGREGAR NUEVO!!!)

            bool datos_ok = true;

            if (!Regex.IsMatch(textBox_desc.Text, @"^[a-zA-Z]+$"))
            {
                datos_ok = false;
                label_ErrorDesc.Text = "(*)";
            }
            else label_ErrorDesc.Text = "";

            decimal precio;
            if (!Decimal.TryParse(textBox_precio.Text, out precio))
            {
                datos_ok = false;
                label_ErrorPrecio.Text = "(*)";
            }
            else label_ErrorPrecio.Text = "";

            decimal porcentaje;
            if (!Decimal.TryParse(textBox_porc.Text, out porcentaje))            
            {
                datos_ok = false;
                label_ErrorPorcentaje.Text = "(*)";
            }
            else label_ErrorPorcentaje.Text = "";


            decimal dias;
            if (!Decimal.TryParse(textBox_dias.Text, out dias))
            {
                datos_ok = false;
                label_ErrorDias.Text = "(*)";
            }
            else label_ErrorDias.Text = "";


            if (datos_ok == true)
            {
                label_ErrorMensaje.Text = "";
                string update = "UPDATE BE_SHARPS.Visibilidad SET visib_desc = @visib_desc, visib_precio = @visib_precio, "
                + "visib_porcentaje = @visib_porcentaje, visib_dias = @visib_dias WHERE visib_cod = @visib_cod";
                SqlConnection con = crearConexion();
                SqlCommand cmd = new SqlCommand(update, con);

                cmd.Parameters.AddWithValue("@visib_cod", txtBx_CodVisib.Text);
                cmd.Parameters.AddWithValue("@visib_desc", textBox_desc.Text);
                cmd.Parameters.AddWithValue("@visib_precio", double.Parse(textBox_precio.Text));
                cmd.Parameters.AddWithValue("@visib_porcentaje", double.Parse(textBox_porc.Text));
                cmd.Parameters.AddWithValue("@visib_dias", double.Parse(textBox_dias.Text));

                int error = 0;

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    SqlError err = ex.Errors[0];
                    MessageBox.Show(ex.Message);
                    error = 1;
                }

                if (error == 0)
                {
                    MessageBox.Show("Datos cargados exitosamente.");
                    this.DialogResult = DialogResult.OK; // PREGUNTAR ¿qué función cumple?
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Los datos no fueron insertados");
                }

                con.Close();
            }
            else
            {
                label_ErrorMensaje.Text = "(*) LOS CAMPOS TIENEN INFORMACIÓN NO VÁLIDA";
            }
        }



        private void button_cancelar_Click_1(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBx_CodVisib.Text = listBox1.SelectedValue.ToString();

            


            //txtBx_Visib.Text = ((DataRowView)listBox1.SelectedItem)["visib_desc"].ToString();
        }

        private void btn_Cargar_Click(object sender, EventArgs e)
        {
            string consulta = "SELECT * FROM BE_SHARPS.Visibilidad where visib_cod=" + txtBx_CodVisib.Text;
            SqlConnection con1 = this.crearConexion();
            SqlDataAdapter adapter1 = new SqlDataAdapter(consulta, con1);
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1);
            DataTable dt1 = ds1.Tables[0];

            textBox_desc.Text = dt1.Rows[0][1].ToString();
            textBox_precio.Text = dt1.Rows[0][2].ToString();
            textBox_porc.Text = dt1.Rows[0][3].ToString();
            textBox_dias.Text = dt1.Rows[0][4].ToString();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (this.existe_Visibilidad(Convert.ToInt32(txtBx_CodVisib.Text)) == true)
            {
                DialogResult advertencia =
                    MessageBox.Show("¿Está seguro que desea eliminar la Visibilidad '" + txtBx_CodVisib.Text + "'?",
                    "Advertencia", MessageBoxButtons.YesNo); // Botonera de advertencia que se va a eliminar
                if (advertencia == DialogResult.Yes)
                {
                    //elimino usuario
                    this.eliminar_Visibilidad(Convert.ToInt32(txtBx_CodVisib.Text));
                    //muestro mensaje que fue eliminado
                    this.Hide();
                    MessageBox.Show("La Visibilidad ha sido eliminada.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            btn_Cargar_Click(sender, e);
        }






    }
}



