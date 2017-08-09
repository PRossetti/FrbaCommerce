using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class Prueba : Form1
    {
        public Prueba()
        {
            InitializeComponent();
        }

 
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion1 = this.crearConexion();
            SqlCommand comando = new SqlCommand("Insert into Cliente(ID, usuario, contrasena, nombre, apellido, edad) values(@ID, @usuario, @contrasena, @nombre, @apellido, @edad)", conexion1);
            comando.Parameters.AddWithValue("ID",textBox1.Text);
            comando.Parameters.AddWithValue("usuario",textBox2.Text);
            comando.Parameters.AddWithValue("contrasena",textBox3.Text);
            comando.Parameters.AddWithValue("nombre",textBox4.Text);
            comando.Parameters.AddWithValue("apellido",textBox5.Text);
            comando.Parameters.AddWithValue("edad",textBox6.Text);
            conexion1.Open();
            comando.ExecuteNonQuery();
            conexion1.Close();
        }
    }
}
