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
    public partial class Editar_Publicacion : Form1
    {
        private DataTable dt_Rubros;
        private DataTable dt_RubrosSeleccionados;
        private DataTable dt_Visibilidades;
        private string pub_cod;
        private string pub_tipo;
        private int stock_Anterior;
        //private string tipo_pub;
        //private string usuario_actual;

        public Editar_Publicacion(ArrayList datos_Publicacion)
        {
            InitializeComponent();
            pub_cod = datos_Publicacion[0].ToString();
            stock_Anterior = Int32.Parse(datos_Publicacion[4].ToString());
            pub_tipo = datos_Publicacion[8].ToString();

            comboBox_Estado.DropDownStyle = ComboBoxStyle.DropDownList;
            //datos_Publicacion[9] -> estado
            switch(datos_Publicacion[9].ToString().ToLower())
            {
                case "borrador":
                    this.comboBox_Estado.Items.AddRange(new object[] {
                                    "Borrador",
                                    "Publicada"});
                    break;
                case "publicada":
                    if (pub_tipo.ToLower() == "compra inmediata")
                    {
                        this.comboBox_Estado.Items.AddRange(new object[] {
                                    "Publicada",
                                    "Pausada",
                                    "Finalizada"});
                    }
                    else // es subasta
                    {
                        comboBox_Estado.Enabled = false;
                    }

                    comboBox_Visibilidad.Enabled = false;
                    textBox_Precio.Enabled = false;
                    listBox_Rubros.Enabled = false;
                    listBox_RubrosSeleccionados.Enabled = false;
                    button_AgregarRubro.Enabled = false;
                    button_QuitarRubro.Enabled = false;
                    checkBox_PermitirPreguntas.Enabled = false;
                    break;
                case "pausada":
                    this.comboBox_Estado.Items.AddRange(new object[] {
                                    "Pausada",
                                    "Publicada",
                                    "Finalizada"});
                    comboBox_Visibilidad.Enabled = false;
                    textBox_Descripcion.Enabled = false;
                    textBox_Precio.Enabled = false;
                    textBox_Stock.Enabled = false;
                    listBox_Rubros.Enabled = false;
                    listBox_RubrosSeleccionados.Enabled = false;
                    button_AgregarRubro.Enabled = false;
                    button_QuitarRubro.Enabled = false;
                    checkBox_PermitirPreguntas.Enabled = false;
                    break;
                /*case "finalizada":
                    this.comboBox_Estado.Items.AddRange(new object[] {
                                    "Finalizada"});
                    break;*/
            }

            comboBox_Visibilidad.DropDownStyle = ComboBoxStyle.DropDownList;

            if (datos_Publicacion[8].ToString() == "Subasta")
            {
                textBox_Stock.ReadOnly = true;
            }

            //Sheno los listbox:
            string consulta1 = "SELECT rubro_id, rubro_desc FROM BE_SHARPS.Rubros";
            string consulta2 = "SELECT rubro_id, rubro_desc FROM BE_SHARPS.Rubros inner JOIN BE_SHARPS.PublicacionXRubro on "
            +   " publi_rubro = rubro_id where publi_pub = "+ datos_Publicacion[0];
            string consulta3 = "select visib_cod, visib_desc FROM BE_SHARPS.Visibilidad"; 
            SqlConnection con = this.crearConexion();

            con.Open();
            SqlDataAdapter adapter1 = new SqlDataAdapter(consulta1, con);
            SqlDataAdapter adapter2 = new SqlDataAdapter(consulta2, con);
            SqlDataAdapter adapter3 = new SqlDataAdapter(consulta3, con);
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            DataSet ds3 = new DataSet();

            adapter1.Fill(ds1, "Rubros");
            adapter2.Fill(ds2, "Rubros");
            adapter3.Fill(ds3, "Visibilidad");

            con.Close();
            dt_Rubros = ds1.Tables[0];
            dt_RubrosSeleccionados = ds2.Tables[0];
            dt_Visibilidades = ds3.Tables[0];

            listBox_Rubros.DataSource = dt_Rubros;
            listBox_Rubros.ValueMember = "rubro_id";
            listBox_Rubros.DisplayMember = "rubro_desc";

            listBox_RubrosSeleccionados.DataSource = dt_RubrosSeleccionados;
            listBox_RubrosSeleccionados.ValueMember = "rubro_id";
            listBox_RubrosSeleccionados.DisplayMember = "rubro_desc";

            comboBox_Visibilidad.DataSource = dt_Visibilidades;
            comboBox_Visibilidad.ValueMember = "visib_cod";
            comboBox_Visibilidad.DisplayMember = "visib_desc";

            comboBox_Visibilidad.SelectedValue = datos_Publicacion[2];
            //Sheno el combobox de visibilidad:
            
            

            //Sheno los otros campos
            textBox_Descripcion.Text = datos_Publicacion[3].ToString();
            textBox_Stock.Text = datos_Publicacion[4].ToString();
            textBox_Precio.Text = datos_Publicacion[7].ToString();
            if (datos_Publicacion[10].ToString() == "YES") checkBox_PermitirPreguntas.Checked = true;
            else checkBox_PermitirPreguntas.Checked = false;
            comboBox_Estado.SelectedItem = datos_Publicacion[9];



        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_AgregarRubro_Click(object sender, EventArgs e)
        {
            bool no_esta = true;

            for (int i = 0; i < listBox_RubrosSeleccionados.Items.Count; i++)
            {
                if (((DataRowView)listBox_RubrosSeleccionados.Items[i])["rubro_id"].ToString() == listBox_Rubros.SelectedValue.ToString())
                {
                    MessageBox.Show("Ya esta en la lista");
                    no_esta = false;
                    break;
                }
            }
            //if (no_esta) listBox2.Items.Add(listBox1.SelectedValue);

            if (no_esta)
            {
                DataRowView rowView1 = listBox_Rubros.SelectedItem as DataRowView;
                if (null == rowView1)
                {
                    return;
                }
                dt_RubrosSeleccionados.ImportRow(rowView1.Row);
            }

        }

        private void button_QuitarRubro_Click(object sender, EventArgs e)
        {
            DataRowView rowView = listBox_RubrosSeleccionados.SelectedItem as DataRowView;

            if (null == rowView)
            {
                return;
            }

            dt_RubrosSeleccionados.Rows.Remove(rowView.Row);
        }

        private void button_ModificarPublicacion_Click(object sender, EventArgs e)
        {
            bool datos_ok = true;

            if (textBox_Descripcion.Text == "")
            {
                datos_ok = false;
                label_ErrorDescripcion.Text = "(*)";
            }
            else
            {
                label_ErrorDescripcion.Text = "";
            }

            decimal precio;
            if (!Decimal.TryParse(textBox_Precio.Text, out precio))
            {
                datos_ok = false;
                label_ErrorPrecio.Text = "(*)";
            }
            else
            {
                label_ErrorPrecio.Text = "";
            }

            int stock;
            if (!Int32.TryParse(textBox_Stock.Text, out stock))
            {
                datos_ok = false;
                label_ErrorStock.Text = "(*)";
            }
            else
            {
                if(stock_Anterior>(Int32.Parse(textBox_Stock.Text)))//Si se puso menos stock q antes
                {
                    datos_ok = false;
                    label_ErrorStock.Text = "(*)";
                }
                else
                {
                label_ErrorStock.Text = "";
                }
            }

            if (listBox_RubrosSeleccionados.Items.Count == 0)
            {
                datos_ok = false;
                label_ErrorRubros.Text = "(*) DEBE ELEGIR ALMENOS UN RUBRO";
            }
            else
            {
                label_ErrorRubros.Text = "";
            }


            if (datos_ok)
            {
                modificar_Publicacion();
            }
            else
            {
                label_ErrorMensaje.Text = "(*) LOS CAMPOS TIENEN INFORMACIÓN NO VALIDA.";
            }
        }

        private void modificar_Publicacion()
        {
            //pub_cod -> de acá saco el codigo de la publicacion para el update
            SqlConnection conexion = this.crearConexion();
            SqlCommand comando = new SqlCommand("BE_SHARPS.modificarPublicacion", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@fecha",obtenerFecha()); //agrego fecha
            comando.Parameters.AddWithValue("@id_publicacion",pub_cod);
            comando.Parameters.AddWithValue("@id_visibilidad",comboBox_Visibilidad.SelectedValue);
            comando.Parameters.AddWithValue("@descripcion",textBox_Descripcion.Text);
            //comando.Parameters.AddWithValue("@fecha_inicio",DBNull.Value);
            //comando.Parameters.AddWithValue("@fecha_vencimiento",DBNull.Value);
            comando.Parameters.AddWithValue("@precio",Decimal.Parse(textBox_Precio.Text));
            comando.Parameters.AddWithValue("@stock", textBox_Stock.Text);
            comando.Parameters.AddWithValue("@estado",comboBox_Estado.SelectedItem);
            if (checkBox_PermitirPreguntas.Checked) comando.Parameters.AddWithValue("@preguntas", "YES");
            else comando.Parameters.AddWithValue("@preguntas", "NO");

            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            finally
            {
                conexion.Close();
            }
            //FALTA VER QUE ONDA CON LOS RUBROS!! (PREGUNTAR A PABLITO ASI LO CAMBIO DIRECTAMENTE EN GENERAR PUBLI TMB)

            //Hago delete que tengo en la tabla de PublicacionXRubro
            SqlConnection conexion2 = this.crearConexion();
            string delete = "DELETE BE_SHARPS.PublicacionXRubro where publi_pub = "+pub_cod;
            SqlCommand comando2 = new SqlCommand(delete, conexion2);
            conexion2.Open();
            comando2.ExecuteNonQuery();
            conexion2.Close();

            //Vuelvo a agregar los rubros:
            int rubro;
            SqlConnection conexion3 = this.crearConexion();
            SqlCommand comando3 = new SqlCommand("BE_SHARPS.agregarRubroAPublicacion", conexion3);
            comando3.CommandType = CommandType.StoredProcedure;
            comando3.Parameters.AddWithValue("@id_publicacion", pub_cod);
            comando3.Parameters.Add("@rubro_id", SqlDbType.Int);
            for (int i = 0; i < listBox_RubrosSeleccionados.Items.Count; i++)
            {
                listBox_RubrosSeleccionados.SelectedIndex = i;


                rubro = int.Parse(listBox_RubrosSeleccionados.SelectedValue.ToString());

                comando3.Parameters["@rubro_id"].Value = rubro;
                try
                {
                    conexion3.Open();
                    comando3.ExecuteNonQuery();
                }
                finally
                {
                    conexion3.Close();
                }
            }

            this.Hide();
            MessageBox.Show("Se modificó correctamente la publicación nº: " + pub_cod);
            this.DialogResult = DialogResult.OK;
            this.Close();

       
        }


    }
}
