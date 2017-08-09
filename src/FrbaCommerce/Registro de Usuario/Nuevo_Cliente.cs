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
    public partial class Nuevo_Cliente : Form1
    {
        string rol_de_nuevo_cliente;
        
        public Nuevo_Cliente(string rol)
        {
  
            InitializeComponent();
            comboBox_TipoDoc.SelectedIndex = 0;
            rol_de_nuevo_cliente = rol;
            
            if(rol_de_nuevo_cliente == "administrador")
            {
                label_Usuario.Hide();
                textBox_Usuario.Hide();
                label_Contrasena.Hide();
                textBox_Contrasena.Hide();
                label_RepContrasena.Hide();
                textBox_RepContrasena.Hide();
                button_Disponibilidad.Hide();
            }

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

                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 0;
                }

                if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                }
            }
            dateTimePicker1.Value = DateTime.Today;

            //Limpiar los labels de errores
            label_Disponibilidad.Text = "";
            label_ErrorContrasena.Text = "";
            label_ErrorRepContrasena.Text = "";
            label_ErrorNombre.Text = "";
            label_ErrorApellido.Text = "";
            label_ErrorNumDoc.Text = "";
            label_ErrorMail.Text = "";
            label_ErrorTel.Text = "";
            label_ErrorDomi.Text = "";
            label_ErrorNum.Text = "";
            label_ErrorPiso.Text = "";
            label_ErrorDpto.Text = "";
            label_ErrorCodPost.Text = "";
            label_ErrorLocalidad.Text = "";

        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            //Login.Form1 L_F = new Login.Form1();
            //L_F.Show();
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void button_Registrarse_Click(object sender, EventArgs e)
        {
            bool datos_ok = true;

            //Checkeo todos los campos

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
            if (!Regex.IsMatch(textBox_Mail.Text, @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$")) 
            {
                datos_ok = false;
                label_ErrorMail.Text = "(*)";
            }
            else label_ErrorMail.Text = "";
            /*
             if (!Regex.IsMatch(textBox_Telefono.Text, @"^[0-9]+$"))
             {
                 datos_ok = false;
                 label_ErrorTel.Text = "(*)";
             }
             else label_ErrorTel.Text = "";
             */
            if (!Regex.IsMatch(textBox_Domicilio.Text, @"^[a-zA-Z.\s]+$"))
            {
                datos_ok = false;
                label_ErrorDomi.Text = "(*)";
            }
            else label_ErrorDomi.Text = "";

            if (!Regex.IsMatch(textBox_NumDom.Text, @"^[0-9]+$"))
            {
                datos_ok = false;
                label_ErrorNum.Text = "(*)";
            }
            else label_ErrorNum.Text = "";

            if (!Regex.IsMatch(textBox_Piso.Text, @"(^$)|(^[0-9]+$)")) //PUEDE SER NULL!!
            {
                datos_ok = false;
                label_ErrorPiso.Text = "(*)";
            }
            else label_ErrorPiso.Text = "";

            if (!Regex.IsMatch(textBox_Dpto.Text, @"(^$)|(^[a-zA-Z0-9]+$)")) //PUEDE SER NULL!!
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

            //Si no es administrador (cliente)
            bool datos_usuario_ok = true;
            if (rol_de_nuevo_cliente == "cliente")
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
                //Contraseñaa
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

            //Fin de checkeo de TIPO DE DATOS

            //Checkeo de telefono

            if (!telefono_Disponible(textBox_Telefono.Text))
            {
                datos_ok = false;
                label_ErrorTel.Text = "(*)Ya es usado";
            }
            else
            {
                if (!Regex.IsMatch(textBox_Telefono.Text, @"^[0-9]+$"))
                {
                    datos_ok = false;
                    label_ErrorTel.Text = "(*)";
                }
                else label_ErrorTel.Text = "";
            };



            if ((datos_ok && rol_de_nuevo_cliente == "administrador") || (datos_ok &&
                rol_de_nuevo_cliente == "cliente" && usuario_Disponible(textBox_Usuario.Text)))
            {
                registrar_Usuario();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                label_ErrorMensaje.Text = "(*) LOS CAMPOS TIENEN INFORMACION NO VÁLIDA";
                if (rol_de_nuevo_cliente == "cliente" && !usuario_Disponible(textBox_Usuario.Text) && datos_usuario_ok)
                {

                    label_Disponibilidad.Text = "Ocupado";
                    label_Disponibilidad.ForeColor = System.Drawing.Color.Red;


                }
                else if (datos_usuario_ok) label_Disponibilidad.Text = "";
            }

            //Hacer algo si no puede registrar el usuario

        }

        private void registrar_Usuario()
        {   

            SqlConnection conexion1 = this.crearConexion();
            SqlCommand cmd = new SqlCommand("BE_SHARPS.insetarCliente", conexion1);
            cmd.CommandType = CommandType.StoredProcedure;

            
            cmd.Parameters.AddWithValue("@quien",rol_de_nuevo_cliente);

            string usuario = "", contrasena = "";
            if (rol_de_nuevo_cliente == "administrador")
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
            cmd.Parameters.AddWithValue("@username",usuario);
            cmd.Parameters.AddWithValue("@pass",SHA256Encripta(contrasena)); //agrego encriptacion
            //
            cmd.Parameters.AddWithValue("@fecha", obtenerFecha());
            cmd.Parameters.Add("@doc_tipo", SqlDbType.VarChar).Value = comboBox_TipoDoc.Text;
            cmd.Parameters.AddWithValue("@doc_nro",textBox_NumDoc.Text);
            cmd.Parameters.AddWithValue("@telefono",textBox_Telefono.Text);
            cmd.Parameters.AddWithValue("@apellido",textBox_Apellido.Text);
            cmd.Parameters.AddWithValue("@nombre",textBox_Nombre.Text);
            cmd.Parameters.Add("@fec_nac", SqlDbType.Date).Value = dateTimePicker1.Value;//Fecha de nacimiento
            cmd.Parameters.AddWithValue("@mail",textBox_Mail.Text);
            cmd.Parameters.AddWithValue("@dom_calle",textBox_Domicilio.Text);
            cmd.Parameters.AddWithValue("@nro_calle",textBox_NumDom.Text);
            if (textBox_Piso.Text == "")
                cmd.Parameters.AddWithValue("@piso", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@piso",textBox_Piso.Text);
            if (textBox_Dpto.Text == "")
                cmd.Parameters.AddWithValue("@dpto", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@dpto",textBox_Dpto.Text);
            cmd.Parameters.AddWithValue("@localidad",textBox_Localidad.Text);
            cmd.Parameters.AddWithValue("@cp", textBox_CodPost.Text);

             
            try
            {
                conexion1.Open();
                cmd.ExecuteNonQuery();
                conexion1.Close();
                if (rol_de_nuevo_cliente == "administrador")
                {
                    //MessageBox.Show("Parece que todo ok");
                    MessageBox.Show("Su usuario es: " + usuario + "\nSu contraseña es: " + contrasena);
                }
                else MessageBox.Show("Se registró correctamente.");
            }
            catch(SqlException ex)
            {
                SqlError err = ex.Errors[0];
                MessageBox.Show(err.Message);
            }
          
        }
        
        private string generar_Usuario()
        {
            string user = "be_sharp_";
            string select = "select COUNT(*) from BE_SHARPS.Usuarios where usuario_user like 'be_sharp_%'";
            int count = 1;
            SqlConnection conexion1 = this.crearConexion();
            SqlCommand comando = new SqlCommand(select, conexion1);    

            conexion1.Open();
            count += (int)comando.ExecuteScalar();
            conexion1.Close();

            string userAux = user + count.ToString();
            while (!usuario_Disponible(userAux))
            {
                count++;
                userAux = user + count.ToString();
            }
            // Verificar x si las dudas q no exista ya creado en el sistema 
            //(algun hijo de puta dando vueltas) -> ir incrementando hasta q este disponible

            return userAux;
        }
        
        private string generar_Contrasena()
        {
            //Contraseña de 8 digitos random
            Random random = new Random();
            int pass = random.Next(100000000);
            return pass.ToString();
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

        private bool telefono_Disponible(string telefono)
        {
            string select = "select COUNT(*) from BE_SHARPS.Clientes where cli_telefono like @telefono";
            SqlConnection conexion1 = this.crearConexion();
            SqlCommand comando = new SqlCommand(select, conexion1);

            comando.Parameters.AddWithValue("@telefono", telefono);
            conexion1.Open();
            int resultado = (int)comando.ExecuteScalar();
            conexion1.Close();

            bool disponibilidad = false;
            if (resultado == 0) disponibilidad = true;
            return disponibilidad;
        }

        /*
          private bool telefono_Disponible(string telefono)
            {
            string select = "select COUNT(*) from Cliente_Prueba where cliente_telefono like @telefono";
            SqlConnection conexion1 = this.crearConexion();
            SqlCommand comando = new SqlCommand(select, conexion1);

            comando.Parameters.AddWithValue("@telefono", telefono);
            conexion1.Open();
            int resultado = (int)comando.ExecuteScalar();
            conexion1.Close();

            bool disponibilidad = false;
            if (resultado == 0) disponibilidad = true;
            return disponibilidad;
            }
         */
    }
}