using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FrbaCommerce
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Abm_Cliente.Prueba());
            //Application.Run(new Abm_Cliente.Abm_Cliente());
            Application.Run(new Login.Login());
            //Application.Run(new Generar_Publicacion.Tipo_Publicacion("be_sharps_C1"));
           //Application.Run(new Abm_Visibilidad.Abm_Visibilidad());
            //Application.Run(new ABM_Rol.Abm_Rol());
            //Application.Run(new Login.Login());
            //Application.Run(new Comprar_Ofertar.Buscar(1));
            //Application.Run(new Abm_Empresa.Abm_Empresa());
            //Application.Run(new Generar_Publicacion.Tipo_Publicacion("be_sharps_C1"));
            //Application.Run(new Listado_Estadistico.Listado_Estadistico());
            //Application.Run(new Listado_Estadistico.Borrar());
        }
    }
}
