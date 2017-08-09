using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient; //agregada
using System.Collections; // agregada


namespace FrbaCommerce.Listado_Estadistico
{
    public partial class Listado_Estadistico : Form1
    {
        
        public Listado_Estadistico()
        {
            InitializeComponent();

            label_ErrorAnio.Text = "";
            label_ErrorMensaje.Text = "";
            label_RankSeleccioando.Text = "";
            comboBox_Trimestre.Hide();
            comboBox_Visib.Hide();
            label5.Text = "Luego de completar el año haga clic en OK \ny elija los filtros correspondientes";

            SqlConnection con = this.crearConexion();            
            // COMIENZO CARGA COMBO BOX DE VISIBILIDAD
            string visibilidades = "SELECT visib_cod, visib_desc FROM BE_SHARPS.Visibilidad";
            SqlDataAdapter adapter1 = new SqlDataAdapter(visibilidades, con);
            DataSet ds1 = new DataSet();
            adapter1.Fill(ds1, "Visibilidad");
            DataTable dt1 = ds1.Tables[0];

            comboBox_Visib.DataSource = dt1;
            comboBox_Visib.ValueMember = "visib_cod";
            comboBox_Visib.DisplayMember = "visib_desc";
            // FIN CARGA COMBO BOX DE VISIBILIDAD

            comboBox_Rank.SelectedIndex = 0;
            comboBox_Trimestre.SelectedIndex = 0;
            comboBox_Visib.SelectedIndex = 0;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Listar_Click(object sender, EventArgs e)
        {
            //SqlCommand cmd = new SqlCommand("usuarioConMasProductosSinVender", con);
            int anioo;
            if (int.TryParse(txtBx_Anio.Text, out anioo) && (int.Parse(txtBx_Anio.Text) >= 2000) && (int.Parse(txtBx_Anio.Text) < 2015))
            {
                SqlConnection con = this.crearConexion();

                string preConsulta = "";
                string groupByOrderBy = "";
                string where = "";
                int anio = int.Parse(txtBx_Anio.Text);
                int mes1 = 1;
                switch (comboBox_Trimestre.SelectedIndex)
                {
                    case 0:
                        mes1 = 1;
                        break;
                    case 1:
                        mes1 = 4;
                        break;
                    case 2:
                        mes1 = 7;
                        break;
                    case 3:
                        mes1 = 10;
                        break;
                    default:
                        MessageBox.Show("Entró por default. Ocurrió algo inesperado");
                        break;
                }

                //int mes2 = mes1 + 2;

                switch (comboBox_Rank.SelectedIndex)
                {
                    case 0:
                        label_RankSeleccioando.Text = comboBox_Rank.Items[0].ToString();
                        string visib = ((DataRowView)comboBox_Visib.Items[comboBox_Visib.SelectedIndex])["visib_cod"].ToString();
                        //MessageBox.Show(((DataRowView)comboBox_Visib.Items[comboBox_Visib.SelectedIndex])["visib_cod"].ToString());

                        preConsulta = "SELECT TOP 5 usuario_id,(case when cli_nombre is not null then cli_nombre else emp_rsocial end) "
                         + "as razon_o_nombre, SUM(pub_stock) as cant_productos_no_vendidos FROM BE_SHARPS.Usuarios "
                         + "LEFT JOIN BE_SHARPS.Clientes ON u_cli_id=cli_id LEFT JOIN BE_SHARPS.Empresas ON u_emp_id=emp_id "
                         + "INNER JOIN BE_SHARPS.Publicaciones ON usuario_id=pub_id_usuario ";


                        where = " WHERE pub_visibilidad_cod =" + visib + " AND YEAR(pub_fecha)=" + anio + " AND MONTH(pub_fecha) BETWEEN " + mes1 + " AND " + (mes1+2);
                        groupByOrderBy = " GROUP BY usuario_id, cli_nombre, emp_rsocial ORDER BY cant_productos_no_vendidos DESC";

                        break;
                    case 1:
                        label_RankSeleccioando.Text = comboBox_Rank.Items[1].ToString();
                        preConsulta = "SELECT TOP 5 (case when cli_nombre is not null then cli_nombre else emp_rsocial end) razon_o_nombre, "
                        + "SUM(factura_total) as facturacion FROM BE_SHARPS.Usuarios LEFT JOIN BE_SHARPS.Clientes ON u_cli_id=cli_id LEFT JOIN BE_SHARPS.Empresas "
                        + "ON u_emp_id=emp_id LEFT JOIN BE_SHARPS.Factura ON fact_usuario_id=usuario_id ";

                        where = " WHERE YEAR(factura_fecha)=" + anio + " AND MONTH(factura_fecha) BETWEEN " + mes1 + " AND " + (mes1+2);
                        groupByOrderBy = " GROUP BY usuario_id, cli_nombre, emp_rsocial ORDER BY SUM(factura_total) DESC";


                        break;
                    case 2:
                        label_RankSeleccioando.Text = comboBox_Rank.Items[2].ToString();

                        preConsulta = "SELECT TOP 5 (case when cli_nombre is not null then cli_nombre+' '+cli_apellido else emp_rsocial end) as razon_o_nombre, "
                         + "cast(AVG(calif_estrellas) as decimal(18,2)) as reputacion FROM BE_SHARPS.Usuarios "
                         + "LEFT JOIN BE_SHARPS.Clientes ON u_cli_id=cli_id "
                         + "LEFT JOIN BE_SHARPS.Empresas ON u_emp_id=emp_id "
                         + "LEFT JOIN BE_SHARPS.Publicaciones ON usuario_id = pub_id_usuario "
                         + "LEFT JOIN BE_SHARPS.Compras ON comp_pub_cod = pub_cod "
                         + "LEFT JOIN BE_SHARPS.Calificaciones on comp_calif_cod = calif_cod ";

                        where = " WHERE YEAR(compra_fec)=" + anio + " AND MONTH(compra_fec) BETWEEN " + mes1 + " AND " + (mes1+2);

                        groupByOrderBy = " GROUP BY usuario_id, cli_nombre, cli_apellido, emp_rsocial ORDER BY AVG(calif_estrellas) DESC";
                        break;

                    case 3:
                        label_RankSeleccioando.Text = comboBox_Rank.Items[3].ToString();
                        preConsulta = "SELECT TOP 5 cli_id, cli_nombre, cli_apellido, COUNT(*) AS cant_pub_sin_calificar "
                        + "FROM BE_SHARPS.Compras "
                        + "INNER JOIN BE_SHARPS.Clientes on comp_comprador_id = cli_id "
                        + "LEFT JOIN BE_SHARPS.Calificaciones on comp_calif_cod = calif_cod";

                        where = " where comp_calif_cod is null AND YEAR(compra_fec)=" + anio + " AND MONTH(compra_fec) BETWEEN " + mes1 + " AND " + (mes1+2);

                        groupByOrderBy = " GROUP BY cli_id, cli_nombre, cli_apellido ORDER BY cant_pub_sin_calificar DESC";
                        break;

                    default:
                        MessageBox.Show("Entró por default, ocurrió algo inesperado");
                        break;
                }

                // FILTROS (anio y trimestre)

                string consultaArmada = preConsulta + where + groupByOrderBy;

                SqlDataAdapter adapter = new SqlDataAdapter(consultaArmada, con);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "origen");
                dataGridView1.DataSource = ds.Tables[0];

            }
            else
            {
                label_ErrorAnio.Text = "(*)";
                label_ErrorMensaje.Text = "(*) Es necesario ingresar un año válido.";
            }

            
            
            /*
            Data
            
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            */
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
        //  CHECKEO LOS DATOS

            bool datos_ok = true;
            int anio;
            if (int.TryParse(txtBx_Anio.Text, out anio) && (int.Parse(txtBx_Anio.Text) >= 2000) && (int.Parse(txtBx_Anio.Text) < 2015))
            {
                label_ErrorAnio.Text = "";
                if (anio == 2014)
                {

                }
                else
                {

                }
                comboBox_Trimestre.Show();
            }
            else
            {
                label_ErrorAnio.Text = "(*)";
                datos_ok = false;
            }

            if (comboBox_Rank.SelectedIndex == 0)
            {
                comboBox_Visib.Show();
            }
            else
            {
                comboBox_Visib.Hide();
            }



            if (datos_ok == true)
            {                
                label_ErrorMensaje.Text = "";
            }
            else
            {
                label_ErrorMensaje.Text = "(*) Es necesario ingresar un año válido.";
            }
        }

        private void comboBox_Rank_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_Visib.Hide();
            comboBox_Trimestre.Hide();
        }


    }
}
