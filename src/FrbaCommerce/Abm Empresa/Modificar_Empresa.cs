using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace FrbaCommerce.Abm_Empresa
{
    public partial class Modificar_Empresa : Form1
    {
        public Modificar_Empresa(ArrayList datos_empresa)
        {
            InitializeComponent();
            textBox_Usuario.Text = datos_empresa[0].ToString();
            //textBox_Contrasena.Text = datos_empresa[1].ToString();
            //textBox_RepContrasena.Text = datos_empresa[1].ToString();
            textBox_Contrasena.Text = "";
            textBox_RepContrasena.Text = "";
            textBox_RazonSocial.Text = datos_empresa[2].ToString();
            textBox_Cuit.Text = datos_empresa[3].ToString();
            dateTimePicker1.Value = Convert.ToDateTime(datos_empresa[4].ToString());
            textBox_Mail.Text = datos_empresa[5].ToString();
            textBox_Telefono.Text = datos_empresa[6].ToString();
            textBox_Domicilio.Text = datos_empresa[7].ToString();
            textBox_DomicilioNum.Text = datos_empresa[8].ToString();
            textBox_DomicilioPiso.Text = datos_empresa[9].ToString();
            textBox_DomicilioDpto.Text = datos_empresa[10].ToString();
            textBox_CodPost.Text = datos_empresa[11].ToString();
            textBox_Localidad.Text = datos_empresa[12].ToString();
            textBox_NombreContact.Text = datos_empresa[13].ToString();
            if (datos_empresa[14].ToString() == "True") checkBox_habilitarEmp.Checked = true;
            else checkBox_habilitarEmp.Checked = false;
        }
        
        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        
        private void button_Listo_Click(object sender, EventArgs e)
        {
            bool datos_ok = true;
            // CHECKEO TIPO DE DATOS:
            if (!Regex.IsMatch(textBox_RazonSocial.Text, @"^[a-zA-Z.\s]+$"))
            {
                datos_ok = false;
                label_ErrorRazonSocial.Text = "(*)";
            }
            else
            {
                if (!razonSocial_Disponible(textBox_RazonSocial.Text))
                {
                    datos_ok = false;
                    label_ErrorRazonSocial.Text = "(*)Ya es usado";
                }
                else label_ErrorRazonSocial.Text = "";
            }
            
            //if (!Regex.IsMatch(textBox_Cuit.Text, @"^[0-9\-]+$"))
            if (!Regex.IsMatch(textBox_Cuit.Text, @"^\d{2}\-\d{8}\-\d{2}$$"))
            {
                datos_ok = false;
                label_ErrorCuit.Text = "(*)";
            }
            else
            {
                if (!cuit_Disponible(textBox_Cuit.Text))
                {
                    datos_ok = false;
                    label_ErrorCuit.Text = "(*)Ya es usado";
                }
                else label_ErrorCuit.Text = "";
            }

            if (!Regex.IsMatch(textBox_NombreContact.Text, @"^[a-zA-Z]+$"))
            {
                datos_ok = false;
                label_ErrorNombreContact.Text = "(*)";
            }
            else label_ErrorNombreContact.Text = "";

            //NOTA: Por ahi para el mail hay q hacer algo mas complicado
            //if (!Regex.IsMatch(textBox_Mail.Text, @"^[a-zA-Z0-9_.@]+$"))
            if (!Regex.IsMatch(textBox_Mail.Text, @"^[_a-zA-Z0-9-]+(\.[_a-zA-Z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$")) // PABLO
            {
                datos_ok = false;
                label_ErrorMail.Text = "(*)";
            }
            else label_ErrorMail.Text = "";

            if (!Regex.IsMatch(textBox_Telefono.Text, @"^[0-9]+$"))
            {
                datos_ok = false;
                label_ErrorTel.Text = "(*)";
            }
            else label_ErrorTel.Text = "";

            if (!Regex.IsMatch(textBox_Domicilio.Text, @"^[a-zA-Z.\s]+$"))
            {
                datos_ok = false;
                label_ErrorDomi.Text = "(*)";
            }
            else label_ErrorDomi.Text = "";

            if (!Regex.IsMatch(textBox_DomicilioNum.Text, @"^[0-9]+$"))
            {
                datos_ok = false;
                label_ErrorNum.Text = "(*)";
            }
            else label_ErrorNum.Text = "";

            if (!Regex.IsMatch(textBox_DomicilioPiso.Text, @"(^$)|(^[0-9]+$)")) //PUEDE SER NULL!!
            {
                datos_ok = false;
                label_ErrorPiso.Text = "(*)";
            }
            else label_ErrorPiso.Text = "";

            if (!Regex.IsMatch(textBox_DomicilioDpto.Text, @"(^$)|(^[a-zA-Z0-9]+$)")) //PUEDE SER NULL!!
            {
                datos_ok = false;
                label_ErrorDpto.Text = "(*)";
            }
            else label_ErrorDpto.Text = "";

            if (!Regex.IsMatch(textBox_CodPost.Text, @"^[0-9]+$"))
            {
                datos_ok = false;
                label_ErrorCodPost.Text = "(*)";
            }
            else label_ErrorCodPost.Text = "";

            if (!Regex.IsMatch(textBox_Localidad.Text, @"^[a-zA-Z]+$"))
            {
                datos_ok = false;
                label_ErrorLocalidad.Text = "(*)";
            }
            else label_ErrorLocalidad.Text = "";

            //Contraseñaa
            if (textBox_Contrasena.Text != textBox_RepContrasena.Text)
            {
                datos_ok = false;
                label_ErrorContrasena.Text = "(*)No coincide";
                label_ErrorRepContrasena.Text = "(*)No coincide";
            }
            else
            {
                label_ErrorContrasena.Text = "";
                label_ErrorRepContrasena.Text = "";
                /*
                if (textBox_Contrasena.Text == "") //Si no tienen nada
                {
                    datos_ok = false;
                    label_ErrorContrasena.Text = "(*) No permitido";
                    label_ErrorRepContrasena.Text = "(*) No permitido";
                }
                else
                {
                    label_ErrorContrasena.Text = "";
                    label_ErrorRepContrasena.Text = "";
                }
                */
            }

            //FIN CHECKEOS

            if (datos_ok)
            {
                actualizar_Empresa();
            }
            else
            {
                label_ErrorMensaje.Text = "(*) LOS CAMPOS TIENEN INFORMACION NO VÁLIDA";
            }

        }

        private void actualizar_Empresa()
        {
            
            SqlConnection conexion = this.crearConexion();
            SqlCommand command = new SqlCommand("BE_SHARPS.modificarEmpresa", conexion);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@username", textBox_Usuario.Text);
            //command.Parameters.AddWithValue("@pass", SHA256Encripta(textBox_Contrasena.Text));
            if (textBox_Contrasena.Text == "") command.Parameters.AddWithValue("@pass", DBNull.Value);
            else command.Parameters.AddWithValue("@pass", SHA256Encripta(textBox_Contrasena.Text));
            command.Parameters.AddWithValue("@razon_social", textBox_RazonSocial.Text);
            command.Parameters.AddWithValue("@cuit", textBox_Cuit.Text);
            command.Parameters.Add("@fec_creacion", SqlDbType.Date).Value = dateTimePicker1.Value;//Fecha de nacimiento
            command.Parameters.AddWithValue("@nombre_contacto", textBox_NombreContact.Text);
            command.Parameters.AddWithValue("@mail", textBox_Mail.Text);
            command.Parameters.AddWithValue("@telefono", textBox_Telefono.Text);

            command.Parameters.AddWithValue("@dom_calle", textBox_Domicilio.Text);
            command.Parameters.AddWithValue("@nro_calle", textBox_DomicilioNum.Text);
            if (textBox_DomicilioPiso.Text == "")
                command.Parameters.AddWithValue("@piso", DBNull.Value);
            else
                command.Parameters.AddWithValue("@piso", textBox_DomicilioPiso.Text);
            if (textBox_DomicilioDpto.Text == "")
                command.Parameters.AddWithValue("@dpto", DBNull.Value);
            else
                command.Parameters.AddWithValue("@dpto", textBox_DomicilioDpto.Text);
            command.Parameters.AddWithValue("@cp", textBox_CodPost.Text);
            command.Parameters.AddWithValue("@localidad", textBox_Localidad.Text);
            command.Parameters.AddWithValue("@habilitado", DbType.Boolean).Value = checkBox_habilitarEmp.Checked;



            try
            {
                conexion.Open();
                command.ExecuteNonQuery();
                conexion.Close();
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                MessageBox.Show(err.Message);
            }


            this.Hide();
            MessageBox.Show("Se modifico correctamente");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool razonSocial_Disponible(string razon_social)
        {
            string select = "select COUNT(*) from BE_SHARPS.Empresas inner join BE_SHARPS.Usuarios on u_emp_id = emp_id "
            + " where emp_rsocial like @razon_social AND usuario_user != @usuario";
            SqlConnection conexion1 = this.crearConexion();
            SqlCommand comando = new SqlCommand(select, conexion1);

            comando.Parameters.AddWithValue("@razon_social", razon_social);
            comando.Parameters.AddWithValue("@usuario", textBox_Usuario.Text);
            conexion1.Open();
            int resultado = (int)comando.ExecuteScalar();
            conexion1.Close();

            bool disponibilidad = false;
            if (resultado == 0) disponibilidad = true;
            return disponibilidad;
        }

        private bool cuit_Disponible(string cuit)
        {
            string select = "select COUNT(*) from BE_SHARPS.Empresas inner join BE_SHARPS.Usuarios on u_emp_id = emp_id "
            + " where emp_cuit like @cuit AND usuario_user != @usuario";
            SqlConnection conexion1 = this.crearConexion();
            SqlCommand comando = new SqlCommand(select, conexion1);

            comando.Parameters.AddWithValue("@cuit", cuit);
            comando.Parameters.AddWithValue("@usuario", textBox_Usuario.Text);
            conexion1.Open();
            int resultado = (int)comando.ExecuteScalar();
            conexion1.Close();

            bool disponibilidad = false;
            if (resultado == 0) disponibilidad = true;
            return disponibilidad;
        }
    }
}
