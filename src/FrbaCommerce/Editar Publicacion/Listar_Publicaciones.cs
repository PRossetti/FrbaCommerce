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

namespace FrbaCommerce.Editar_Publicacion
{
    public partial class Listar_Publicaciones : Form1
    {
        private string usuario_actual;
        private int maximo_x_pagina;
        private DataTable dt_FiltroVisibilidad;
        public Listar_Publicaciones(string usuario)
        {
            //RECIBIDO UN NOMBRE DE USUARIO, BUSCO SUS PUBLICACIONES
            InitializeComponent();
            usuario_actual = usuario;
            //comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_FiltroVisib.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_FiltroEstado.DropDownStyle = ComboBoxStyle.DropDownList;

            string select = "select visib_cod, visib_desc FROM BE_SHARPS.Visibilidad order by visib_precio";
            SqlConnection conexion = this.crearConexion();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conexion);

            DataSet dataSet = new DataSet();
            conexion.Open();
            dataAdapter.Fill(dataSet, "Visibilidad");
            conexion.Close();

            dt_FiltroVisibilidad = dataSet.Tables[0];
            comboBox_FiltroVisib.DataSource = dt_FiltroVisibilidad;
            comboBox_FiltroVisib.ValueMember = "visib_cod";
            comboBox_FiltroVisib.DisplayMember = "visib_desc";
            
            comboBox_FiltroVisib.Visible = false;
            comboBox_FiltroEstado.Visible = false;
            label_FiltroVisib.Visible = false;
            label_FiltroEstado.Visible = false;

        }
        private Comprar_Ofertar.Paginar p;

        private void load_Publicaciones(object sender, EventArgs e)
        {
            maximo_x_pagina = 40;
            string select = "select pub_cod, pub_desc, pub_stock, pub_precio, pub_tipo, pub_preg_habilitadas, pub_estado, visib_desc, visib_precio "
            + " , pub_fecha, pub_fec_venc from BE_SHARPS.Usuarios inner JOIN BE_SHARPS.Publicaciones on usuario_id = pub_id_usuario inner JOIN BE_SHARPS.Visibilidad "
            + " on visib_cod = pub_visibilidad_cod where usuario_user = '" + usuario_actual + "' order by pub_visibilidad_cod desc";
            ///NOTA: VER EL TEMA DE LOS FILTROS EN EL STRING DEL SELECT
            ///habria que agregarle al where lo siguiente: " and pub_desc like '"+textbox.Text+"%'" (....)
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

        private void button_Actualizar_Click(object sender, EventArgs e)
        {
            p.actualizaTope(Convert.ToInt32(maskedTextBox4.Text));
            actualizar();
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

        private void button_Seleccionar_Click(object sender, EventArgs e)
        {
            textBox_Publicacion.Text = dataGridView1["pub_cod", dataGridView1.CurrentRow.Index].Value.ToString();
        }

        private void button_EditarPublicacion_Click(object sender, EventArgs e)
        {
            if (textBox_Publicacion.Text != "")
            {
                // NO TIENE Q ENTRAR CUANDO LA PUBLICACION ES FINALIZADA!!!!
                string cod_pub = textBox_Publicacion.Text;
                ArrayList datos_Pub = this.obtener_Datos_Publicacion(Int32.Parse(cod_pub));
                if (datos_Pub[9].ToString() != "Finalizada")
                {
                    Editar_Publicacion E_P = new Editar_Publicacion(datos_Pub);
                    this.Hide();
                    E_P.ShowDialog();
                    this.Show();
                }
                else MessageBox.Show("La publicacion está finalizada y no se puede editar.");
            }
        }

        private void button_Crear_Click(object sender, EventArgs e)
        {
            Generar_Publicacion.Tipo_Publicacion T_P = new Generar_Publicacion.Tipo_Publicacion(usuario_actual);
            this.Hide();
            T_P.ShowDialog();
            this.Show();
        }

        private void checkBox_AgregarVisib_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_AgregarVisib.Checked)
            {
                comboBox_FiltroVisib.Visible = true;
                label_FiltroVisib.Visible = true;
            }
            else
            {
                comboBox_FiltroVisib.Visible = false;
                label_FiltroVisib.Visible = false;
            }
        }

        private void checkBox_AgregarEstado_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_AgregarEstado.Checked)
            {
                comboBox_FiltroEstado.SelectedIndex = 0;
                comboBox_FiltroEstado.Visible = true;
                label_FiltroEstado.Visible = true;
            }
            else
            {
                comboBox_FiltroEstado.Visible = false;
                label_FiltroEstado.Visible = false;
            }
        }

        private void button_Filtrar_Click(object sender, EventArgs e)
        {
            //string descripcion, estado, visibilidad = "";

            string select = "select pub_cod, pub_desc, pub_stock, pub_precio, pub_tipo, pub_preg_habilitadas, pub_estado, "
                + " visib_desc, visib_precio , pub_fecha, pub_fec_venc from BE_SHARPS.Usuarios inner JOIN BE_SHARPS.Publicaciones on usuario_id = pub_id_usuario "
                + " inner JOIN BE_SHARPS.Visibilidad on visib_cod = pub_visibilidad_cod where usuario_user = '" + usuario_actual + "' ";
     
            select += " and pub_desc like '"+textBox_FiltroDesc.Text+"%' ";

            if (checkBox_AgregarVisib.Checked) select += "and visib_cod = "+comboBox_FiltroVisib.SelectedValue+" ";
            if (checkBox_AgregarEstado.Checked) select += "and pub_estado like '"+comboBox_FiltroEstado.SelectedItem+"' ";

            select += " order by pub_visibilidad_cod desc";
            p = new FrbaCommerce.Comprar_Ofertar.Paginar(select, "DataMember", maximo_x_pagina);
            dataGridView1.DataSource = p.cargar();
            dataGridView1.DataMember = "datamember";

            actualizar();
        }

    }
}
