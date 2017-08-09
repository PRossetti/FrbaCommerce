using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.Historial_Cliente
{
    public partial class Historial_Listar : Form1
    {
        private string usuario_actual;
        private string tipo_consulta;
        //private DataSet dsGlobal;
        private int maximo_x_pagina;
        public Historial_Listar(string usuario, string que_hago)
        {
            InitializeComponent();
            //string select = "";
            usuario_actual = usuario;
            tipo_consulta = que_hago;

            
            /*
            SqlConnection conexion = this.crearConexion();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion);

            DataSet ds = new DataSet();
            conexion.Open();
            dataAdapter.Fill(ds, "DataMember");
            conexion.Close();

            dsGlobal = ds;
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "DataMember";
             * */
        }
        private Comprar_Ofertar.Paginar p;
        private void Historial_Listar_Load(object sender, EventArgs e)
        {
            string select = "";
            maximo_x_pagina = 40;
            switch (tipo_consulta.ToLower())
            {
                case "compras":
                    comboBox_Filtro.Items.Clear();
                    comboBox_Filtro.Items.AddRange(new object[] { "compras realizadas", "ventas realizadas" });
                    comboBox_Filtro.SelectedIndex = 0;
                    if (comboBox_Filtro.SelectedItem.ToString() == "compras realizadas")
                    {
                        select = "select comp_pub_cod as publicacion, pub_desc as descripcion, compra_cant as cantidad_comprada, pub_precio, "
                            + " compra_fec FROM BE_SHARPS.Compras inner join BE_SHARPS.Usuarios on comp_comprador_id = usuario_id inner JOIN BE_SHARPS.Publicaciones on comp_pub_cod = pub_cod "
                            + " where usuario_user = '" + usuario_actual + "'order by compra_fec desc";
                    }
                    else
                    {
                        select = "select comp_pub_cod as publicacion, pub_desc as descripcion, compra_cant as cantidad_vendida "
                            + " , pub_precio, compra_fec FROM BE_SHARPS.Compras inner JOIN BE_SHARPS.Publicaciones on comp_pub_cod = pub_cod inner join BE_SHARPS.Usuarios "
                            + " on pub_id_usuario = usuario_id where usuario_user = '"+usuario_actual+"'order by compra_fec desc";
                    }
                    break;

                case "ofertas":
                    comboBox_Filtro.Items.Clear();
                    comboBox_Filtro.Items.AddRange(new object[] { "ofertas realizadas", "ofertas recibidas" });
                    comboBox_Filtro.SelectedIndex = 0;
                    if (comboBox_Filtro.SelectedItem.ToString() == "ofertas realizadas")
                    {
                        select = "select of_pub_cod as publicacion, pub_desc as descripcion, "
                                 + "pub_precio  as precio_base, oferta_monto as valor_oferta, oferta_fecha, "
                                 + "(case when comp_comprador_id=usuario_id then 'SI' else 'NO' end) as gano_subasta "
                                 + "FROM BE_SHARPS.Ofertas "
                                 + "INNER JOIN BE_SHARPS.Usuarios on of_usuario_id = usuario_id "
                                 + "INNER JOIN BE_SHARPS.Publicaciones on of_pub_cod = pub_cod "
                                 + "LEFT  JOIN BE_SHARPS.Compras on of_pub_cod=comp_pub_cod "
                                 + "where usuario_id = " + obtenerUsuarioID(usuario_actual) + " "
                                 + "GROUP BY of_pub_cod, pub_desc, pub_precio, oferta_monto, oferta_fecha, comp_comprador_id, usuario_id "
                                 + "order by oferta_fecha desc, valor_oferta asc";

                    }
                    else
                    {
                        select = "select of_pub_cod as publicacion, pub_desc as descripcion, 'Subasta' as tipo "
                            + " , pub_precio as precio_base, oferta_monto as valor_oferta, oferta_fecha FROM BE_SHARPS.Ofertas "
                            + " inner JOIN BE_SHARPS.Publicaciones on of_pub_cod = pub_cod inner join BE_SHARPS.Usuarios on pub_id_usuario = usuario_id "
                            + " where usuario_user = '"+usuario_actual+"' order by oferta_fecha desc, valor_oferta asc";
                    }
                    break;
                case "calificaciones":
                    comboBox_Filtro.Items.Clear();
                    comboBox_Filtro.Items.AddRange(new object[] { "calificaciones realizadas", "calificaciones recibidas" });
                    comboBox_Filtro.SelectedIndex = 0;
                    if (comboBox_Filtro.SelectedItem.ToString() == "calificaciones realizadas")
                    {
                        select = "select comp_pub_cod as publicacion, pub_desc as descripcion, compra_cant as cantidad_comprada "
                            + " , pub_precio, calif_desc, calif_estrellas, compra_fec " 
                            + " from BE_SHARPS.Usuarios inner JOIN BE_SHARPS.Compras on comp_comprador_id = usuario_id "
                            + " INNER JOIN BE_SHARPS.Calificaciones on comp_calif_cod = calif_cod "
                            + " inner JOIN BE_SHARPS.Publicaciones on pub_cod = comp_pub_cod "
                            + " where usuario_user = '"+usuario_actual+"' order by compra_fec desc";
                    }
                    else
                    {
                        select = "select comp_pub_cod as publicacion, pub_desc as descripcion, compra_cant as cantidad_vendida "
                            + " , pub_precio, calif_desc, calif_estrellas, compra_fec FROM BE_SHARPS.Publicaciones "
                            + " INNER JOIN BE_SHARPS.Calificaciones on comp_calif_cod = calif_cod "
                            + " inner join BE_SHARPS.Usuarios on pub_id_usuario = usuario_id inner JOIN BE_SHARPS.Compras on comp_pub_cod = pub_cod "
                            + "  where usuario_user = '"+usuario_actual+"' "
                            + " order by compra_fec desc";
                    }
                    break;
            }
            p = new FrbaCommerce.Comprar_Ofertar.Paginar(select, "DataMember", maximo_x_pagina);
            dataGridView1.DataSource = p.cargar();
            dataGridView1.DataMember = "DataMember";
            //Como hago para ocultar el id_publicacion??
            actualizar();

        }
        private void actualizar()
        {
            maskedTextBox1.Text = p.countRow().ToString();
            maskedTextBox2.Text = p.numPag().ToString();
            maskedTextBox3.Text = p.countPag().ToString();
            maskedTextBox4.Text = p.limitRow().ToString();
        }

        private void button_PrimerPagina_Click(object sender, EventArgs e)
        {
            p.primeraPagina();
            actualizar();
        }

        private void button_PagAnterior_Click(object sender, EventArgs e)
        {
            p.atras();
            actualizar();
        }

        private void button_PagSiguiente_Click(object sender, EventArgs e)
        {
            p.adelante();
            actualizar();
        }

        private void button_UltimaPagina_Click(object sender, EventArgs e)
        {
            p.ultimaPagina();
            actualizar();
        }

        private void button_Actualizar_Click(object sender, EventArgs e)
        {
            p.actualizaTope(Convert.ToInt32(maskedTextBox4.Text));
            actualizar();
        }

        private void button_Atras_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

         private void comboBox_Filtro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = "";
            switch (tipo_consulta.ToLower())
            {
                case "compras":
                    if (comboBox_Filtro.SelectedItem.ToString() == "compras realizadas")
                    {
                        select = "select comp_pub_cod as publicacion, pub_desc as descripcion, compra_cant as cantidad_comprada, pub_precio, "
                            + " compra_fec FROM BE_SHARPS.Compras inner join BE_SHARPS.Usuarios on comp_comprador_id = usuario_id inner JOIN BE_SHARPS.Publicaciones on comp_pub_cod = pub_cod "
                            + " where usuario_user = '" + usuario_actual + "'order by compra_fec desc";
                    }
                    else
                    {
                        select = "select comp_pub_cod as publicacion, pub_desc as descripcion, compra_cant as cantidad_vendida "
                            + " , pub_precio, compra_fec FROM BE_SHARPS.Compras inner JOIN BE_SHARPS.Publicaciones on comp_pub_cod = pub_cod inner join BE_SHARPS.Usuarios "
                            + " on pub_id_usuario = usuario_id where usuario_user = '" + usuario_actual + "'order by compra_fec desc";
                    }
                    break;

                case "ofertas":
                    if (comboBox_Filtro.SelectedItem.ToString() == "ofertas realizadas")
                    {
                        select = "select of_pub_cod as publicacion, pub_desc as descripcion, " 
	                     + "pub_precio  as precio_base, oferta_monto as valor_oferta, oferta_fecha, "
                         + "(case when comp_comprador_id=usuario_id then 'SI' else 'NO' end) as gano_subasta "
                         + "FROM BE_SHARPS.Ofertas "
                         + "INNER JOIN BE_SHARPS.Usuarios on of_usuario_id = usuario_id " 
                         + "INNER JOIN BE_SHARPS.Publicaciones on of_pub_cod = pub_cod "
                         + "LEFT  JOIN BE_SHARPS.Compras on of_pub_cod=comp_pub_cod "
                         + "where usuario_id = " + obtenerUsuarioID(usuario_actual)+ " "
                         + "GROUP BY of_pub_cod, pub_desc, pub_precio, oferta_monto, oferta_fecha, comp_comprador_id, usuario_id "
                         + "order by oferta_fecha desc, valor_oferta asc";                   
                    }
                    else
                    {
                        select = "select of_pub_cod as publicacion, pub_desc as descripcion, 'Subasta' as tipo "
                            + " , pub_precio as precio_base, oferta_monto as valor_oferta, oferta_fecha FROM BE_SHARPS.Ofertas "
                            + " inner JOIN BE_SHARPS.Publicaciones on of_pub_cod = pub_cod inner join BE_SHARPS.Usuarios on pub_id_usuario = usuario_id "
                            + " where usuario_user = '" + usuario_actual + "' order by oferta_fecha desc, valor_oferta asc";
                    }
                    break;
                case "calificaciones":
                    if (comboBox_Filtro.SelectedItem.ToString() == "calificaciones realizadas")
                    {
                        select = "select comp_pub_cod as publicacion, pub_desc as descripcion, compra_cant as cantidad_comprada "
                            + " , pub_precio, calif_desc, calif_estrellas, compra_fec  from BE_SHARPS.Usuarios inner JOIN BE_SHARPS.Compras on comp_comprador_id = usuario_id "
                            + "  inner JOIN BE_SHARPS.Publicaciones on pub_cod = comp_pub_cod "
                            + " INNER JOIN BE_SHARPS.Calificaciones on comp_calif_cod = calif_cod "
                            + " where usuario_user = '" + usuario_actual + "' order by compra_fec desc";
                    }
                    else
                    {
                        select = "select comp_pub_cod as publicacion, pub_desc as descripcion, compra_cant as cantidad_vendida "
                            + " , pub_precio, calif_desc, calif_estrellas, compra_fec FROM BE_SHARPS.Publicaciones "
                            + " inner join BE_SHARPS.Usuarios on pub_id_usuario = usuario_id inner JOIN BE_SHARPS.Compras on comp_pub_cod = pub_cod "
                            + " INNER JOIN BE_SHARPS.Calificaciones on comp_calif_cod = calif_cod "
                            + " where usuario_user = '" + usuario_actual + "' "
                            + " order by compra_fec desc";
                    }
                    break;
            }
            p = new FrbaCommerce.Comprar_Ofertar.Paginar(select, "DataMember", maximo_x_pagina);
            dataGridView1.DataSource = p.cargar();
            dataGridView1.DataMember = "datamember";

            actualizar();
        }
    }
}
