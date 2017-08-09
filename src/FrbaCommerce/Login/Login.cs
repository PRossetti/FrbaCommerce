using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions; //agregada
using System.Data.SqlClient; // agregada


namespace FrbaCommerce.Login
{
    public partial class Login : Form1
    {   
        private int usuario_id;
        public Login()
        {
            InitializeComponent();
            label3.Text = "Aprete Actualizar para actualizar el estado \nde las publicaciones acorde a la fecha establecida";            
            label4.Text = "Espere un instante hasta que se termine la actualización...";
            label4.ForeColor = System.Drawing.Color.Red;
            label4.Hide();
            label5.Text = "";
            progressBar1.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_Registrarse_Click(object sender, EventArgs e)
        {
            Registro_de_Usuario.Tipo_Usuario T_U = new Registro_de_Usuario.Tipo_Usuario();
            //T_U.Show();
            this.Hide();
            T_U.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            //string pass = System.String.Empty; // creo que es lo mismo que asignarle ""
            
            //string consulta = "SELECT COUNT(*) from BE_SHARPS.Usuarios where usuario_user='" + txBx_user.Text + "' AND "
            //+ "usuario_pass='" + txBx_pass.Text + "'";
            
            string consulta1 = "SELECT usuario_id, usuario_user, usuario_pass, usuario_trys, usuario_last_login from BE_SHARPS.Usuarios " +
            "where usuario_habilitado=1 and usuario_user='" + txBx_user.Text + "'";

            SqlConnection con = this.crearConexion();
            SqlDataAdapter adapter = new SqlDataAdapter(consulta1, con);
            DataSet ds = new DataSet();
            
            adapter.Fill(ds, "Usuarios");
            DataTable dt = ds.Tables[0]; // esta tabla tiene 4 columnas(columns) y una fila(row)
            con.Open();
            
            int filas = 0;
            
            foreach (DataRow fila in dt.Rows) // para saber si me devuelve 1 o 0 filas. Seria como el executescalar
            {
                filas++;
            }

            if (filas == 1)
            {
                int trys = int.Parse(dt.Rows[0][3].ToString());
                //el usuario estaba en la base de datos, ahora debo chequear si tiene trys y luego
                // si la pass esta bien, sino restar trys

                usuario_id = int.Parse(dt.Rows[0][0].ToString());

                if (int.Parse(dt.Rows[0][3].ToString()) > 0) // si tiene intentos..
                {
                    
                    if (dt.Rows[0][2].ToString() == SHA256Encripta(txBx_pass.Text)) // si la contraseña es correcta [agregada la encriptacion]
                    {
                        /*
                        string consulta3 = "select COUNT(*) FROM BE_SHARPS.Publicaciones left join BE_SHARPS.PubliXItem_Factura on "
                        + "publitem_pub_cod=pub_cod inner JOIN BE_SHARPS.Compras on pub_cod=comp_pub_cod where publitem_pub_cod "
                        + "is null and pub_id_usuario="+usuario_id;
                         */
                        
                        string consulta3 = "select COUNT(pub_cod) FROM BE_SHARPS.Publicaciones, BE_SHARPS.Usuarios "
                        + " where pub_id_usuario = usuario_id and (pub_fec_venc < convert(datetime,'" + obtenerFecha() + "',103) or pub_estado = 'Finalizada') "
                        + " and not exists (select item_pub_cod from BE_SHARPS.Item_Factura where item_pub_cod = pub_cod) "
                        + " and usuario_id = " + dt.Rows[0][0]; // los pendientes de pagar

                        //SqlConnection con1 = this.crearConexion();
                        SqlDataAdapter adapter3 = new SqlDataAdapter(consulta3, con);
                        DataSet ds3 = new DataSet();
                        adapter3.Fill(ds3, "Compras");
                        int ventas_pendientes = int.Parse(ds3.Tables[0].Rows[0][0].ToString());
                        
                        if (ventas_pendientes <= 10)
                        {
                            MessageBox.Show("Login correcto");
                            // aca debo reiniciar los trys
                            string check = "SELECT COUNT(*) FROM BE_SHARPS.Usuarios where usuario_last_login is null and usuario_id=" + dt.Rows[0][0];
                            SqlCommand cmd2 = new SqlCommand(check, con);
                            int control = (int)cmd2.ExecuteScalar();

                            string update = "UPDATE BE_SHARPS.Usuarios SET usuario_trys=" + 3 + " , "
                            +"usuario_last_login=convert(datetime,'" + obtenerFecha() + "',103) where usuario_id=" + dt.Rows[0][0];
                            SqlCommand cmd = new SqlCommand(update, con);
                            cmd.ExecuteNonQuery(); // lo vuelvo a poner en 3

                            if (control == 1)
                            {
                                string update1 = "UPDATE BE_SHARPS.Usuarios SET usuario_habilitado=" + 0 + " where usuario_id=" + dt.Rows[0][0];
                                SqlCommand cmd3 = new SqlCommand(update1, con);
                                cmd3.ExecuteNonQuery();

                                this.Hide();
                                Registro_de_Usuario.Cambiar_Pass C_P = new Registro_de_Usuario.Cambiar_Pass(int.Parse(dt.Rows[0][0].ToString()));
                                C_P.ShowDialog();
                                this.Show();
                            }

                            // tengo que levantar los roles
                            

                            string consulta2 = "SELECT urol_uid, urol_rolid, rol_nombre FROM BE_SHARPS.Usuario_Rol, BE_SHARPS.Roles "
                            + "where rol_habilitado=1 and urol_rolid=rol_id and urol_uid=" + dt.Rows[0][0];

                            SqlDataAdapter adapter2 = new SqlDataAdapter(consulta2, con);
                            DataSet ds2 = new DataSet();
                            adapter2.Fill(ds2, "Usuario_Rol");
                            DataTable dt2 = ds2.Tables[0];


                            int roles = 0;
                            foreach (DataRow fila in dt2.Rows) // si no lo hago con foreach me tira error
                            {
                                roles++;
                            }

                            if (roles == 1)
                            {   // si entra por aca significa que tiene un solo rol

                                string[] arr_rol = new string[3];

                                arr_rol[0] = dt2.Rows[0][1].ToString(); // rol_id
                                arr_rol[1] = dt2.Rows[0][2].ToString(); // rol_nombre
                                //arr_rol[2] = dt2.Rows[0][0].ToString(); // usuario_id

                                Index.Cargar_Funciones C_F = new Index.Cargar_Funciones(arr_rol, usuario_id);
                                this.Hide();
                                C_F.ShowDialog();
                                this.Show();
                            }
                            else
                            {
                                Elegir_Rol E_R = new Elegir_Rol(dt2, usuario_id);
                                this.Hide();
                                E_R.ShowDialog();
                                this.Show();
                                //MessageBox.Show("Tiene más de un rol");
                            }
                        }
                        else // si tiene mas de 10 ventas pendientes
                        {
                            MessageBox.Show("Usuario inhabilitado. \n Dirijase a la oficina de administración para regularizar su situación.");
                            // aca debo pausar sus publicaciones                           
                            try
                            {
                                SqlCommand cmd4 = new SqlCommand("BE_SHARPS.pausarUser", con);
                                cmd4.CommandType = CommandType.StoredProcedure;
                                cmd4.Parameters.AddWithValue("@usuario_id", usuario_id);
                                cmd4.ExecuteNonQuery();
                            }
                            catch(SqlException ex)
                            {
                                SqlError err = ex.Errors[0];
                                MessageBox.Show(err.Message);
                            }
                            
                        }
                    }
                    else // si no es correcta
                    {
                        // aca debo descontar un try
                        string update = "UPDATE BE_SHARPS.Usuarios SET usuario_trys=usuario_trys-1 where usuario_id='"
                            + dt.Rows[0][0] + "'";
                        SqlCommand cmd = new SqlCommand(update, con); 
                        cmd.ExecuteNonQuery(); // aca resto uno
                        trys--;                        
                        MessageBox.Show("La contraseña ingresada es incorrecta. Le quedan " + trys +
                        " intentos");
                    }

                }
                else // si no tiene intentos
                {
                    MessageBox.Show("Ya no tiene intentos disponibles, su usuario ha sido deshabilitado. \n"
                        +"Contactese con un administrador");
                }           

            }
            else
            {
                MessageBox.Show("El Usuaro ingresado no existe o está deshabilitado");
            }
            
            con.Close();            

        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            /*string s_count = "select COUNT(*) from BE_SHARPS.Publicaciones where pub_fec_venc < convert(datetime,'"+obtenerFecha()+"',103)";
            SqlConnection con = this.crearConexion();
            SqlCommand cmd = new SqlCommand(s_count, con);
            con.Open();
            progressBar1.Maximum = (int)cmd.ExecuteScalar();
            con.Close();
            */
            progressBar1.Show();
            MessageBox.Show("Luego de aceptar esta ventana, comenzará la actualización.\nEspere. " 
            +"Un mensaje le informara cuando la misma haya finalizado. \nLa operación puede durar cerca de un minuto dependiendo de la fecha. \nEl programa podría dejar de respondar hasta que finalice la actualización.");
            label4.Show();

            string consulta = "select pub_cod from BE_SHARPS.Publicaciones where pub_estado<>'Finalizada' and "
            + "pub_fec_venc < convert(datetime,'" + obtenerFecha() + "',103)";

            SqlConnection con = this.crearConexion();
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Publicaciones");
            DataTable dt = ds.Tables[0];

            progressBar1.Maximum = dt.Rows.Count;
            string update;
            SqlCommand cmd;
            con.Open();
            for (int i = 0; i < progressBar1.Maximum; i++)
            {
                update = "UPDATE BE_SHARPS.Publicaciones set pub_estado='Finalizada' where pub_cod=" + dt.Rows[i][0];
                cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                progressBar1.Value = i + 1;
            }
            con.Close();
            label4.Show();
            label4.Text = "La actualización terminó correctamente";
            progressBar1.Hide();
            label4.ForeColor = System.Drawing.Color.Green;
           

            // voy a cambiar el estado de las pubs a Finalizada (si corresponde)
            /*
            string consulta = "UPDATE BE_SHARPS.Publicaciones set pub_estado='Finalizada' where pub_fec_venc < convert(datetime,'" + obtenerFecha() + "',103)";
            label4.Show();
            try
            {
                MessageBox.Show("Espere hasta que se termine la actualización\n Un mensaje le informara cuando finalice");
                SqlConnection con = this.crearConexion();
                SqlCommand cmd = new SqlCommand(consulta, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                label4.Show();
                label4.Text = "La actualización terminó correctamente";
                label4.ForeColor = System.Drawing.Color.Green;
            }
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                MessageBox.Show(err.Message);
                label4.Text = "Ocurrió un error, no pudo realizarse la actualización";
                label4.ForeColor = System.Drawing.Color.Red;
            }
            */
        }
    }
}
