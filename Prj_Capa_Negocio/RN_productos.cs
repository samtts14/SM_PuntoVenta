using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;

namespace Prj_Capa_Negocio
{
    public class RN_productos
    {
        public void RN_Registrar_Producto(EN_Producto pro)
        {
            BD_Productos obj = new BD_Productos();
            obj.BD_Registrar_Producto(pro);
        }

        public void RN_Editar_Producto(EN_Producto pro)
        {
            BD_Productos obj = new BD_Productos();
            obj.BD_Editar_Producto(pro);
        }

        public DataTable RN_Mostrar_Todos_Productos()
        {
            BD_Productos obj = new BD_Productos();
            return obj.BD_Mostrar_Todos_Productos();
        }

        public DataTable RN_Buscar_Productos(string valor)
        {
            BD_Productos obj = new BD_Productos();
            return obj.BD_Buscar_Productos(valor);
        }

        public void RN_darBaja_Producto(string idprod)
        {
            BD_Productos obj = new BD_Productos();
            obj.BD_darBaja_Producto(idprod);
        }

        public void RN_Eliminar_Producto(string idprod)
        {
            BD_Productos obj = new BD_Productos();
            obj.BD_Eliminar_Producto(idprod);
        }

        public void RN_Sumar_Stock_Producto(string idprod, double stock)
        {
            BD_Productos obj = new BD_Productos();
            obj.BD_Sumar_Stock_Producto(idprod, stock);
        }

        public void RN_Restar_Stock_Producto(string idprod, double stock)
        {
            BD_Productos obj = new BD_Productos();
            obj.BD_Restar_Stock_Producto(idprod, stock);
        }
        public void RN_Actualizar_PrecioCompra_Producto(string idprod, double precompraPesos, double preVenta_mnor, double utilidad, double valoralmacen)
        {
            BD_Productos obj = new BD_Productos();
            obj.BD_Actualizar_PrecioCompra_Producto(idprod, precompraPesos, preVenta_mnor, utilidad, valoralmacen);
        }

    }
}
