using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.Generar_Publicacion
{
    public partial class Generar_Publicacion : Form1
    {
        private DataTable dt1;
        private DataTable dt2;
        
        private string tipo_pub;
        private string usuario_actual;
        public Generar_Publicacion(string tipo_publicacion, string usuario)
        {
            
            InitializeComponent();
            tipo_pub = tipo_publicacion;
            usuario_actual = usuario;

            comboBox_Estado.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Visibilidad.DropDownStyle = ComboBoxStyle.DropDownList;

            //Cargo en el listbox de Rubros todos los rubros:
            
            string consulta1 = "SELECT rubro_id, rubro_desc FROM BE_SHARPS.Rubros where rubro_habilitado = 1";
            string consulta2 = "SELECT rubro_id, rubro_desc FROM BE_SHARPS.Rubros where rubro_id is null"; //para q la listbox tenga el mismo formato pero este vacia
            SqlConnection con = this.crearConexion();

            con.Open();
            SqlDataAdapter adapter1 = new SqlDataAdapter(consulta1, con);
            SqlDataAdapter adapter2 = new SqlDataAdapter(consulta2, con);

            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();

            adapter1.Fill(ds1, "Rubros");
            adapter2.Fill(ds2, "Rubros");

            con.Close();
            dt1 = ds1.Tables[0];
            dt2 = ds2.Tables[0];

            listBox_Rubros.DataSource = dt1;
            listBox_Rubros.ValueMember = "rubro_id";
            listBox_Rubros.DisplayMember = "rubro_desc";

            listBox_RubrosSeleccionados.DataSource = dt2;
            listBox_RubrosSeleccionados.ValueMember = "rubro_id";
            listBox_RubrosSeleccionados.DisplayMember = "rubro_desc";

                        
            //Si es del tipo subasta, el stock es uno (y fijo)
            if (tipo_pub == "Subasta")
            {
                textBox_Stock.Text = "1";
                textBox_Stock.ReadOnly = true;
            }

            //Cargo las visibilidades en su comboBox
            string select2 = "select visib_desc FROM BE_SHARPS.Visibilidad where visib_habilitada = 1 order by visib_precio";
            SqlConnection conexion2 = this.crearConexion();
            SqlDataAdapter dataAdapter2 = new SqlDataAdapter(select2, conexion2);

            DataSet dataSet2 = new DataSet();
            conexion2.Open();
            dataAdapter2.Fill(dataSet2);
            conexion2.Close();

            comboBox_Visibilidad.DataSource = dataSet2.Tables[0];
            comboBox_Visibilidad.ValueMember = "visib_desc";

            //Valor Pre-Establecido del comboBox_Estado = "Publicada"
            //comboBox_Estado.SelectedItem = "Publicada";
            string select3 = "select estado_id, estado_nombre from be_sharps.estados where estado_habilitado = 1 and estado_nombre <> 'Finalizada'";
            SqlConnection conexion3 = this.crearConexion();
            SqlDataAdapter dataAdapter3 = new SqlDataAdapter(select3, conexion3);

            DataSet dataSet3 = new DataSet();
            conexion3.Open();
            dataAdapter3.Fill(dataSet3);
            conexion3.Close();

            comboBox_Estado.DataSource = dataSet3.Tables[0];
            comboBox_Estado.ValueMember = "estado_nombre";
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
                dt2.ImportRow(rowView1.Row);
            }
            
            /*
            for (int i = 0; i < listBox_RubrosSeleccionados.Items.Count; i++)
            {
                if (listBox_Rubros.SelectedValue == listBox_RubrosSeleccionados.Items[i])
                {
                    no_esta = false;
                    break;
                }
            }
            if (no_esta) listBox_RubrosSeleccionados.Items.Add(listBox_Rubros.SelectedValue);
            */
        }


        private void button_QuitarRubro_Click(object sender, EventArgs e)
        {
            //No entiendo xq con selectedValue no me devuelve el string que tengo seleccionado
            DataRowView rowView = listBox_RubrosSeleccionados.SelectedItem as DataRowView;

            if (null == rowView)
            {
                return;
            }

            dt2.Rows.Remove(rowView.Row);
            //listBox_RubrosSeleccionados.Items.Remove(listBox_RubrosSeleccionados.SelectedItem);
        }
  
    
        private void button_CrearPublicacion_Click(object sender, EventArgs e)
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
                label_ErrorStock.Text = "";
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

            if (comboBox_Visibilidad.SelectedValue.ToString() == "Gratis" && comboBox_Estado.SelectedValue.ToString() != "Borrador")
            {
                string s_gratuitas = "SELECT COUNT(*) FROM BE_SHARPS.Publicaciones, BE_SHARPS.Usuarios where "
                +"pub_id_usuario=usuario_id and usuario_user = '" +usuario_actual+ "' "
		        +"and pub_visibilidad_cod=10006 and (pub_estado='Publicada' or pub_estado='Pausada')";

                SqlConnection con = this.crearConexion();
                SqlCommand cmd = new SqlCommand(s_gratuitas, con);
                con.Open();
                int gratuitas = (int)cmd.ExecuteScalar();
                con.Close();

                if (gratuitas > 2) // si entra es porque no puede crear otra pub gratuita
                {
                    MessageBox.Show("Atención: No puede publicar otra publicación gratuita ya que actualmente tiene\n" 
		            +"el máximo permitido (3) de publicaciones gratuitas activas simultaneamente.\n"
                    +"Elija otro tipo de Visibilidad o creela en Borrador.");
                    label_ErrorVisibilidad.Text = "(*)";
                    datos_ok = false;
                }
                else
                {
                    label_ErrorVisibilidad.Text = "";
                }
            }
            else
            {
                label_ErrorVisibilidad.Text = "";
            }


            if (datos_ok)
            {
                crear_Publicacion();
            }
            else
            {
                label_ErrorMensaje.Text = "(*) LOS CAMPOS TIENEN INFORMACIÓN NO VALIDA.";
            }
           
        }

        private void crear_Publicacion()
        {
            SqlConnection conexion = this.crearConexion();
            SqlCommand comando = new SqlCommand("BE_SHARPS.crearPublicacion", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@fecha", obtenerFecha());
            //MessageBox.Show("Usuario actual: " + usuario_actual);
            comando.Parameters.AddWithValue("@usuario", usuario_actual);
            comando.Parameters.AddWithValue("@tipo_publicacion", tipo_pub);
            comando.Parameters.AddWithValue("@descripcion", textBox_Descripcion.Text);
            comando.Parameters.AddWithValue("@stock", textBox_Stock.Text);
            //Corto el precio a dos decimales:
            decimal precio = Decimal.Parse(textBox_Precio.Text);
            precio = Math.Round(precio, 2, MidpointRounding.ToEven);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@visibilidad", comboBox_Visibilidad.SelectedValue.ToString());
            //MessageBox.Show("La visibilidad es: " + comboBox_Visibilidad.SelectedValue.ToString());
            comando.Parameters.AddWithValue("@estado", comboBox_Estado.SelectedValue.ToString());
            //MessageBox.Show("El estado es: " + comboBox_Estado.SelectedValue.ToString());
            if (checkBox_PermitirPreguntas.Checked) comando.Parameters.AddWithValue("@preguntas", "YES");
            else comando.Parameters.AddWithValue("@preguntas", "NO");

            SqlParameter retorno = comando.Parameters.Add("@id_publicacion", SqlDbType.Int);
            retorno.Direction = ParameterDirection.Output;

            //MessageBox.Show("Seguro de terminar??");
            bool ok = true;
            int id_publicacion = 0;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                id_publicacion = (int)comando.Parameters["@id_publicacion"].Value;
                conexion.Close();
            }
            catch (SqlException ex)
            {
                ok = false;
                SqlError err = ex.Errors[0];
                MessageBox.Show(err.Message);               
            }
            
            //AGREGO LOS RUBROS
            if ( (ok == true) && (id_publicacion!=0) )
            {
                int rubro;
                SqlConnection conexion2 = this.crearConexion();
                SqlCommand comando2 = new SqlCommand("BE_SHARPS.agregarRubroAPublicacion", conexion2);
                comando2.CommandType = CommandType.StoredProcedure;
                comando2.Parameters.AddWithValue("@id_publicacion", id_publicacion);
                comando2.Parameters.Add("@rubro_id", SqlDbType.Int);
                for (int i = 0; i < listBox_RubrosSeleccionados.Items.Count; i++)
                {
                    listBox_RubrosSeleccionados.SelectedIndex = i;


                    rubro = int.Parse(listBox_RubrosSeleccionados.SelectedValue.ToString());

                    comando2.Parameters["@rubro_id"].Value = rubro;
                    try
                    {
                        conexion2.Open();
                        comando2.ExecuteNonQuery();
                    }
                    finally
                    {
                        conexion2.Close();
                    }
                }

                MessageBox.Show("Publicación creada exitosamente.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }
        
    }
}
