using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prj_Capa_Datos;
using Prj_Capa_Entidad;
using System.Data;

namespace Prj_Capa_Negocio
{
    public class RN_Ingreso_Compra
    {
        public void RN_Ingresar_Registrocompra(EN_IngresoCompra com)
        {
            BD_Ingreso_Compra obj = new BD_Ingreso_Compra();
            obj.BD_Ingresar_Registrocompra(com);
        }

        public void RN_Ingresar_Detalle_Registrocompra(EN_Det_IngresoCompra det)
        {
            BD_Ingreso_Compra obj = new BD_Ingreso_Compra();
            obj.BD_Ingresar_Detalle_Registrocompra(det);
        }

        public bool RN_Verificar_NroDoc_Fisico(string idfisico)
        {
            BD_Ingreso_Compra obj = new BD_Ingreso_Compra();
            return obj.BD_Verificar_NroDoc_Fisico(idfisico);
        }

        public DataTable RN_cargar_Todas_Compras()
        {
            BD_Ingreso_Compra obj = new BD_Ingreso_Compra();
            return obj.BD_cargar_Todas_Compras();
        }

        public DataTable RN_Buscar_Compras_Explorador(string valor)
        {
            BD_Ingreso_Compra obj = new BD_Ingreso_Compra();
            return obj.BD_Buscar_Compras_Explorador(valor);
        }
        public DataTable RN_Buscar_Compras_Explorador_Pormes_Dia(string tipo, DateTime fechames)
        {
            BD_Ingreso_Compra obj = new BD_Ingreso_Compra();
            return obj.BD_Buscar_Compras_Explorador_Pormes_Dia(tipo, fechames);
        }

        public void RN_borrar_Compra(string idcompra)
        {
            BD_Ingreso_Compra obj = new BD_Ingreso_Compra();
            obj.BD_borrar_Compra(idcompra);
        }
    }
}
