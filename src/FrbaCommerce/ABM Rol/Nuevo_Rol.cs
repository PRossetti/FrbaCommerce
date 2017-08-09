using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient; //agregada
using System.Text.RegularExpressions; //agregada

namespace FrbaCommerce.ABM_Rol
{
    public partial class Nuevo_Rol : Form1
    {
        public Nuevo_Rol()
        {
            InitializeComponent();
            //listBox1.SelectionMode = SelectionMode.MultiSimple; // para poder seleccionar multiples filas

            label_ErrorMensaje.Text = "";
            label_ErrorNombre.Text = "";
            
            string consulta = "select id, funcion from BE_SHARPS.t_funciones";
            SqlConnection con = this.crearConexion();
            SqlCommand cmd = new SqlCommand(consulta,con); // esta linea creo que esta de mas
            SqlDataAdapter adapter = new SqlDataAdapter(consulta,con);
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                adapter.Fill(ds);
                con.Close();

                listBox1.DataSource = ds.Tables[0];
                listBox1.ValueMember = "funcion";
                listBox1.DisplayMember = "funcion";
            }
            catch(Exception)
            {
                MessageBox.Show("No se puede abrir la conexión.");
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
            //int selectedIndex = listBox2.SelectedIndex;
            listBox2.Items.Remove(listBox2.SelectedItem);

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
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
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            bool datos_ok = true;
            //CHECKEAR QUE TODOS LOS DATOS ESTAN BIEN
            if (!Regex.IsMatch(txBx_Rol.Text, @"^[a-zA-Z]+$"))
            {
                datos_ok = false;
                label_ErrorNombre.Text = "(*)";
            }

            if (datos_ok)
            {
                label_ErrorMensaje.Text = "";
                label_ErrorNombre.Text = "";

                string insert1 = "INSERT INTO BE_SHARPS.Roles (rol_nombre, rol_habilitado) values (@rol,1)";
                string consulta = "SELECT rol_id FROM BE_SHARPS.Roles WHERE rol_nombre='" + txBx_Rol.Text + "'";
                SqlConnection con = this.crearConexion();
                SqlCommand cmd = new SqlCommand(insert1, con);

                cmd.Parameters.AddWithValue("@rol", txBx_Rol.Text);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    //SqlCommand cmd2 = new SqlCommand(consulta, con2);
                    //cmd2.Parameters.AddWithValue("@rolname", txBx_Rol.Text);
                    /*
                    SqlCommand cmd3 = new SqlCommand(consulta, con);
                    SqlDataReader rdr = cmd3.ExecuteReader();
                    */

                    SqlDataAdapter adapter = new SqlDataAdapter(consulta, con);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Roles");


                    //int id = (int)cmd2.ExecuteScalar(); esta solucion no me funciona
                    /*
                    int id;
                    if (rdr.Read() == true)
                    {
                        id = int.Parse(rdr.GetValue(0).ToString());
                        rdr.Close(); 
                    */

                    int id = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    for (int i = 0; i < listBox2.Items.Count; i++)
                    {
                        //insert2 = "INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) values ('" + id + "', '" + listBox2.Items[i] + "'";

                        SqlCommand cmd2 = new SqlCommand("BE_SHARPS.insertarRol_Funcion", con);
                        cmd2.CommandType = CommandType.StoredProcedure;

                        cmd2.Parameters.AddWithValue("@id", id);
                        cmd2.Parameters.AddWithValue("funcion", listBox2.Items[i]);
                        con.Open();
                        cmd2.ExecuteNonQuery();
                        con.Close();

                    }
                    MessageBox.Show("Datos cargados exitosamente.");
                    this.Close();
                    //} es la llave de cierre del if (rdr.Read()==true) 
                }
                catch (SqlException ex)
                {
                    SqlError err = ex.Errors[0];
                    MessageBox.Show("[SQL-ERROR] "+err.Message.ToString());
                }              

            }
            else
            {
                label_ErrorMensaje.Text = "(*) LOS CAMPOS TIENEN INFORMACION NO VÁLIDA";
            }
                       
        }

    }
}
