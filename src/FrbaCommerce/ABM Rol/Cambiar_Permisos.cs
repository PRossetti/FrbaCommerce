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
    public partial class Cambiar_Permisos : Form1
    {
        public int user_id; // que feo
        public DataTable dt1; // horible
        public DataTable dt2; // horible
        public Cambiar_Permisos(int usuario_id)
        {            
            InitializeComponent();

            user_id = usuario_id;
            string consulta2 = "SELECT rol_id, rol_nombre FROM BE_SHARPS.Usuario_Rol, BE_SHARPS.Roles where rol_habilitado=1 "
            +"and rol_id = urol_rolid and urol_uid=" + usuario_id;
            string consulta1 = "SELECT rol_id, rol_nombre FROM BE_SHARPS.Roles where rol_habilitado=1";
            SqlConnection con = this.crearConexion();
            
            con.Open();
            SqlDataAdapter adapter1 = new SqlDataAdapter(consulta1, con);
            SqlDataAdapter adapter2 = new SqlDataAdapter(consulta2, con);
            
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();

            adapter1.Fill(ds1, "Roles");
            adapter2.Fill(ds2, "Roles");
            
            con.Close();
            dt1 = ds1.Tables[0]; // lo declare afuera
            dt2 = ds2.Tables[0];           
            
            listBox1.DataSource = dt1;
            listBox1.ValueMember = "rol_id";
            listBox1.DisplayMember = "rol_nombre";
            
            listBox2.DataSource = dt2;
            listBox2.ValueMember = "rol_id";
            listBox2.DisplayMember = "rol_nombre";
            
            /*
            foreach (DataRow fila in dt2.Rows)
            {
                listBox2.Items.Add(fila[1]);                
            }
             */

        }
        
        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Quitar_Click(object sender, EventArgs e)
        {
            DataRowView rowView = listBox2.SelectedItem as DataRowView;

            if (null == rowView)
            {
                return;
            }

            dt2.Rows.Remove(rowView.Row);
            //listBox2.Items.Remove(listBox2.SelectedItem);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            bool no_esta = true;

            //MessageBox.Show("items: " + listBox2.Items.Count);
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                //if (listBox1.SelectedValue == listBox2.Items[i])            
                //MessageBox.Show(((DataRowView)listBox2.Items[i])["rol_id"] + "=" + listBox1.SelectedValue);
                if (((DataRowView)listBox2.Items[i])["rol_id"].ToString() == listBox1.SelectedValue.ToString())
                {
                    MessageBox.Show("Ya está en la lista.");
                    no_esta = false;
                    break;
                }
            }
            //if (no_esta) listBox2.Items.Add(listBox1.SelectedValue);
            
            if (no_esta)
            {
                DataRowView rowView1 = listBox1.SelectedItem as DataRowView;
                if (null == rowView1)
                {
                    return;
                }
                dt2.ImportRow(rowView1.Row);
            }
            
                //listBox2.Items.Add(((DataRowView)listBox1.Items[listBox1.SelectedIndex])["rol_nombre"].ToString());

        }

        private void btn_Aplicar_Click(object sender, EventArgs e)
        {
            //int rol_id=0;
            string insert = System.String.Empty; // = ""
            string delete = "delete BE_SHARPS.Usuario_Rol where urol_uid =" + user_id;
            SqlConnection con = this.crearConexion();

            SqlCommand cmd2 = new SqlCommand(delete, con);
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();

            for (int i = 0; i < listBox2.Items.Count ; i++ )
            {
                insert = "INSERT INTO BE_SHARPS.Usuario_Rol (urol_uid, urol_rolid) VALUES (" + user_id + ", " 
                    + ((DataRowView)listBox2.Items[i])["rol_id"] + ")";
                                    
                SqlCommand cmd = new SqlCommand(insert, con);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch(SqlException ex)
                {
                    SqlError err = ex.Errors[0];
                    string mensaje = string.Empty;
                    switch (err.Number)
                    {
                        case 3609:
                            mensaje = "[Trigger] El usuario ya tenía asignado el rol: " + ((DataRowView)listBox2.Items[i])["rol_nombre"];
                            break;
                        default:
                            mensaje = "Error SQL: " + err.Number.ToString();
                            break;
                    }
                    MessageBox.Show(mensaje);
                }                    
                con.Close();                
            }

            MessageBox.Show("Los cambios han sido aplicados.");
            this.DialogResult = DialogResult.OK;
            this.Close();

        }



    }
}
