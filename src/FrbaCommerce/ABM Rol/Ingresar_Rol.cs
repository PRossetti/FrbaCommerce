using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;

namespace FrbaCommerce.ABM_Rol
{
    public partial class Ingresar_Rol : Form1
    {
        string que_hago;

        public Ingresar_Rol(string modo)
        {
            que_hago = modo;
            InitializeComponent();

            SqlConnection con = this.crearConexion();
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT rol_nombre FROM BE_SHARPS.Roles", con);
            adapter.Fill(ds);
            this.listBox_Rol.DataSource = ds.Tables[0];
            this.listBox_Rol.DisplayMember = "rol_nombre";

        }

        private void btn_Siguiente_Click(object sender, EventArgs e)
        {
            switch (que_hago.ToLower())
            {
                case "modificar":

                    if (this.existe_Rol(listBox_Rol.Text) == true)
                    {
                        //ArrayList datos_Rol = this.obtener_Datos_Rol(listBox_Rol.Text);
                        Modificar_Rol M_R = new Modificar_Rol(listBox_Rol.Text);
                        this.Hide();
                        M_R.ShowDialog();
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("No existe el rol");
                    }


                    break;
                case "eliminar":
                    if (this.existe_Rol(listBox_Rol.Text) == true)
                    {
                        DialogResult advertencia =
                            MessageBox.Show("¿Está seguro que desea eliminar el Rol '" + listBox_Rol.Text + "' ?",
                            "Advertencia", MessageBoxButtons.YesNo); 
                        if (advertencia == DialogResult.Yes)
                        {
                            this.eliminar_Rol(listBox_Rol.Text);
                            this.Hide();
                            MessageBox.Show("El Rol ha sido eliminado.");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        //En otro caso dejo todo como está

                    }
                    else
                    {
                        MessageBox.Show("No existe el rol");
                    }
                    break;
            }
        }


        private void btn_Atras_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
