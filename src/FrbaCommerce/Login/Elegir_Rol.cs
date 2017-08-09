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
    public partial class Elegir_Rol : Form1
    {
        private int usuario_id;
        public Elegir_Rol(DataTable dt, int user_id) // me llama Login.cs
        {
            InitializeComponent();

            usuario_id = user_id;
            string consulta = System.String.Empty;

            listBox1.DataSource = dt;
            listBox1.ValueMember = "urol_rolid";
            listBox1.DisplayMember = "rol_nombre";
        }

        private void button1_Click(object sender, EventArgs e)
        {                         
            if (listBox1.SelectedItem != null)
            {
                // no me funcionaba porque ponía SelectedValue !
                string[] arr_rol = new string[3];
                arr_rol[0] = listBox1.SelectedValue.ToString(); // rol_id
                arr_rol[1] = ((DataRowView)listBox1.Items[listBox1.SelectedIndex])["rol_nombre"].ToString(); // asi eeeessss rol_nombre                
                //arr_rol[1] = listBox1.SelectedItem.ToString();

                //string name = ((DataRowView)listBox1.Items[listBox1.SelectedIndex])["rol_nombre"].ToString();
                //MessageBox.Show("arr_rol[0]: " + arr_rol[0] + "\n arr_rol[1]: " + arr_rol[1]);

                Index.Cargar_Funciones C_F = new Index.Cargar_Funciones(arr_rol, usuario_id);
                this.Hide();
                C_F.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione un rol para continuar");
            }
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}
