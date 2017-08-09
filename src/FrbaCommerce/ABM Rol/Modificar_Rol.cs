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
using System.Text.RegularExpressions; 

namespace FrbaCommerce.ABM_Rol
{
    
    public partial class Modificar_Rol : Form1
    {
         private string rol; // que feo
         private DataTable dt2;
         private DataTable dt1;

         public Modificar_Rol(string rol_nombre)
        {
            InitializeComponent();
            txBx_Rol.Text = rol_nombre;
            rol = rol_nombre;
            label_ErrorRol.Text = "";
            label_MsjRevisar.Text = "";
            label_Habilitado.Text = "";

            btn_Habilitar.Hide();
            btn_Deshabilitar.Hide();
            

            SqlConnection con = this.crearConexion();

            string consulta = "select id, funcion as rfun_fun from BE_SHARPS.t_funciones"; // CLAVE, gracias al as rfun_fun me funciona :D!
            //SqlCommand cmd = new SqlCommand(consulta,con); // esta linea creo que esta de mas
            SqlDataAdapter adapter = new SqlDataAdapter(consulta,con);
            DataSet ds = new DataSet();

            /*
             * Bloque comentado que serviria para llenar la listBox2 con las funciones que ya posee.
             * Obviamente esta desordenado, lo junte todo aca para no tener comentarios por todos lados.                           
             */
            
            string consulta2 = "select rfun_rol_id, rfun_fun, rol_habilitado FROM BE_SHARPS.Rol_Funcion, BE_SHARPS.Roles where rfun_rol_id = rol_id and rol_nombre ='" + rol + "'";

            //SqlCommand cmd2 = new SqlCommand(consulta2, con);
            SqlDataAdapter adapter2 = new SqlDataAdapter(consulta2, con);
            DataSet ds2 = new DataSet(); 
                          

            try
            {
                adapter.Fill(ds);
                adapter2.Fill(ds2, "Rol_Funcion");
                
                dt1 = ds.Tables[0];
                listBox1.DataSource = dt1;
                listBox1.ValueMember = "rfun_fun";
                listBox1.DisplayMember = "rfun_fun";
                
                dt2 = ds2.Tables[0];
                listBox2.DataSource = dt2;
                listBox2.ValueMember = "rfun_fun";
                listBox2.DisplayMember = "rfun_fun";  

            }
            catch(Exception)
            {
                MessageBox.Show("No se puede abrir la conexión");
            }
            
            
            if (bool.Parse(dt2.Rows[0][2].ToString()) == false)// tengo que usar bool porque es de tipo bit, aca tengo si esta habilitado o no 
            {
                btn_Habilitar.Show();
                label_Habilitado.Text = "El rol está deshabilitado";
                label_Habilitado.ForeColor = System.Drawing.Color.Red; 
            }
            else
            {
                btn_Deshabilitar.Show();
                label_Habilitado.Text = "El rol está habilitado";
                label_Habilitado.ForeColor = System.Drawing.Color.Green; 
            }



        }
        /*
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Add("hola");

        }
        */

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            DataRowView rowView = listBox2.SelectedItem as DataRowView;

            if (null == rowView)
            {
                return;
            }

            dt2.Rows.Remove(rowView.Row);
            //listBox2.Items.Remove(listBox2.SelectedItem);
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool no_esta = true;

            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                if (((DataRowView)listBox2.Items[i])["rfun_fun"].ToString() == listBox1.SelectedValue.ToString())
                {
                    MessageBox.Show("Ya esta en la lista");
                    no_esta = false;
                    break;
                }
            }

            if (no_esta)
            {
                DataRowView rowView1 = listBox1.SelectedItem as DataRowView;
                if (null == rowView1)
                {
                    return;
                }
                dt2.ImportRow(rowView1.Row);
            }
            
            /*
            bool no_esta = true;
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                //listBox2.SelectedIndex = i;
                if (listBox1.SelectedValue == listBox2.Items[i])
                {
                    no_esta = false;
                    break;
                }
            }
                if(no_esta)listBox2.Items.Add(listBox1.SelectedValue);
            */
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            bool datos_ok = true;
            if (!Regex.IsMatch(txBx_Rol.Text, @"^[a-zA-Z]+$"))
            {
                datos_ok = false;                
            }
            else
            {
                label_ErrorRol.Text = "";
                label_MsjRevisar.Text = "";
            }
                



            if (datos_ok == false)
            {
                label_ErrorRol.Text = "(*)";
                label_MsjRevisar.Text = "(*) LOS CAMPOS TIENEN INFORMACIÓN NO VÁLIDA";
            }
            else
            {
                string delete = "DELETE BE_SHARPS.Rol_Funcion FROM BE_SHARPS.Rol_Funcion INNER JOIN BE_SHARPS.Roles on rfun_rol_id = rol_id and rol_nombre ='" + rol.ToString() + "'";
               
                
                //string insert1 = "INSERT INTO BE_SHARPS.Roles (rol_nombre) values (@rol)"; ESTE NO LO USO MAS, PREGUNTARME DESPUES POR QUE (LUCAS)
                
                string consulta = "SELECT rol_id FROM BE_SHARPS.Roles WHERE rol_nombre='" + rol + "'";

                SqlConnection con = this.crearConexion();




                if (datos_ok == true)
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(delete, con);
                    SqlCommand cmd = new SqlCommand(delete, con);

                    SqlDataAdapter adapter = new SqlDataAdapter(consulta, con);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Roles");

                    con.Open();
                    cmd.ExecuteNonQuery();

                    if (listBox2.Items.Count > 0)
                    {
                        int id = int.Parse(ds.Tables[0].Rows[0][0].ToString());

                        for (int i = 0; i < listBox2.Items.Count; i++)
                        {
                            //insert2 = "INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) values ('" + id + "', '" + listBox2.Items[i] + "'";

                            SqlCommand cmd2 = new SqlCommand("BE_SHARPS.insertarRol_Funcion", con);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            //MessageBox.Show("id: " + id + " funcion: " + ((DataRowView)listBox2.Items[i])["rfun_fun"]);
                            cmd2.Parameters.AddWithValue("@id", id);
                            cmd2.Parameters.AddWithValue("funcion", ((DataRowView)listBox2.Items[i])["rfun_fun"]); // estaba mal esta linea
                            cmd2.ExecuteNonQuery();
                            
                        }
                    }
                    con.Close();
                    MessageBox.Show("Datos cargados exitosamente.");
                    this.Close();

                }

                if (txBx_Rol.Text != rol) // para actualizar el nombre
                {
                    try
                    {
                        string update = "UPDATE BE_SHARPS.Roles SET rol_nombre='" + txBx_Rol.Text + "' where rol_nombre='" + rol + "'";
                        SqlCommand cmd3 = new SqlCommand(update, con);
                        con.Open();
                        cmd3.ExecuteNonQuery();
                        con.Close();
                        datos_ok = true;
                    }
                    catch (SqlException ex)
                    {
                        datos_ok = false;
                        SqlError err = ex.Errors[0];
                        MessageBox.Show("[SQL-ERROR] " + err.Message.ToString());
                        label_MsjRevisar.Text = "Ocurrió un error";
                    }

                }

                
            }
            //} es la llave de cierre del if (rdr.Read()==true)            
                       
        }

        private void btn_Habilitar_Click(object sender, EventArgs e)
        {
            string update = "UPDATE BE_SHARPS.Roles set rol_habilitado=1 where rol_nombre='" + rol + "'";
            SqlConnection con = this.crearConexion();
            SqlCommand cmd = new SqlCommand(update,con );
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            label_Habilitado.Text = "El rol ahora está habilitado";
            label_Habilitado.ForeColor = System.Drawing.Color.Green; 
            MessageBox.Show("El rol ha sido habilitado. Para realizar modificaciones en las funcionalidades, realizelos y haga clic en Cargar. De lo contrario, haga clic en Cerrar.");
            btn_Deshabilitar.Show();
            btn_Habilitar.Hide();
        }

        private void btn_Deshabilitar_Click(object sender, EventArgs e)
        {
            string update = "UPDATE BE_SHARPS.Roles set rol_habilitado=0 where rol_nombre='" + rol + "'";
            SqlConnection con = this.crearConexion();
            SqlCommand cmd = new SqlCommand(update, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            label_Habilitado.Text = "El rol ahora está deshabilitado";
            label_Habilitado.ForeColor = System.Drawing.Color.Red;
            MessageBox.Show("El rol ha sido deshabilitado. Para realizar modificaciones en las funcionalidades, realizelos y haga clic en Cargar. De lo contrario, haga clic en Cerrar.");
            btn_Habilitar.Show();
            btn_Deshabilitar.Hide();
        }

    }
}
