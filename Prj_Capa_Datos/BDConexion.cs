using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Datos//21-02
{
   public class BDConexion
    {
        public string Conectar()
        {
            return "data source = DESKTOP-6JJKTNR; Initial Catalog= PuntoVentaSM; Integrated security= true"; 
            // Integrated security= true----- se pone si se conecta con autenticacion de windows. si es con usuario y contrasena se deben de poner ellos
            // ej: uid=sa; pwd=1497
        }

        public static string Conectar2()
        {
            return "data source = DESKTOP-6JJKTNR; Initial Catalog= PuntoVentaSM; Integrated security= true";
            
        }
    }
}
