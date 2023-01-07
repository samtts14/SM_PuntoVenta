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
    public class RN_Cotizacion
    {
        public void RN_Registrar_Cotizacion(EN_Cotizacion coti)
        {
            BD_Cotizacion obj = new BD_Cotizacion();
            obj.BD_Registrar_Cotizacion(coti);
        }

        public void RN_Editar_Cotizacion(EN_Cotizacion coti)
        {
            BD_Cotizacion obj = new BD_Cotizacion();
            obj.BD_Editar_Cotizacion(coti);
        }

        public void RN_Cambiar_Estado_Cotizacion(string idCoti, string estado)
        {
            BD_Cotizacion obj = new BD_Cotizacion();
            obj.BD_Cambiar_Estado_Cotizacion(idCoti, estado);
        }

        public DataTable RN_Buscar_Cotizacion_paraEditar(string idCoti)
        {
            BD_Cotizacion obj = new BD_Cotizacion();
            return obj.BD_Buscar_Cotizacion_paraEditar(idCoti);
        }
    }
}
