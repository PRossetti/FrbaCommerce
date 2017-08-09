using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient; //agregada

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class Buscar : Form1
    {
        private int maximo_x_pagina;
        private int usuario_id;
        public Buscar(int u_id)
        {
            InitializeComponent();
            usuario_id = u_id;
            txtBx_Publicacion.Hide();
        }
        private Paginar p;
        private void Buscar_Load(object sender, EventArgs e)
        {
            maximo_x_pagina = 40;//cargar por default
            //p = new Paginar("SELECT pub_cod, pub_desc,pub_stock,pub_precio FROM BE_SHARPS.Publicaciones", "DataMember1", maximo_x_pagina);
            string consulta = "SELECT DISTINCT pub_cod, pub_id_usuario, pub_visibilidad_cod, pub_desc, pub_stock, pub_fecha, pub_fec_venc, "
            + "pub_precio, pub_tipo, pub_estado, pub_preg_habilitadas, visib_precio FROM BE_SHARPS.Publicaciones, BE_SHARPS.Visibilidad where "
            + "pub_visibilidad_cod=visib_cod and pub_stock>0 and "
            + "(pub_estado='Publicada' OR pub_estado='Pausada') and pub_id_usuario <> " + usuario_id + " ORDER BY visib_precio DESC";
            
            p = new Paginar(consulta, "DataMember1", maximo_x_pagina);
            dataGridView1.DataSource = p.cargar();
            dataGridView1.DataMember = "datamember1";

            /*
            string consulta = "SELECT * FROM BE_SHARPS.Rubros";
            SqlConnection con = this.crearConexion();
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, con);
            DataSet ds = new DataSet();
            con.Open();
            adapter.Fill(ds, "Rubros");
            con.Close();
            
            checkedListBox1.DataSource = ds.Tables[0];
            checkedListBox1.ValueMember = "rubro_id";
            checkedListBox1.DisplayMember = "rubro_desc";
             */

            adaptador("SELECT * FROM BE_SHARPS.Rubros", ref checkedListBox1, "rubro_id", "rubro_desc"); 
            



            actualizar();
        }

        private void actualizar()
        {
            maskedTextBox1.Text = p.countRow().ToString();
            maskedTextBox2.Text = p.numPag().ToString();
            maskedTextBox3.Text = p.countPag().ToString();
            maskedTextBox4.Text = p.limitRow().ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            p.actualizaTope(Convert.ToInt32(maskedTextBox4.Text));
            actualizar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p.adelante();
            actualizar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.atras();
            actualizar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            p.primeraPagina();
            actualizar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            p.ultimaPagina();
            actualizar();
        }

        private void btn_Seleccionar_Click(object sender, EventArgs e)
        {
            //txtBx_Publicacion.Text = dataGridView1.CurrentCell.Value.ToString();
            //mydatagrid["columnName",rowindex].Value.ToString();
            string estado = dataGridView1["pub_estado", dataGridView1.CurrentRow.Index].Value.ToString();
            if (estado == "Publicada")
            {

            txtBx_Publicacion.Text = dataGridView1["pub_cod", dataGridView1.CurrentRow.Index].Value.ToString();
            int pub_cod = int.Parse(dataGridView1["pub_cod", dataGridView1.CurrentRow.Index].Value.ToString());

            Comprar_Ofertar.Detalle_Publicacion D_P = new Comprar_Ofertar.Detalle_Publicacion(pub_cod, usuario_id);
            this.Hide();
            D_P.ShowDialog();
            //this.Show();
            this.Close();
            }
            else
            {
                MessageBox.Show("No puede realizar operaciones sobre una publicación pausada.");
            }

        }

        private void button_Filtrar_Click(object sender, EventArgs e)
        {
            
            string filtroDesc = textBox_FiltroDesc.Text + '%';
            string consultaFiltrada = "SELECT DISTINCT pub_cod, pub_id_usuario, pub_visibilidad_cod, pub_desc, pub_stock, pub_fecha, pub_fec_venc, "
            + "pub_precio, pub_tipo, pub_estado, pub_preg_habilitadas, visib_precio FROM BE_SHARPS.Publicaciones, BE_SHARPS.Visibilidad, BE_SHARPS.PublicacionXRubro WHERE "
            + "pub_id_usuario <> " + usuario_id + "AND pub_visibilidad_cod=visib_cod AND pub_stock>0 and "
            + "(pub_estado='Publicada' OR pub_estado='Pausada') and pub_cod=publi_pub AND pub_desc like '%" + filtroDesc + "'";
      
                 
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                consultaFiltrada = consultaFiltrada+ " AND (publi_rubro=" + 
                    ((DataRowView)checkedListBox1.CheckedItems[0])["rubro_id"]; 
                //string consultaFiltrada = "SELECT * FROM BE_SHARPS.Publicaciones, BE_SHARPS.PublicacionXRubro "
                //+ "where pub_cod=publi_pub and (publi_rubro=" + ((DataRowView)checkedListBox1.CheckedItems[0])["rubro_id"];

                for (int i = 1; i < checkedListBox1.CheckedItems.Count; i++)
                {
                    consultaFiltrada = consultaFiltrada + " OR publi_rubro= " + ((DataRowView)checkedListBox1.CheckedItems[i])["rubro_id"];
                    //MessageBox.Show(((DataRowView)checkedListBox1.CheckedItems[i])["rubro_id"].ToString());              
                }
                consultaFiltrada = consultaFiltrada + ")";
            }

            consultaFiltrada = consultaFiltrada + " ORDER BY visib_precio DESC";
            p = new Paginar(consultaFiltrada, "DataMember1", maximo_x_pagina);
            dataGridView1.DataSource = p.cargar();
            dataGridView1.DataMember = "datamember1";

            actualizar();
                     


        }

        private void btn_Preguntar_Click(object sender, EventArgs e)
        {
            txtBx_Publicacion.Text = dataGridView1["pub_cod", dataGridView1.CurrentRow.Index].Value.ToString();
            int pub_cod = int.Parse(dataGridView1["pub_cod", dataGridView1.CurrentRow.Index].Value.ToString());
            string sePuedePreguntar = dataGridView1["pub_preg_habilitadas", dataGridView1.CurrentRow.Index].Value.ToString();

            if (sePuedePreguntar.ToUpper() == "YES")
            {
                Comprar_Ofertar.Preguntar P = new Comprar_Ofertar.Preguntar(pub_cod, usuario_id);
                this.Hide();
                P.ShowDialog();                
                this.Show();
            }
            else
            {
                MessageBox.Show("Las preguntas no están habilitadas para esta publicación");
            }
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
