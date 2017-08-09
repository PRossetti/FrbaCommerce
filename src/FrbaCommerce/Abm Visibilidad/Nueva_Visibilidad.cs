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

namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class Nueva_Visibilidad : Form1
    {
        public Nueva_Visibilidad()
        {
            InitializeComponent();

            label_ErrorCod.Text = "";
            label_ErrorDesc.Text = "";
            label_ErrorPrecio.Text = "";
            label_ErrorPorcentaje.Text = "";
            label_ErrorMensaje.Text = "";
            label_ErrorDias.Text = "";
        }

        // remake con procedimiento
        private void button_aceptar_Click(object sender, EventArgs e)
        {
            //CHECKEAR QUE TODOS LOS DATOS ESTAN BIEN (MISMO METODO PARA AGREGAR NUEVO!!!)

            bool datos_ok = true;

            int codigo;
            if (!int.TryParse(textBox_cod.Text, out codigo))
            {
                datos_ok = false;
                label_ErrorCod.Text = "(*)";
            }
            else label_ErrorCod.Text = "";


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

                SqlConnection conexion1 = this.crearConexion();
                SqlCommand cmd = new SqlCommand("BE_SHARPS.p_insertar_visib", conexion1);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@visib_cod", int.Parse(textBox_cod.Text));
                cmd.Parameters.AddWithValue("@visib_desc", textBox_desc.Text);
                cmd.Parameters.AddWithValue("@visib_precio", Decimal.Parse(textBox_precio.Text));
                cmd.Parameters.AddWithValue("@visib_porcentaje", Decimal.Parse(textBox_porc.Text));
                cmd.Parameters.AddWithValue("@visib_dias", double.Parse(textBox_dias.Text));

                int error = 0;
                conexion1.Open();
                try
                {
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
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Los datos no fueron insertados");
                }
                conexion1.Close();
            }
            else
            {
                label_ErrorMensaje.Text = "(*) LOS CAMPOS TIENEN INFORMACION NO VÁLIDA";
            }



            

            //MessageBox.Show("Operación realizada");

        }


        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }





        /* FUNCIONA
        private void button_aceptar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion1 = this.crearConexion();
            SqlCommand ing = new SqlCommand("INSERT into BE_SHARPS.Visibilidad(visib_desc, visib_precio," 
            + "visib_porcentaje) values(@visib_desc, @visib_precio, @visib_porcentaje)", conexion1);
            
            ing.Parameters.AddWithValue("@visib_desc", textBox_desc.Text);
            ing.Parameters.AddWithValue("@visib_precio", textBox_precio.Text);
            ing.Parameters.AddWithValue("@visib_porcentaje", textBox_porc.Text);
            
            conexion1.Open();
            ing.ExecuteNonQuery();
            MessageBox.Show("Se ingreso correctamente");
            conexion1.Close();
        }
        */
                   
    }
}
