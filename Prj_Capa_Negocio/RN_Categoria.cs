using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prj_Capa_Datos;

namespace Prj_Capa_Negocio
{
    public class RN_Categoria
    {

        public void RN_Registrar_Categoria(string nomCateg)
        {
            BD_Categoria obj = new BD_Categoria();
            obj.BD_Registrar_Categoria(nomCateg);
        }

        //****************EDITAR CATEGORIA********************

        public void RN_Editar_Categoria(int idcateg, string nomCateg)
        {
            BD_Categoria obj = new BD_Categoria();
            obj.BD_Editar_Categoria(idcateg, nomCateg);
        }

        //**************MOSTRAR****************

        public DataTable RN_Mostrar_Todas_Categorias()
        {
            BD_Categoria obj = new BD_Categoria();
            return obj.BD_Mostrar_Todas_Categorias();
        }

    }
}
