using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace FrbaCommerce.Registro_de_Usuario
{
    public partial class Nuevo_Empresa : Form1
    {
        private string rol_de_nueva_empresa;
        public Nuevo_Empresa(string rol)
        {
            InitializeComponent();
            rol_de_nueva_empresa = rol;

            if (rol_de_nueva_empresa == "administrador")
            {
                label_Usuario.Hide();
                textBox_Usuario.Hide();
                label_Contraseña.Hide();
                textBox_Contrasena.Hide();
                label_RepContraseña.Hide();
                textBox_RepContrasena.Hide();
                button_Disponibilidad.Hide();
            }
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                }

            }
        }

        private void button_Registrarse_Click(object sender, EventArgs e)
        {
            bool datos_ok = true;
            if (!Regex.IsMatch(textBox_RazonSocial.Text, @"^[a-zA-Z\.\s]+$"))
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

            if (!Regex.IsMatch(textBox_Cuit.Text, @"^[0-9\-]+$"))
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

            if (!Regex.IsMatch(textBox_NombreContact.Text, @"^[a-zA-Z\s]+$"))
            {
                datos_ok = false;
                label_ErrorNombreContact.Text = "(*)";
            }
            else label_ErrorNombreContact.Text = "";

            //NOTA: Por ahi para el mail hay q hacer algo mas complicado
            //if (!Regex.IsMatch(textBox_Mail.Text, @"^[a-zA-Z0-9_.@]+$"))
            if (!Regex.IsMatch(textBox_Mail.Text, @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$"))
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

            if (!Regex.IsMatch(textBox_Domicilio.Text, @"^[a-zA-Z\.\s]+$"))
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
            if (rol_de_nueva_empresa == "empresa")
            {
                if (textBox_Contrasena.Text != textBox_RepContrasena.Text)
                {
                    datos_ok = false;
                    label_ErrorContrasena.Text = "(*)No coincide";
                    label_ErrorRepContrasena.Text = "(*)No coincide";
                }
                else
                {
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
                }
            }

            bool datos_usuario_ok = true;
            if (rol_de_nueva_empresa == "empresa")
            {
                if (textBox_Usuario.Text == "")
                {
                    datos_ok = false;
                    datos_usuario_ok = false;
                    label_Disponibilidad.Text = "(*) No permitido";
                    label_Disponibilidad.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    if (!Regex.IsMatch(textBox_Usuario.Text, @"^[a-zA-Z0-9_]+$"))
                    {
                        datos_ok = false;
                        datos_usuario_ok = false;
                        label_Disponibilidad.Text = "(*)";
                        label_Disponibilidad.ForeColor = System.Drawing.Color.Red;
                    }
                    else label_Disponibilidad.Text = "";
                }
            }

            //FIN CHECKEOS

            if ((datos_ok && rol_de_nueva_empresa == "administrador") || (datos_ok &&
                rol_de_nueva_empresa == "empresa" && usuario_Disponible(textBox_Usuario.Text)))
            {
                crear_Empresa();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                label_ErrorMensaje.Text = "(*) LOS CAMPOS TIENEN INFORMACION NO VÁLIDA";
                if (rol_de_nueva_empresa == "empresa" && !usuario_Disponible(textBox_Usuario.Text) && datos_usuario_ok)
                {

                    label_Disponibilidad.Text = "Ocupado";
                    label_Disponibilidad.ForeColor = System.Drawing.Color.Red;


                }
                else
                {
                    if (datos_usuario_ok) label_Disponibilidad.Text = "";
                }
            }


        }

        private void crear_Empresa()
        {
            SqlConnection conexion1 = this.crearConexion();
            SqlCommand cmd = new SqlCommand("BE_SHARPS.insertarEmpresa", conexion1);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@quien", rol_de_nueva_empresa);

            string usuario = "", contrasena = "";
            if (rol_de_nueva_empresa == "administrador")
            {
                //VER QUE HACER CON LO NUEVO QUE HICIERON LOS PIBES (POR AHI SOLO HACER UN IF SI ES CLIENTE)
                //usuario = generar_Usuario();
                //contrasena = generar_Contrasena();
                var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
                var random = new Random();
                var result = new string(
                    Enumerable.Repeat(chars, 8)
                              .Select(s => s[random.Next(s.Length)])
                              .ToArray());

                var random2 = new Random();
                var result2 = new string(
                    Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

                usuario = result;
                contrasena = result2;
                //contrasena = passSinEncriptar; 

                string check = "SELECT COUNT(*) FROM BE_SHARPS.Usuarios where usuario_user='" + usuario + "'";
                SqlConnection con1 = this.crearConexion();
                SqlCommand cmd1 = new SqlCommand(check, con1);
                con1.Open();
                int control = (int)cmd1.ExecuteScalar();
                con1.Close();
                int i = 0;
                while (control == 1)
                {
                    random = new Random();
                    result = new string(
                    Enumerable.Repeat(chars, 8)
                              .Select(s => s[random.Next(s.Length)])
                              .ToArray());
                    usuario = result;
                    check = "SELECT COUNT(*) FROM BE_SHARPS.Usuarios where usuario_user='" + usuario + "'";
                    cmd1 = new SqlCommand(check, con1);
                    con1.Open();
                    control = (int)cmd1.ExecuteScalar();
                    con1.Close();
                    if (i > 25)
                    {
                        MessageBox.Show("Se entro a un bucle infinito. Ocurrió algo inesperado");
                        break;
                    }
                    i++;
                }

            }
            else
            {
                usuario = textBox_Usuario.Text;
                contrasena = textBox_Contrasena.Text;
            }


            //OJO!!
            cmd.Parameters.AddWithValue("@username", usuario);
            cmd.Parameters.AddWithValue("@pass", SHA256Encripta(contrasena)); // encriptada
            //

            cmd.Parameters.AddWithValue("@fecha", obtenerFecha());
            cmd.Parameters.AddWithValue("@razon_social", textBox_RazonSocial.Text);
            cmd.Parameters.AddWithValue("@cuit", textBox_Cuit.Text);
            cmd.Parameters.Add("@fec_creacion", SqlDbType.Date).Value = dateTimePicker1.Value;//Fecha de nacimiento
            cmd.Parameters.AddWithValue("@nombre_contacto", textBox_NombreContact.Text);
            cmd.Parameters.AddWithValue("@mail", textBox_Mail.Text);
            cmd.Parameters.AddWithValue("@telefono", textBox_Telefono.Text);

            cmd.Parameters.AddWithValue("@dom_calle", textBox_Domicilio.Text);
            cmd.Parameters.AddWithValue("@nro_calle", textBox_DomicilioNum.Text);
            if (textBox_DomicilioPiso.Text == "")
                cmd.Parameters.AddWithValue("@piso", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@piso", textBox_DomicilioPiso.Text);
            if (textBox_DomicilioDpto.Text == "")
                cmd.Parameters.AddWithValue("@dpto", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@dpto", textBox_DomicilioDpto.Text);
            cmd.Parameters.AddWithValue("@cp", textBox_CodPost.Text);
            cmd.Parameters.AddWithValue("@localidad", textBox_Localidad.Text);

            //SqlParameter retornoUsuario = cmd.Parameters.Add("@usuario", SqlDbType.NVarChar,35);
            //retornoUsuario.Direction = ParameterDirection.Output;

            //SqlParameter retornoContrasena = cmd.Parameters.Add("@contrasena", SqlDbType.NVarChar,35);
            //retornoContrasena.Direction = ParameterDirection.Output;

            try
            {
                conexion1.Open();
                cmd.ExecuteNonQuery();
                //usuario = cmd.Parameters["@usuario"].Value.ToString();
                //contrasena = cmd.Parameters["@contrasena"].Value.ToString();
            }
            finally
            {
                conexion1.Close();
            }
            if (rol_de_nueva_empresa == "administrador")
            {

                MessageBox.Show("Su usuario es: " + usuario + "\n"
                                + "Su contraseña es: " + contrasena);
            }
            else MessageBox.Show("Se ha creado su usuario.");
        }


        private bool razonSocial_Disponible(string razon_social)
        {
            string select = "select COUNT(*) from BE_SHARPS.Empresas "
            + " where emp_rsocial like @razon_social";
            SqlConnection conexion1 = this.crearConexion();
            SqlCommand comando = new SqlCommand(select, conexion1);

            comando.Parameters.AddWithValue("@razon_social", razon_social);
            //comando.Parameters.AddWithValue("@usuario", textBox_Usuario.Text);
            conexion1.Open();
            int resultado = (int)comando.ExecuteScalar();
            conexion1.Close();

            bool disponibilidad = false;
            if (resultado == 0) disponibilidad = true;
            return disponibilidad;
        }

        private bool cuit_Disponible(string cuit)
        {
            string select = "select COUNT(*) from BE_SHARPS.Empresas "
            + " where emp_cuit like @cuit ";
            SqlConnection conexion1 = this.crearConexion();
            SqlCommand comando = new SqlCommand(select, conexion1);

            comando.Parameters.AddWithValue("@cuit", cuit);
            //comando.Parameters.AddWithValue("@usuario", textBox_Usuario.Text);
            conexion1.Open();
            int resultado = (int)comando.ExecuteScalar();
            conexion1.Close();

            bool disponibilidad = false;
            if (resultado == 0) disponibilidad = true;
            return disponibilidad;
        }

        private void button_Disponibilidad_Click(object sender, EventArgs e)
        {
            if (usuario_Disponible(textBox_Usuario.Text))
            {
                label_Disponibilidad.Text = "Disponible";
                label_Disponibilidad.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label_Disponibilidad.Text = "Ocupado";
                label_Disponibilidad.ForeColor = System.Drawing.Color.Red;
            }
        }

        private bool usuario_Disponible(string usuario)
        {
            if (usuario == "") return false;
            string select = "select COUNT(*) from BE_SHARPS.Usuarios where usuario_user like @usuario";
            SqlConnection conexion1 = this.crearConexion();
            SqlCommand comando = new SqlCommand(select, conexion1);
            //comando.Parameters.AddWithValue("@usuario", usuario);

            conexion1.Open();
            comando.Parameters.AddWithValue("@usuario", usuario);
            int resultado = (int)comando.ExecuteScalar();
            conexion1.Close();

            bool disponibilidad = false;
            if (resultado == 0) disponibilidad = true;

            return disponibilidad;
        }
    }
}
