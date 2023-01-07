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
    public class RN_Cliente
    {
        public bool RN_Verificar_NroDni(string NroDni)
        {
            BD_Cliente obj = new BD_Cliente();
            return obj.BD_Verificar_NroDni(NroDni);
        }

        public void RN_Insertar_Cliente(EN_Cliente cli)
        {
            BD_Cliente obj = new BD_Cliente();
            obj.BD_Insertar_Cliente(cli);
        }

        public void RN_Editar_Cliente(EN_Cliente cli)
        {
            BD_Cliente obj = new BD_Cliente();
            obj.BD_Editar_Cliente(cli);
        }

        public DataTable RN_CargarTodos_Clientes(string estado)
        {
            BD_Cliente obj = new BD_Cliente();
            return obj.BD_CargarTodos_Clientes(estado);
            
        }

        public DataTable RN_Buscar_Clientes(string valor, string estado)
        {
            BD_Cliente obj = new BD_Cliente();
            return obj.BD_Buscar_Clientes(valor, estado);
        }
        public void RN_dardeBaja_Cliente(string @idcliente)
        {
            BD_Cliente obj = new BD_Cliente();
            obj.BD_dardeBaja_Cliente(idcliente);
        }

        public void RN_Eliminar_Cliente(string @idcliente)
        {
            BD_Cliente obj = new BD_Cliente();
            obj.BD_Eliminar_Cliente(idcliente);
        }
    }
}
