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

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class Detalle_Publicacion : Form1
    {
        private int pub_codigo;
        private int usuario_id;
        private int vendedor_id;
        private string preg_habilitadas;

        public Detalle_Publicacion(int pub_cod, int u_id)
        {
            InitializeComponent();
            pub_codigo = pub_cod;
            usuario_id = u_id; // ACA ESTABA HARDCODEADO EL USUARIO
            btn_Comprar.Hide();
            btn_Ofertar.Hide();
            label_UnidComprar.Hide();
            txtBx_UnidComprar.Hide();
            txtBx_PrecioCompra.Hide();
            label_PrecioCompra.Hide();
            
            label_Error.Text = "";
            label_MsjRevisar.Text = "";
            label_Preguntas.Text = "";

            
            ArrayList datos_pub = this.obtener_Datos_Publicacion(pub_cod);

            vendedor_id = int.Parse(datos_pub[1].ToString());

            txtBx_pub_usuarioid.Text = datos_pub[1].ToString();
            txtBx_Desc.Text = datos_pub[3].ToString();
            txtBx_Stock.Text = datos_pub[4].ToString();
            txtBx_FecPub.Text = datos_pub[5].ToString();
            txtBx_FecVenc.Text = datos_pub[6].ToString();
            txtBx_Precio.Text = datos_pub[7].ToString();
            preg_habilitadas = datos_pub[10].ToString(); // preguntas habilitadas

            if (preg_habilitadas == "NO")
                label_Preguntas.Text = "Las preguntas no están habilitadas para esta publicación";

            string pub_tipo = datos_pub[8].ToString();

            switch (pub_tipo.ToLower())
            {   
                case "compra inmediata":
                    btn_Comprar.Show();
                    label_UnidComprar.Show();
                    txtBx_UnidComprar.Show();
                    txtBx_PrecioCompra.Show();
                    label_PrecioCompra.Show();
                    break;
                case "subasta":
                    btn_Ofertar.Show();
                    break;
                default:
                    MessageBox.Show("No se conoce el tipo de publicacion");
                    break;
            }     
                      
         }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Comprar_Click(object sender, EventArgs e)
        {
            int ret;
            if (int.TryParse(txtBx_UnidComprar.Text, out ret) == true && (int.Parse(txtBx_UnidComprar.Text) <= int.Parse(txtBx_Stock.Text))
                && (int.Parse(txtBx_UnidComprar.Text)>0))
            {
                double precioCompra= double.Parse(txtBx_Precio.Text) * double.Parse(txtBx_UnidComprar.Text);
                txtBx_PrecioCompra.Text = precioCompra.ToString();

                DialogResult advertencia =
                MessageBox.Show("¿Está seguro que desea realizar la compra?", "Advertencia", MessageBoxButtons.YesNo); 
                // Botonera de advertencia que se va a eliminar
                
                if (advertencia == DialogResult.Yes)
                {
                    // para que este bien bien habria que hacer un trigger y atender la excepcion en caso que corresponda  
                    //cmd.Parameters.AddWithValue("@cantidad", double.Parse(txtBx_UnidComprar.Text));

                    this.Hide();
                    Comprar_Ofertar.Datos_Vendedor D_V =
                        new Comprar_Ofertar.Datos_Vendedor(vendedor_id, int.Parse(txtBx_UnidComprar.Text), pub_codigo, usuario_id);
                    D_V.ShowDialog();
                    //this.Show();
                    this.Close();
                    /*
                    if (D_V.DialogResult == DialogResult.OK)
                    {
                        label_MsjRevisar.Text = "La compra ha sido realizada";
                        label_MsjRevisar.ForeColor = System.Drawing.Color.Green; 
                    }
                    else
                    {
                        label_MsjRevisar.Text = "No se pudo realizar la compra. Cierre esta ventana para continuar";
                        label_MsjRevisar.ForeColor = System.Drawing.Color.Red; 
                    }
                    */
                                       
                }
                else
                {
                    label_Error.Text = "";
                    label_MsjRevisar.Text = "Se canceló la compra";
                }
            }
            else
            {
                label_Error.Text = "(*)";
                label_MsjRevisar.Text = "(*) LOS CAMPOS CONTIENEN INFORMACIÓN NO VÁLIDA";
            }
            
        }

        private void btn_Preguntar_Click(object sender, EventArgs e)
        {
            if (preg_habilitadas == "YES")
            {
                Preguntar P = new Preguntar(pub_codigo, usuario_id);
                this.Hide();
                P.ShowDialog();
                this.Show();
            }
            else
            {
                label_Preguntas.ForeColor = System.Drawing.Color.Red; 
                MessageBox.Show("Esta publicación no tiene las preguntas habilitadas");
            }
        }

        private void txtBx_UnidComprar_TextChanged(object sender, EventArgs e)
        {
            int ret;
            if ( int.TryParse(txtBx_UnidComprar.Text, out ret)==true && (int.Parse(txtBx_UnidComprar.Text) <= int.Parse(txtBx_Stock.Text)))
            {
                double precioCompra = double.Parse(txtBx_Precio.Text) * double.Parse(txtBx_UnidComprar.Text);
                txtBx_PrecioCompra.Text = precioCompra.ToString();
            }
            else
            {
                label_Error.Show();
                label_MsjRevisar.Show();
            }
        }

        private void btn_Ofertar_Click(object sender, EventArgs e)
        {
            Comprar_Ofertar.Ofertar O = new Comprar_Ofertar.Ofertar(pub_codigo, decimal.Parse(txtBx_Precio.Text), usuario_id);
            this.Hide();
            O.ShowDialog();
            this.Show();
        }
    }
}
