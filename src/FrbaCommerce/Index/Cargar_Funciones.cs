using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions; //agregada
using System.Collections; // agregada
using System.Data.SqlClient; // agregada

namespace FrbaCommerce.Index
{
    public partial class Cargar_Funciones : Form1
    {
        private int usuario_id;
        private string usuario_user;
        public Cargar_Funciones(string[] rol, int user_id) // me llama Elegir_Rol
        {
            InitializeComponent();
            txt_Rol.Text = rol[1];
            usuario_id = user_id;
            txtBx_UsuarioID.Text = user_id.ToString();
            usuario_user = obtenerUsuarioUser(usuario_id);        


            // deberia a la talaba t_funcioens agregarle id para luego hacer el switch case por id y no por el nombre de la funcion
            string consulta = "SELECT id, rfun_fun FROM BE_SHARPS.Rol_Funcion, BE_SHARPS.t_funciones where funcion=rfun_fun and rfun_rol_id =" + rol[0];


            adaptador(consulta, ref listBox1, "id", "rfun_fun");
            /*
            SqlConnection con = crearConexion();
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Rol_Funcion");
            DataTable dt = ds.Tables[0];

            listBox1.DataSource = dt;
            listBox1.ValueMember = "rfun_fun";
            listBox1.DisplayMember = "rfun_fun";
            */

        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            int funcion = int.Parse(((DataRowView)listBox1.Items[listBox1.SelectedIndex])["id"].ToString()); // me habia empezado a tirar error
            //string name = ((DataRowView)comboBox1.Items[e.Index])["name"];
            // a funcion debería asignarle el id de la funcion y sino directamente hago string funcion y le asigno el valueMember

            switch (funcion)
            {
                case 1: // ABM Cliente
                    Abm_Cliente.Abm_Cliente ABM_C = new Abm_Cliente.Abm_Cliente();
                    this.Hide();
                    ABM_C.ShowDialog();
                    this.Show();
                    break;

                case 2: // ABM Empresa
                    Abm_Empresa.Abm_Empresa ABM_E = new Abm_Empresa.Abm_Empresa();
                    this.Hide();
                    ABM_E.ShowDialog();
                    this.Show();
                    break;
                case 3: // ABM Rol
                    ABM_Rol.Abm_Rol ABM_R = new ABM_Rol.Abm_Rol();
                    this.Hide();
                    ABM_R.ShowDialog();
                    this.Show();
                    break;

                case 4: // ABM Visibilidad
                    Abm_Visibilidad.Abm_Visibilidad ABM_V = new Abm_Visibilidad.Abm_Visibilidad();
                    this.Hide();
                    ABM_V.ShowDialog();
                    this.Show();
                    break;

                case 5: // Listado estadistico
                    Listado_Estadistico.Listado_Estadistico L_E = new Listado_Estadistico.Listado_Estadistico();
                    this.Hide();
                    L_E.ShowDialog();
                    this.Show();
                    break;

                case 6: // Comprar - Ofertar
                    string consulta = "SELECT COUNT(*) FROM BE_SHARPS.Compras where comp_calif_cod is null and comp_comprador_id="
                        + usuario_id;
                    SqlConnection con = this.crearConexion();
                    SqlDataAdapter adapter = new SqlDataAdapter(consulta,con);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds,"BE_SHARPS.Compras");
                    int compras_pendientes = int.Parse(ds.Tables[0].Rows[0][0].ToString());


                    if (compras_pendientes < 5) 
                    {   
                        Comprar_Ofertar.Buscar CO = new Comprar_Ofertar.Buscar(usuario_id);
                        this.Hide();
                        CO.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Opcion bloqueada. Para desbloquearla, califique sus compras pendientes.");
                    }
                    break;

                case 7: // Generar Publicacion
                    Generar_Publicacion.Tipo_Publicacion T_P = new Generar_Publicacion.Tipo_Publicacion(usuario_user);
                    this.Hide();
                    T_P.ShowDialog();
                    this.Show();
                    break;

                case 8: // Editar publicacion
                    Editar_Publicacion.Listar_Publicaciones L_P = new Editar_Publicacion.Listar_Publicaciones(usuario_user);
                    this.Hide();
                    L_P.ShowDialog();
                    this.Show();
                    break;

                case 9: // Facturar publicaciones
                    Facturar_Publicaciones.Ventas_Realizadas F_P = new Facturar_Publicaciones.Ventas_Realizadas(usuario_user);
                    this.Hide();
                    F_P.ShowDialog();
                    this.Show();
                    break;

                case 10: // Gestion preguntas
                    Gestion_de_Preguntas.IndexPreguntas IP = new Gestion_de_Preguntas.IndexPreguntas(usuario_id);
                    this.Hide();
                    IP.ShowDialog();
                    this.Show();
                    break;

                case 11: // Historial
                    Historial_Cliente.Historial_Cliente H_C = new Historial_Cliente.Historial_Cliente(usuario_user);
                    this.Hide();
                    H_C.ShowDialog();
                    this.Show();
                    break;
            
                case 12: // Calificar compras
                    Calificar_Vendedor.Calificar C_V = new Calificar_Vendedor.Calificar(usuario_id);
                    this.Hide();
                    C_V.ShowDialog();
                    this.Show();
                    break;

                case 13: // Calificar compras
                    Facturar_Publicaciones.Admin_Fact A_F = new Facturar_Publicaciones.Admin_Fact();
                    this.Hide();
                    A_F.ShowDialog();
                    this.Show();
                    break;

                case 14: // Editar perfil
                    SqlConnection con2 = this.crearConexion();
                    SqlCommand cmd = new SqlCommand("BE_SHARPS.tipoUsuario", con2);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@usuario", usuario_id);

                    SqlParameter ret_tipoVendedor = cmd.Parameters.Add("@tipoVendedor", SqlDbType.Char, 1); // hay que especificar la longitud de char
                    SqlParameter ret_idTipoVendedor = cmd.Parameters.Add("@idTipoVendedor", SqlDbType.Int);

                    ret_tipoVendedor.Direction = ParameterDirection.Output;
                    ret_idTipoVendedor.Direction = ParameterDirection.Output;

                    con2.Open();
                    cmd.ExecuteNonQuery();
                    char tipoVendedor = char.Parse(cmd.Parameters["@tipoVendedor"].Value.ToString());
                    int idTipoVendedor = (int)cmd.Parameters["@idTipoVendedor"].Value;
                    con2.Close();

                    if (tipoVendedor == 'C')
                    {
                        ArrayList datos_Usuario = this.obtener_Datos_Usuario(usuario_user);
                        Abm_Cliente.Modificar_Cliente M_C = new Abm_Cliente.Modificar_Cliente(datos_Usuario);
                        this.Hide();
                        M_C.ShowDialog();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    if (tipoVendedor == 'E')
                    {
                        ArrayList datos_Empresa = this.obtener_Datos_Empresa(usuario_user);
                        Abm_Empresa.Modificar_Empresa M_E = new Abm_Empresa.Modificar_Empresa(datos_Empresa);
                        this.Hide();
                        M_E.ShowDialog();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }

                    break;
                default:
                    MessageBox.Show("Entro por default, ocurrió algo inesperado");
                    break;
            }
        }
    }
}
