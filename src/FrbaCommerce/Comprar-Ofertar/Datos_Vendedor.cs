using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient; // agregada

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class Datos_Vendedor : Form1
    {
        private bool ok;
        public Datos_Vendedor(int vendedor_id, int unidades, int pub_codigo, int usuario_id)
        {
            InitializeComponent();
          

            SqlConnection con = this.crearConexion();
            SqlCommand cmd = new SqlCommand("BE_SHARPS.tipoUsuario", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@usuario", vendedor_id);
            
            SqlParameter ret_tipoVendedor = cmd.Parameters.Add("@tipoVendedor",SqlDbType.Char,1); // hay que especificar la longitud de char
            SqlParameter ret_idTipoVendedor = cmd.Parameters.Add("@idTipoVendedor", SqlDbType.Int);

            ret_tipoVendedor.Direction = ParameterDirection.Output;
            ret_idTipoVendedor.Direction = ParameterDirection.Output;

            con.Open();
            cmd.ExecuteNonQuery();
            char tipoVendedor = char.Parse(cmd.Parameters["@tipoVendedor"].Value.ToString());
            int idTipoVendedor = (int)cmd.Parameters["@idTipoVendedor"].Value;
            con.Close();
            
            //OBTENER REPUTACION
            SqlCommand cmd2 = new SqlCommand("BE_SHARPS.obtenerReputacion", con);
            cmd2.CommandType = CommandType.StoredProcedure;

            cmd2.Parameters.AddWithValue("@usuario_id", vendedor_id);
            // output
            /*
            cmd2.Parameters.Add("@ventas",SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd2.Parameters.Add("@calificaciones", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd2.Parameters.Add("@estrellas", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd2.Parameters.Add("@reputacion", SqlDbType.Decimal).Direction = ParameterDirection.Output;
            */

            SqlParameter ret1 = cmd2.Parameters.Add("@ventas",SqlDbType.Int);
            SqlParameter ret2 = cmd2.Parameters.Add("@calificaciones", SqlDbType.Int);
            SqlParameter ret3 = cmd2.Parameters.Add("@estrellas", SqlDbType.Int);
            SqlParameter ret4 = cmd2.Parameters.Add("@reputacion", SqlDbType.Float);

            ret1.Direction = ParameterDirection.Output;
            ret2.Direction = ParameterDirection.Output;
            ret3.Direction = ParameterDirection.Output;
            ret4.Direction = ParameterDirection.Output; 
                       
            con.Open();
            cmd2.ExecuteNonQuery();
            int ventas = (int)cmd2.Parameters["@ventas"].Value;
            int calificaciones = (int)cmd2.Parameters["@calificaciones"].Value;
            int estrellas = (int)cmd2.Parameters["@estrellas"].Value;
            double reputacion = (double)cmd2.Parameters["@reputacion"].Value;
            con.Close();

            txtBx_Calificaciones.Text = calificaciones.ToString();
            txtBx_Estrellas.Text = estrellas.ToString();
            txtBx_Vtas.Text = ventas.ToString();
            txtBx_Reputacion.Text = reputacion.ToString(); 

            //MessageBox.Show("Tipo Vendedor: " + tipoVendedor + "Id Vendedor: " + idTipoVendedor);

            SqlDataAdapter adapter;
            DataSet ds = new DataSet();

            
            switch (tipoVendedor)
            {
                case 'C':
                    string consultaCli = "SELECT * FROM BE_SHARPS.Clientes where cli_id ="+ idTipoVendedor;
                    adapter = new SqlDataAdapter(consultaCli,con);
                    adapter.Fill(ds, "Clientes");
                    dataGridView1.DataSource = ds.Tables[0];
                    break;

                case 'E':
                    string consultaEmp = "SELECT * FROM BE_SHARPS.Empresas where emp_id="+ idTipoVendedor;
                    adapter = new SqlDataAdapter(consultaEmp, con);
                    adapter.Fill(ds, "Empresas");
                    dataGridView1.DataSource = ds.Tables[0];
                    break;

                default:
                    MessageBox.Show("[Error] Entro por default. Sucedio algo inesperado");
                    break;
            }

            //string update = "UPDATE BE_SHARPS.Publicaciones set pub_stock = pub_stock-"
            //    + unidades + " where pub_cod=" + pub_codigo;
                        
            //SqlConnection con = this.crearConexion();
            SqlCommand cmd3 = new SqlCommand("BE_SHARPS.comprar", con); //ACA HAGO EL INSERT
            cmd3.CommandType = CommandType.StoredProcedure;

            cmd3.Parameters.AddWithValue("@pub_codigo", pub_codigo);
            cmd3.Parameters.AddWithValue("@unidades", unidades);
            cmd3.Parameters.AddWithValue("@cliente_id", usuario_id); // ahora se pasa el usuario_id            
            cmd3.Parameters.AddWithValue("@fecha", obtenerFecha());


            ok = true;
            try
            {
                con.Open();
                cmd3.ExecuteNonQuery();
                con.Close();                
                //this.DialogResult = DialogResult.OK;
            }
            catch (SqlException ex)
            {
                ok = false;
                SqlError err = ex.Errors[0];
                MessageBox.Show(err.Message);
                label2.Text = "No se pudo realizar la compra";
                label3.Text = "";
                label2.ForeColor = System.Drawing.Color.Red;                
            }


        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            if (ok == true)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
            
            this.Close();
        }
    }
}
