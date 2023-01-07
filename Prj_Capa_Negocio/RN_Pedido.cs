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
    public class RN_Pedido
    {
        public void RN_Registrar_Pedido(EN_Pedido ped)
        {
            BD_Pedido obj = new BD_Pedido();
            obj.BD_Registrar_Pedido(ped);
        }

        public void RN_Editar_Pedido(EN_Pedido ped)
        {
            BD_Pedido obj = new BD_Pedido();
            obj.BD_Editar_Pedido(ped);
        }

        public void RN_Registrar_Detalle_Pedido(EN_Det_Pedido det)
        {
            BD_Pedido obj = new BD_Pedido();
            obj.BD_Registrar_Detalle_Pedido(det);
        }

        public void RN_Eliminar_Detalle_Pedido(string idpedido)
        {
            BD_Pedido obj = new BD_Pedido();
            obj.BD_Eliminar_Detalle_Pedido(idpedido);
        }

        public bool RN_Verificar_Pedido(string NroPedido)
        {
            BD_Pedido obj = new BD_Pedido();
            return obj.BD_Verificar_Pedido(NroPedido);
        }

        public void RN_Poner_Pedido_Como_Atendido(string idpedido)
        {
            BD_Pedido obj = new BD_Pedido();
            obj.BD_Poner_Pedido_Como_Atendido(idpedido);
        }

        public void RN_Cambiar_Cliente_dePedido(string idpedido, string idcliente)
        {
            BD_Pedido obj = new BD_Pedido();
            obj.BD_Cambiar_Cliente_dePedido(idpedido, idcliente);
        }

        public void RN_Eliminar_Pedido_Permanente(string idpedido)
        {
            BD_Pedido obj = new BD_Pedido();
            obj.BD_Eliminar_Pedido_Permanente(idpedido);
        }

        public DataTable RN_Buscar_Pedidpo_para_Editar(string idpedido)
        {
            BD_Pedido obj = new BD_Pedido();
            return obj.BD_Buscar_Pedidpo_para_Editar(idpedido);
        }

        public DataTable RN_Cargar_Pedidos_porValor(string IdPedido)
        {
            BD_Pedido obj = new BD_Pedido();
            return obj.BD_Cargar_Pedidos_porValor(IdPedido);
        }

        public DataTable RN_Cargar_Pedidos_porFecha(string tipo, DateTime xfecha)
        {
            BD_Pedido obj = new BD_Pedido();
            return obj.BD_Cargar_Pedidos_porFecha(tipo, xfecha);
        }

        public DataTable RN_Cargar_Pedidos_porAtender()
        {
            BD_Pedido obj = new BD_Pedido();
            return obj.BD_Cargar_Pedidos_porAtender();
        }
    }
}
