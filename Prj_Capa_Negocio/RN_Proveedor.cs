using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;

namespace Prj_Capa_Negocio
{
    public class RN_Proveedor
    {
        public void RN_Registrar_Proveedor(EN_Proveedor pro)
        {
            BD_Proveedor obj = new BD_Proveedor();
            obj.BD_Registrar_Proveedor(pro);
        }

        public void RN_Editar_Proveedor(EN_Proveedor pro)
        {
            BD_Proveedor obj = new BD_Proveedor();
            obj.BD_Editar_Proveedor(pro);
        }

        public DataTable RN_Mostrar_Todos_Proveedores()
        {
            BD_Proveedor obj = new BD_Proveedor();
            return obj.BD_Mostrar_Todos_Proveedores();
        }

        public DataTable RN_Buscar_Proveedores(string valor)
        {
            BD_Proveedor obj = new BD_Proveedor();
            return obj.BD_Buscar_Proveedores(valor);
        }
    }
}
