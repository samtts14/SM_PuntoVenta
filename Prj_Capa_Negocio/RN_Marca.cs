using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Prj_Capa_Datos;

namespace Prj_Capa_Negocio
{
    public class RN_Marca
    {
        //REGISTRAR
        public void RN_Registrar_Marca(string nomMarca)
        {
            BD_Marcas obj = new BD_Marcas();
            obj.BD_Registrar_Marca(nomMarca);
        }

        //EDITAR
        public void RN_Editar_Marca(int idmar, string nomMarca)
        {
            BD_Marcas obj = new BD_Marcas();
            obj.BD_Editar_Marca(idmar, nomMarca);
        }

        //MOSTRAR
        public DataTable RN_Mostrar_Todas_Marcas()
        {
            BD_Marcas obj = new BD_Marcas();
            return obj.BD_Mostrar_Todas_Marcas();
        }

        //ELIMINAR

        public void RN_Eliminar_Marca(int idmar)
        {
            BD_Marcas obj = new BD_Marcas();
            obj.BD_Eliminar_Marca(idmar);
        }
    }
}
