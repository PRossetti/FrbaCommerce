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
using System.Globalization;
using System.Text.RegularExpressions;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class Modificar_Cliente : Form1
    {
       

        public Modificar_Cliente(ArrayList datos_usuario)
        {
            InitializeComponent();
                //Completo los campos:
                textBox_Usuario.Text = datos_usuario[0].ToString();
                //textBox_Contrasena.Text = datos_usuario[1].ToString();
                //textBox_RepContrasena.Text = datos_usuario[1].ToString();
                textBox_Contrasena.Text = "";
                textBox_RepContrasena.Text = "";
                textBox_Nombre.Text = datos_usuario[2].ToString();
                textBox_Apellido.Text = datos_usuario[3].ToString();
                dateTimePicker_FechaNac.Value = Convert.ToDateTime(datos_usuario[4].ToString());
                comboBox_TipoDoc.Text = datos_usuario[5].ToString();
                textBox_NumDoc.Text = datos_usuario[6].ToString();
                textBox_Mail.Text = datos_usuario[7].ToString();
                textBox_Telefono.Text = datos_usuario[8].ToString();
                textBox_Domicilio.Text = datos_usuario[9].ToString();
                textBox_DomicilioNum.Text = datos_usuario[10].ToString();
                textBox_DomicilioPiso.Text = datos_usuario[11].ToString();
                textBox_DomicilioDpto.Text = datos_usuario[12].ToString();
                textBox_CodPost.Text = datos_usuario[13].ToString();
                textBox_Localidad.Text = datos_usuario[14].ToString();
                if (datos_usuario[15].ToString() == "True") checkBox_habilitarCli.Checked = true;
                else checkBox_habilitarCli.Checked = false;

        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_Listo_Click(object sender, EventArgs e)
        {

            bool datos_ok = true;
            //CHECKEAR QUE TODOS LOS DATOS ESTAN BIEN (MISMO METODO PARA AGREGAR NUEVO!!!)
            if (!Regex.IsMatch(textBox_Nombre.Text, @"^[a-zA-Z]+$"))
            {
                datos_ok = false;
                label_ErrorNombre.Text = "(*)";
            }
            else label_ErrorNombre.Text = "";

            if (!Regex.IsMatch(textBox_Apellido.Text, @"^[a-zA-Z]+$"))
            {
                datos_ok = false;
                label_ErrorApellido.Text = "(*)";
            }
            else label_ErrorApellido.Text = "";

            //Falta checkear si existe en la BD alguien con mismo tipo y numDoc
            if (!Regex.IsMatch(textBox_NumDoc.Text, @"^[0-9]+$"))
            {
                datos_ok = false;
                label_ErrorNumDoc.Text = "(*)";
            }
            else label_ErrorNumDoc.Text = "";
            
            //NOTA: Por ahi para el mail hay q hacer algo mas complicado
            //if (!Regex.IsMatch(textBox_Mail.Text, @"^[a-zA-Z0-9_.@]+$"))
            if (!Regex.IsMatch(textBox_Mail.Text, @"^[_a-zA-Z0-9-]+(\.[_a-zA-Z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$"))
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
            //Checkear telefono!!
            //El checkeo tiene q ser con otros usuarios!! no consigo mismo..
            if (!telefono_Disponible(textBox_Telefono.Text))
            {
                datos_ok = false;
                label_ErrorTel.Text = "(*)Ya es usado";
            }
            else label_ErrorTel.Text = "";

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
            

            if (datos_ok)
            {
                actualizar_Usuario();
            }
            else
            {
                label_ErrorMensaje.Text = "(*) LOS CAMPOS TIENEN INFORMACION NO VÁLIDA";
            }
        }

        private void actualizar_Usuario()
        {

            //MODIFICADO A NUEVA MIGRACION

            SqlConnection conexion = this.crearConexion();
            SqlCommand command = new SqlCommand("BE_SHARPS.modificarCliente", conexion);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@username", textBox_Usuario.Text);
            //command.Parameters.AddWithValue("@pass", SHA256Encripta(textBox_Contrasena.Text));
            if (textBox_Contrasena.Text == "") command.Parameters.AddWithValue("@pass", DBNull.Value);
            else command.Parameters.AddWithValue("@pass", SHA256Encripta(textBox_Contrasena.Text));
            command.Parameters.Add("@doc_tipo", SqlDbType.VarChar).Value = comboBox_TipoDoc.Text;
            command.Parameters.AddWithValue("@doc_nro", textBox_NumDoc.Text);
            command.Parameters.AddWithValue("@telefono", textBox_Telefono.Text);
            command.Parameters.AddWithValue("@apellido", textBox_Apellido.Text);
            command.Parameters.AddWithValue("@nombre", textBox_Nombre.Text);
            command.Parameters.Add("@fec_nac", SqlDbType.Date).Value = dateTimePicker_FechaNac.Value;//Fecha de nacimiento
            command.Parameters.AddWithValue("@mail", textBox_Mail.Text);
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
            command.Parameters.AddWithValue("@localidad", textBox_Localidad.Text);
            command.Parameters.AddWithValue("@cp", textBox_CodPost.Text);
            command.Parameters.AddWithValue("@habilitado", DbType.Boolean).Value = checkBox_habilitarCli.Checked;

            try
            {
                conexion.Open();
                command.ExecuteNonQuery();
                conexion.Close();
            }
            catch(SqlException ex)
            {
                SqlError err = ex.Errors[0];
                MessageBox.Show(err.Message);
            }


            this.Hide();
            MessageBox.Show("Se modifico correctamente");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool telefono_Disponible(string telefono)
        {
            string select = "select COUNT(*) from BE_SHARPS.Clientes inner join BE_SHARPS.Usuarios on u_cli_id = cli_id "
            + " where cli_telefono like @telefono AND usuario_user != @usuario";
            SqlConnection conexion1 = this.crearConexion();
            SqlCommand comando = new SqlCommand(select, conexion1);

            comando.Parameters.AddWithValue("@telefono", telefono);
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
