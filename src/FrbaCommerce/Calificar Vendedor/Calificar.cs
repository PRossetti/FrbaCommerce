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

namespace FrbaCommerce.Calificar_Vendedor
{
    public partial class Calificar : Form1
    {
        private DataTable dt;
        public Calificar(int usuario_id)
        {
            InitializeComponent();
            
            SqlConnection con = this.crearConexion();

            string pubSinCalificar = "select compra_id as compra, pub_desc as descripcion, comp_vendedor_id as vendedor, " 
			+ "compra_fec as fecha_compra FROM BE_SHARPS.Compras, "
            + "BE_SHARPS.Publicaciones where pub_cod = comp_pub_cod and comp_calif_cod IS NULL and comp_comprador_id =" + usuario_id;

            SqlDataAdapter adapter = new SqlDataAdapter(pubSinCalificar, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "pubSinCalificar");
            dataGridView1.DataSource = ds.Tables[0];
            dt = new DataTable();
            dt = ds.Tables[0];
            /*
            comboBox_Visib.DataSource = dt1;
            comboBox_Visib.ValueMember = "visib_cod";
            comboBox_Visib.DisplayMember = "visib_desc";
            */
        }

        private void btn_Atras_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btb_Calificar_Click(object sender, EventArgs e)
        {

            if ( dt.Rows.Count > 0)
            {
                int id_compra = int.Parse(dataGridView1["compra", dataGridView1.CurrentRow.Index].Value.ToString());

                Calificar_Vendedor.CalificarCompra C_P = new Calificar_Vendedor.CalificarCompra(id_compra);
                this.Hide();
                C_P.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila para cailficar.");
            }


        }


    }
}
