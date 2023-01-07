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
    public class RN_TipoDoc
    {
        public static string RN_NroID(int idtipo)
        {
          return  BD_Tipo_Doc.BD_NroID(idtipo);
        }

        public static void RN_Actualizar_SiguienteNro_Correlativo(int idtipo)
        {
            BD_Tipo_Doc.BD_Actualizar_SiguienteNro_Correlativo(idtipo);
        }
        public static void RN_Actualizar_TipoCambio(int idtipo, double TipoCambio)
        {
            BD_Tipo_Doc.BD_Actualizar_TipoCambio(idtipo, TipoCambio);
        }
        public static double RN_Leer_TipoCambio(int idtipo)
        {
            return BD_Tipo_Doc.BD_Leer_TipoCambio(idtipo);
        }
        public static void RN_Actualizar_SiguienteNro_CorrelativoProducto(int idtipo)
        {
            BD_Tipo_Doc.BD_Actualizar_SiguienteNro_CorrelativoProducto(idtipo);
        }
    }
}
