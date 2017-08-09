using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.Facturar_Publicaciones
{
    public partial class Ventas_Realizadas : Form1
    {
        private string usuario_actual;
        private DataSet dataSetGlobal;
        public Ventas_Realizadas(string usuario)
        {
            InitializeComponent();

            txtBx_Tarjeta.Hide();
            txtBx_Num.Hide();
            txtBx_Cod.Hide();
            lbl_Tarjeta.Hide();
            lbl_Num.Hide();
            lbl_Cod.Hide();
            label_ErrorMensaje.Text = "";
       
       
            usuario_actual = usuario;
            comboBox_FormaDePago.SelectedIndex = 0;

            SqlConnection conexion = this.crearConexion();
            string count = "select COUNT(pub_cod) FROM BE_SHARPS.Publicaciones, BE_SHARPS.Usuarios "
                + " where pub_id_usuario = usuario_id and (pub_fec_venc < convert(datetime,'" + obtenerFecha() + "',103) or pub_estado = 'Finalizada') "
                + " and not exists (select item_pub_cod from BE_SHARPS.Item_Factura where item_pub_cod = pub_cod) "
                + " and usuario_user = '"+usuario_actual+"'";
            SqlCommand comando = new SqlCommand(count, conexion);

            conexion.Open();
            textBox_PubliFinalizadas.Text = comando.ExecuteScalar().ToString();
            conexion.Close();

            string select_loco = "select pub_cod, pub_desc, pub_precio ,(SUM(case when compra_cant IS null then 0 else compra_cant end))as cant_vendida "
                + " ,visib_desc, visib_precio,((SUM(case when compra_cant IS null then 0 else compra_cant end)*pub_precio*visib_porcentaje)+visib_precio) as total "
                + " FROM BE_SHARPS.Compras right JOIN BE_SHARPS.Publicaciones on comp_pub_cod = pub_cod inner JOIN BE_SHARPS.Visibilidad on pub_visibilidad_cod = visib_cod "
                + " inner join BE_SHARPS.Usuarios on pub_id_usuario = usuario_id where not exists (select item_pub_cod from BE_SHARPS.Item_Factura where item_pub_cod = pub_cod) "
                + " and (pub_fec_venc < convert(datetime,'" + obtenerFecha() + "',103) or pub_estado = 'Finalizada') and usuario_user = '" + usuario_actual + "' group by pub_cod, pub_desc, pub_precio, visib_desc "
                + " , visib_precio, visib_porcentaje, pub_fec_venc order by pub_fec_venc ";
            SqlConnection conexion2 = this.crearConexion();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select_loco, conexion2);

            DataSet ds = new DataSet();
            conexion2.Open();
            dataAdapter.Fill(ds, "holi");
            conexion2.Close();

            dataSetGlobal = ds;
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "holi";

            //comboBox_FormaDePago.SelectedIndex = 0;

        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_VistaPrevia_Click(object sender, EventArgs e)
        {
            int cant_A_facturar;
            if (!Int32.TryParse(textBox_PubliAFacturar.Text, out cant_A_facturar) || Int32.Parse(textBox_PubliAFacturar.Text) > Int32.Parse(textBox_PubliFinalizadas.Text)
                || Int32.Parse(textBox_PubliAFacturar.Text) < 0)
            {
                MessageBox.Show("El valor ingresado es incorrecto.");
            }
            else
            {
                string select_loco = "select top "+textBox_PubliAFacturar.Text+" pub_cod, pub_desc, pub_precio ,(SUM(case when compra_cant IS null then 0 else compra_cant end))as cant_vendida "
                + " ,visib_desc, visib_precio,((SUM(case when compra_cant IS null then 0 else compra_cant end)*pub_precio*visib_porcentaje)+visib_precio) as total "
                + " FROM BE_SHARPS.Compras right JOIN BE_SHARPS.Publicaciones on comp_pub_cod = pub_cod inner JOIN BE_SHARPS.Visibilidad on pub_visibilidad_cod = visib_cod "
                + " inner join BE_SHARPS.Usuarios on pub_id_usuario = usuario_id where not exists (select item_pub_cod from BE_SHARPS.Item_Factura where item_pub_cod = pub_cod) "
                + " and (pub_fec_venc < convert(datetime,'" + obtenerFecha() + "',103) or pub_estado = 'Finalizada') and usuario_user = '" + usuario_actual + "' group by pub_cod, pub_desc, pub_precio, visib_desc "
                + " , visib_precio, visib_porcentaje, pub_fec_venc order by pub_fec_venc ";
                SqlConnection conexion2 = this.crearConexion();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(select_loco, conexion2);

                DataSet ds = new DataSet();
                conexion2.Open();
                dataAdapter.Fill(ds, "holi");
                conexion2.Close();

                dataSetGlobal = ds;
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "holi";
            }
        }

        private void button_Facturar_Click(object sender, EventArgs e)
        {
            bool datos_ok = true;
            bool tarjeta = false;

            if (comboBox_FormaDePago.SelectedIndex == 1)
            {
                tarjeta = true;
                if (txtBx_Num.Text == "")
                {
                    datos_ok = false;
                }
                if (txtBx_Num.Text == "")
                {
                    datos_ok = false;
                }
                if (txtBx_Num.Text == "")
                {
                    datos_ok = false;
                } 
            }

            
            
            int cant_A_facturar;
            if (!Int32.TryParse(textBox_PubliAFacturar.Text, out cant_A_facturar) || Int32.Parse(textBox_PubliAFacturar.Text) > Int32.Parse(textBox_PubliFinalizadas.Text)
                || Int32.Parse(textBox_PubliAFacturar.Text) < 0)
            {                
                MessageBox.Show("El valor ingresado es incorrecto.");
                datos_ok = false;                
            }

            if (datos_ok == true)
            {
                label_ErrorMensaje.Text = "";
                DataTable Lista = new DataTable();
                DataColumn datacolumn = new DataColumn("id_publi");
                Lista.Columns.Add(datacolumn);

                for (int i = 0; i < cant_A_facturar; i++)
                {
                    Lista.Rows.Add(dataSetGlobal.Tables[0].Rows[i][0]);
                }

                SqlConnection conexion = this.crearConexion();
                SqlCommand comando = new SqlCommand("BE_SHARPS.facturarPublicaciones", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                SqlParameter listaDeParametros = comando.Parameters.AddWithValue("@lista_Pubs", Lista);
                listaDeParametros.SqlDbType = SqlDbType.Structured;
                comando.Parameters.AddWithValue("@formaDePago", comboBox_FormaDePago.SelectedItem);
                comando.Parameters.AddWithValue("@fecha", obtenerFecha());

                comando.Parameters.Add("@facturado", SqlDbType.Float).Direction = ParameterDirection.Output;



                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    float facturado = float.Parse(comando.Parameters["@facturado"].Value.ToString());
                    conexion.Close();

                    MessageBox.Show("Se realizó la facturación sin problemas \n Monto total factura: " + facturado.ToString());
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
                catch (SqlException ex)
                {
                    SqlError error = ex.Errors[0];
                    MessageBox.Show(error.Message);
                    conexion.Close();
                }
                conexion.Close();
            }
            else //si los datos estan mal
            {
                if (tarjeta == true)
                {
                    label_ErrorMensaje.Text = "Verifique los datos de la tarjeta";
                }
                else
                {
                    label_ErrorMensaje.Text = "";
                }
            }
        }

        private void comboBox_FormaDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_FormaDePago.SelectedIndex == 1)
            {
                txtBx_Tarjeta.Show();
                txtBx_Num.Show();
                txtBx_Cod.Show();
                lbl_Tarjeta.Show();
                lbl_Num.Show();
                lbl_Cod.Show();
            }
            else
            {
                txtBx_Tarjeta.Hide();
                txtBx_Num.Hide();
                txtBx_Cod.Hide();
                lbl_Tarjeta.Hide();
                lbl_Num.Hide();
                lbl_Cod.Hide();
            }
        }


    }
}
