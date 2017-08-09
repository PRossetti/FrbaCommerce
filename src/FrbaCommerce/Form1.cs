using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Collections;
using System.Security.Cryptography;
using System.Configuration; // agregada

namespace FrbaCommerce
{
    public partial class Form1 : Form
    {
        private String stringDeConexion;
        private DateTime fecha;

        public Form1()
        {
            InitializeComponent();
            configurarDatosDeServidor();
        }

        private void configurarDatosDeServidor()
        {
            String lectura = ConfigurationManager.AppSettings["ConnectionString"];
            this.stringDeConexion = lectura;             
             /*
            String ruta = Application.StartupPath + @"\FRBACOMMERCE.txt";
            //hack para q el designer de las pantallas no falle.
            if (ruta.Contains("IDE")) return;
            //
            StreamReader archivo = new StreamReader(ruta, Encoding.ASCII);

            if ((lectura = archivo.ReadLine()) != null)
            {
                this.stringDeConexion = lectura;
            }

            archivo.Close();
            */
        }

        public SqlConnection crearConexion()
        {
            return new SqlConnection(this.stringDeConexion);
        }

        public DateTime obtenerFecha()
        {
            fecha = DateTime.ParseExact(ConfigurationManager.AppSettings["Fecha"], "dd/MM/yyyy", null);
            return fecha;
        }


        public Boolean existe_Usuario(string usuario)
        {
            // ADAPTADO A LA MIGRACION
            Boolean esta_en_tabla = false;
            string select = "SELECT usuario_user FROM BE_SHARPS.Usuarios where usuario_user ='" + usuario + "'";
            SqlConnection conexion1 = crearConexion();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion1);
            SqlCommand comando = new SqlCommand(select, conexion1);

            conexion1.Open();
            SqlDataReader lectura = comando.ExecuteReader();
            if (lectura.Read() == true)
            {
                esta_en_tabla = true;
            }
            conexion1.Close();

            return esta_en_tabla;
        }

        public ArrayList obtener_Datos_Usuario(string usuario)
        {

            string select = "SELECT usuario_user, usuario_pass, cli_nombre, cli_apellido, "
            + " cli_fec_nac, cli_doc_tipo, cli_doc_nro, cli_mail, cli_telefono, cli_dom_calle, "
            + " cli_nro_calle, cli_piso, cli_dpto, cli_cp, cli_localidad, usuario_habilitado FROM BE_SHARPS.Usuarios inner join BE_SHARPS.Clientes on u_cli_id = cli_id "
            + " where usuario_user = '" + usuario + "'";
            SqlConnection conexion1 = crearConexion();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion1);
            SqlCommand comando = new SqlCommand(select, conexion1);
            ArrayList lista = new ArrayList();

            conexion1.Open();
            SqlDataReader lectura = comando.ExecuteReader();
            if (lectura.Read() == true)
            {
                //Completo los campos de la tabla en la lista
                lista.Add(lectura.GetValue(0).ToString());  //Usuario (0)
                lista.Add(lectura.GetValue(1).ToString());  //Contraseña (1)
                lista.Add(lectura.GetValue(2).ToString());  //Nombre (2)
                lista.Add(lectura.GetValue(3).ToString());  //Apellido (3)
                lista.Add(lectura.GetValue(4).ToString());  //FechaNac (4)
                //--- Puede ser q le tenga q sacar el .ToString() y dejar el nativo
                lista.Add(lectura.GetValue(5).ToString());  //Tipo Doc (5)
                lista.Add(lectura.GetValue(6).ToString());  //Num Doc (6)
                lista.Add(lectura.GetValue(7).ToString());  //Mail (7)
                lista.Add(lectura.GetValue(8).ToString()); //Tel (8)
                lista.Add(lectura.GetValue(9).ToString()); //Domicilio Calle (9)
                lista.Add(lectura.GetValue(10).ToString()); //Domicilio Num (10)
                lista.Add(lectura.GetValue(11).ToString()); //Domicilio Piso (puede ser null) (11)
                lista.Add(lectura.GetValue(12).ToString()); //Domicilio Dpto (puede ser null) (12)
                lista.Add(lectura.GetValue(13).ToString()); //Cod Postal (13)
                lista.Add(lectura.GetValue(14).ToString()); //Localidad (14)
                lista.Add(lectura.GetValue(15).ToString()); //Habilitado (15)
            }
            else
            {
                lista = null;
            }
            conexion1.Close();
            return lista;
        }
        /*
        public ArrayList check_Usuario(string usuario)
        //checkea si existe el usuario: si existe devuelve un array con los datos sino devuelve null
        {
            
            string select = "SELECT * FROM Cliente where Usuario ='" + usuario + "'";
            SqlConnection conexion1 = crearConexion();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion1);
            SqlCommand comando = new SqlCommand(select, conexion1);
            ArrayList lista = new ArrayList();

            conexion1.Open();
            SqlDataReader lectura = comando.ExecuteReader();
            if (lectura.Read() == true)
            {
                lista.Add(lectura.GetValue(1).ToString());
                lista.Add(lectura.GetValue(2).ToString());
                lista.Add(lectura.GetValue(3).ToString());
                lista.Add(lectura.GetValue(4).ToString());
                //lista.Add(lectura.GetValue(5).ToString()); //Este ahora es una edad
                lista.Add(lectura.GetValue(6).ToString());
            }
            else
            {
                lista = null;
            }
            conexion1.Close();
            return lista;
        }
        */
        public void eliminar_Cliente(string usuario)
        {
            /*string delete = "DELETE FROM Cliente_Prueba WHERE cliente_usuario = '" + usuario + "'";
            SqlConnection conexion1 = crearConexion();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(delete, conexion1);
            SqlCommand comando = new SqlCommand(delete, conexion1);

            try
            {
                conexion1.Open();
                comando.ExecuteNonQuery();

            }

            finally
            {
                conexion1.Close();
            }*/
            // NUEVO ELIMINAR CLIENTE
            SqlConnection conexion = crearConexion();
            SqlCommand command = new SqlCommand("BE_SHARPS.eliminarCliente", conexion);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@cliente", usuario);

            try
            {
                conexion.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                conexion.Close();
            }
        }

        //se llama asi: ing.Parameters.AddWithValue("contrasena",SHA256Encripta(textBox3.Text));
        //o asi: cmd.Parameters.AddWithValue("@Contrasena", SHA256Encripta(this.textBox2.Text));
        public string SHA256Encripta(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }
        // ************ COMIENZO ABM VISIBILIDAD ************
        public bool existe_Visibilidad( int codigo )
        {
            string consulta = "SELECT COUNT(*) FROM BE_SHARPS.Visibilidad WHERE visib_cod='" + codigo + "'";
            SqlConnection conexion1 = this.crearConexion();
            //SqlDataAdapter DataAdapter = new SqlDataAdapter(consulta, conexion1);
            SqlCommand cmd = new SqlCommand(consulta, conexion1);

            conexion1.Open();
            int i = (int)cmd.ExecuteScalar();
            conexion1.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

               

        public ArrayList obtener_Datos_Visibilidad(int codigo)
        {
            string consulta = "SELECT * FROM BE_SHARPS.Visibilidad WHERE visib_cod='" + codigo + "'";
            SqlConnection con = this.crearConexion();
            //SqlDataAdapter DataAdapter = new SqlDataAdapter(consulta, con);
            SqlCommand cmd = new SqlCommand(consulta, con);            
            ArrayList datos = new ArrayList();

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            

            if (rdr.Read() == true)
            {
                datos.Add(rdr.GetValue(0).ToString()); //aca estaria el codigo que no lo voy a modificar
                datos.Add(rdr.GetValue(1).ToString()); // en datos[0] estaria la descripcion                
                datos.Add(rdr.GetValue(2).ToString()); // precio
                datos.Add(rdr.GetValue(3).ToString()); // porcentaje
            }
            else
            {
                rdr = null;
            }
            con.Close();
            return datos;
        }

        public int eliminar_Visibilidad(int codigo)
        {
            //string delete = "DELETE FROM BE_SHARPS.Visibilidad WHERE visib_cod='" + codigo + "'";
            string delete = "UPDATE BE_SHARPS.Visibilidad set visib_habilitada=0 WHERE visib_cod='" + codigo + "'";
            SqlConnection con = this.crearConexion();
            SqlCommand cmd = new SqlCommand(delete, con);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            
            return i;
        }

        // ************ FIN ABM VISIBILIDAD ************

        // ************ COMIENZO ABM ROL ************

        public Boolean existe_Rol(string rol)
        {
            Boolean esta_en_tabla = false;
            string select = "SELECT rol_nombre FROM BE_SHARPS.Roles where rol_nombre ='" + rol + "'";
            SqlConnection conexion1 = crearConexion();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion1);
            SqlCommand comando = new SqlCommand(select, conexion1);

            conexion1.Open();
            SqlDataReader lectura = comando.ExecuteReader();
            if (lectura.Read() == true)
            {
                esta_en_tabla = true;
            }
            conexion1.Close();

            return esta_en_tabla;
        }
        /*
        public ArrayList obtener_Datos_Rol(string rol)
        {

            string select = "SELECT rol_nombre FROM BE_SHARPS.Roles where rol_nombre ='" + rol + "'";
            SqlConnection conexion1 = crearConexion();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion1);
            SqlCommand comando = new SqlCommand(select, conexion1);
            ArrayList lista = new ArrayList();

            conexion1.Open();
            SqlDataReader lectura = comando.ExecuteReader();
            if (lectura.Read() == true)
            {
                //Completo los campos de la tabla en la lista
                lista.Add(lectura.GetValue(0).ToString());  //Rol id
                //lista.Add(lectura.GetValue(1).ToString());  //Rol nombre
            }
            else
            {
                lista = null;
            }
            conexion1.Close();
            return lista;
        }
        */
        public void eliminar_Rol(string rol)
        {
            string delete = "UPDATE BE_SHARPS.Roles SET rol_habilitado=0 where rol_nombre ='" + rol + "'";
            SqlConnection conexion1 = crearConexion();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(delete, conexion1);
            SqlCommand comando = new SqlCommand(delete, conexion1);

            try
            {
                conexion1.Open();
                comando.ExecuteNonQuery();

            }

            finally
            {
                conexion1.Close();
            }
        }
        

        // ************ FIN ABM ROL ************



        // **************** COMIENZO FUNCIONES GENERALES *****************

        public DataTable adaptador(string consulta)
        {
            SqlConnection con = this.crearConexion();
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, con);
            DataSet ds = new DataSet();

            adapter.Fill(ds);

            DataTable dt = ds.Tables[0];

            return dt;
        }

        public bool adaptador(string consulta, ref ListBox lista,string valueMember, string displayMember)
        {
            
            try
            {                
                DataTable dt = adaptador(consulta);

                lista.DataSource = dt;
                lista.ValueMember = valueMember;
                lista.DisplayMember = displayMember;
            }
            catch
            {
                return false;
            }

            return true;                        
        }

        public bool adaptador(string consulta, ref CheckedListBox lista, string valueMember, string displayMember)
        {

            try
            {
                DataTable dt = adaptador(consulta);

                lista.DataSource = dt;
                lista.ValueMember = valueMember;
                lista.DisplayMember = displayMember;
            }
            catch
            {
                return false;
            }

            return true;
        }


        public bool adaptador(string consulta, ref ListBox lista, string valueMember, string displayMember, ref DataTable dt)
        {

            try
            {
                dt = adaptador(consulta);

                lista.DataSource = dt;
                lista.ValueMember = valueMember;
                lista.DisplayMember = displayMember;
            }
            catch
            {
                return false;
            }

            return true;
        }

        // *********** FIN FUNCIONES GENERALES *************


        // PARA ABM EMPRESA (MODIFICADO 07/07/2014)

        public Boolean existe_Empresa(string usuario)
        {
            // ADAPTADO A LA MIGRACION
            Boolean esta_en_tabla = false;
            string select = "SELECT usuario_user FROM BE_SHARPS.Usuarios right join BE_SHARPS.Empresas on "
                + " u_emp_id = emp_id where usuario_user ='" + usuario + "'";
            SqlConnection conexion = crearConexion();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion);
            SqlCommand comando = new SqlCommand(select, conexion);

            conexion.Open();
            SqlDataReader lectura = comando.ExecuteReader();
            if (lectura.Read() == true)
            {
                esta_en_tabla = true;
            }
            conexion.Close();

            return esta_en_tabla;
        }


        public ArrayList obtener_Datos_Empresa(string usuario)
        {

            string select = "SELECT usuario_user, usuario_pass, emp_rsocial, emp_cuit, "
            + " emp_fec_creacion, emp_mail, emp_telefono, emp_dom_calle, "
            + " emp_nro_calle, emp_piso, emp_depto, emp_cp, emp_localidad, emp_contacto, usuario_habilitado "
            + " FROM BE_SHARPS.Usuarios inner join BE_SHARPS.Empresas on u_emp_id = emp_id "
            + " where usuario_user = '" + usuario + "'";
            SqlConnection conexion = crearConexion();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion);
            SqlCommand comando = new SqlCommand(select, conexion);
            ArrayList lista = new ArrayList();

            conexion.Open();
            SqlDataReader lectura = comando.ExecuteReader();
            if (lectura.Read() == true)
            {
                //Completo los campos de la tabla en la lista
                lista.Add(lectura.GetValue(0).ToString());  //Usuario (0)
                lista.Add(lectura.GetValue(1).ToString());  //Contraseña (1)
                lista.Add(lectura.GetValue(2).ToString());  //Razon Social (2)
                lista.Add(lectura.GetValue(3).ToString());  //Cuit(3)
                lista.Add(lectura.GetValue(4).ToString());  //FechaCreacion (4)
                lista.Add(lectura.GetValue(5).ToString());  //Mail (5)
                lista.Add(lectura.GetValue(6).ToString());  //Tel (6)
                lista.Add(lectura.GetValue(7).ToString());  //Domicilio Calle (7)
                lista.Add(lectura.GetValue(8).ToString()); //Domicilio Num (8)
                lista.Add(lectura.GetValue(9).ToString()); //Domicilio Piso (puede ser null) (9)
                lista.Add(lectura.GetValue(10).ToString()); //Domicilio Dpto (puede ser null) (10)
                lista.Add(lectura.GetValue(11).ToString()); //Cod Postal (11)
                lista.Add(lectura.GetValue(12).ToString()); //Localidad (12)
                lista.Add(lectura.GetValue(13).ToString()); //Contacto (13)
                lista.Add(lectura.GetValue(14).ToString()); //Habilitado (14)
                //FALTA CONTEMPLAR emp_ciudad
                //lista.Add(lectura.GetValue(14).ToString()); //Ciudad (14)

            }
            else
            {
                lista = null;
            }
            conexion.Close();
            return lista;
        }

        public void eliminar_Empresa(string usuario)
        {
            SqlConnection conexion = crearConexion();
            SqlCommand command = new SqlCommand("BE_SHARPS.eliminarEmpresa", conexion);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@empresa", usuario);

            try
            {
                conexion.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                conexion.Close();
            }
        }


        // FIN PARA ABM EMPRESA (MODIFICADO 07/07/2014)

        // **************** COMIENZO Editar Publicacion ************************

        public ArrayList obtener_Datos_Publicacion(int pub_cod)
        {

            string consulta = "SELECT pub_cod, pub_id_usuario, pub_visibilidad_cod, pub_desc, pub_stock, pub_fecha, pub_fec_venc, "
              + "pub_precio, pub_tipo, pub_estado, pub_preg_habilitadas FROM BE_SHARPS.Publicaciones WHERE pub_cod ='" + pub_cod + "'";


            SqlConnection con = this.crearConexion();
            SqlCommand cmd = new SqlCommand(consulta, con);

            ArrayList lista = new ArrayList();
            con.Open();
            SqlDataReader reader =  cmd.ExecuteReader();           

            if (reader.Read() == true) 
            {
                for (int i = 0; i < 11; i++) //va a ir de 0 a 10
                {
                    lista.Add(reader.GetValue(i).ToString());
                }            
            }
            else
            {
                lista = null;
            }          

            con.Close();
            return lista;
        }
        // **************** FIN Editar Publicacion ************************

        // ***************** AGREGADAS 10/07/2014 ************************
        /*public int obtenerClienteID(int usuario_id)
        {
            int cli_id;
            string consulta = "select u_cli_id from BE_SHARPS.Usuarios where usuario_id=" + usuario_id;
            SqlConnection con = this.crearConexion();
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds,"Usuario");

            cli_id = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            return cli_id;
        }*/

        public int obtenerUsuarioID(string user_name)
        {
            int user_id;
            string consulta = "SELECT usuario_id FROM BE_SHARPS.Usuarios where usuario_user='" + user_name + "'";
            SqlConnection con = this.crearConexion();
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds,"Usuario");

            user_id = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            return user_id;
        }


        public string obtenerUsuarioUser(int usuario_id)
        {
            string usuario_user;
            string consulta = "select usuario_user from BE_SHARPS.Usuarios where usuario_id=" + usuario_id;
            SqlConnection con = this.crearConexion();
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Usuario");

            usuario_user = ds.Tables[0].Rows[0][0].ToString();
            return usuario_user;

        }

    }
    
}
