using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prj_Capa_Datos;

namespace Prj_Capa_Negocio
{
    public class RN_Usuario
    {
        public bool RN_Login(string usu, string clave)
        {
            BD_Ususario obj = new BD_Ususario();
            return obj.BD_Login(usu, clave);
        }

        public DataTable RN_Buscar_Usuario(string nomusu)
        {
            BD_Ususario obj = new BD_Ususario();
            return obj.BD_Buscar_Usuario(nomusu);
        }

    }
}
