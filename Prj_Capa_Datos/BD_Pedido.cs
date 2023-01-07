using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Prj_Capa_Entidad;
using System.Data.SqlClient;

namespace Prj_Capa_Datos
{
    public class BD_Pedido : BDConexion
    {
        public static bool seguardo = false;
        public static bool detseguardo = false;
        //insertar
        public void BD_Registrar_Pedido(EN_Pedido ped)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Pedido", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Ped", ped.IdPedido);
                cmd.Parameters.AddWithValue("@Id_Cliente", ped.IdCliente);
                cmd.Parameters.AddWithValue("@SubTotal", ped.SubTotal);
                cmd.Parameters.AddWithValue("@IgvPed", ped.Igv);
                cmd.Parameters.AddWithValue("@TotalPed", ped.TotalPed);
                cmd.Parameters.AddWithValue("@id_Usu", ped.IdUsu);
                cmd.Parameters.AddWithValue("@TotalGancia", ped.TotalGanancia);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seguardo = true;


            }
            catch (Exception ex)
            {
                seguardo = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar: " + ex.Message, "Registrar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Editar Pedido
        public void BD_Editar_Pedido(EN_Pedido ped)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Editar_Pedido", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Ped", ped.IdPedido);
                cmd.Parameters.AddWithValue("@Id_Cliente", ped.IdCliente);
                cmd.Parameters.AddWithValue("@SubTotal", ped.SubTotal);
                cmd.Parameters.AddWithValue("@IgvPed", ped.Igv);
                cmd.Parameters.AddWithValue("@TotalPed", ped.TotalPed);
                cmd.Parameters.AddWithValue("@id_Usu", ped.IdUsu);
                cmd.Parameters.AddWithValue("@TotalGancia", ped.TotalGanancia);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seguardo = true;


            }
            catch (Exception ex)
            {
                seguardo = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar: " + ex.Message, "Registrar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //detalle
        public void BD_Registrar_Detalle_Pedido(EN_Det_Pedido det)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Registrar_detalle_Pedido", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Ped", det.IdPed);
                cmd.Parameters.AddWithValue("@Id_Pro", det.IdProd);
                cmd.Parameters.AddWithValue("@Precio", det.Precio);
                cmd.Parameters.AddWithValue("@Cantidad", det.Cantidad);
                cmd.Parameters.AddWithValue("@Importe", det.Importe);
                cmd.Parameters.AddWithValue("@Tipo_Prod", det.TipoProd);
                cmd.Parameters.AddWithValue("@Und_Medida", det.Und);
                cmd.Parameters.AddWithValue("@Utilidad_Unit", det.Utilidad_Unit);
                cmd.Parameters.AddWithValue("@TotalUtilidad", det.TotalUtilidad);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                detseguardo = true;


            }
            catch (Exception ex)
            {
                detseguardo = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar: " + ex.Message, "Registrar detalle de pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Eliminar detalle pedido
        public void BD_Eliminar_Detalle_Pedido(string idpedido)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_eliminar_detalle_Pedido", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Ped", idpedido);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                detseguardo = true;


            }
            catch (Exception ex)
            {
                detseguardo = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al eliminar: " + ex.Message, "Eliminar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Verificar
        public bool BD_Verificar_Pedido(string NroPedido)
        {
            bool respuesta = false;
            Int32 getvalue = 0;
            SqlConnection cn = new SqlConnection();

            try
            {

                SqlCommand cmd = new SqlCommand();

                cn.ConnectionString = Conectar();
                cmd.CommandText = "Sp_Pedido_Atendido";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                //parametros
                cmd.Parameters.AddWithValue("@Id_Ped", NroPedido);

                cn.Open();
                getvalue = Convert.ToInt32(cmd.ExecuteScalar());
                if (getvalue > 0)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
                cmd.Parameters.Clear();
                cmd.Dispose();
                cmd = null;
                cn.Close();
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al verificar: " + ex.Message, "Verificar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                respuesta = false;
            }
            return respuesta;
        }

        //Poner pedido como atendido
        public void BD_Poner_Pedido_Como_Atendido(string idpedido)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Pedido_Atendido", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Ped", idpedido);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                detseguardo = true;


            }
            catch (Exception ex)
            {
                detseguardo = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al eliminar: " + ex.Message, "Eliminar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Cambiar nombre del cliente del pedido
        public void BD_Cambiar_Cliente_dePedido(string idpedido, string idcliente)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Actu_clien_Ped", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Ped", idpedido);
                cmd.Parameters.AddWithValue("@Id_cli", idcliente);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                detseguardo = true;


            }
            catch (Exception ex)
            {
                detseguardo = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al cambiar: " + ex.Message, "Cambiar Cliente en el Pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Eliminar pedido permanente
        public void BD_Eliminar_Pedido_Permanente(string idpedido)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Eliminar_Pedido_Completo", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Ped", idpedido);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                detseguardo = true;


            }
            catch (Exception ex)
            {
                detseguardo = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al eliminar el pedido de forma permanente. " + ex.Message, "Eliminar Pedido Permanente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //*********CONSULTAS**********

        //Buscar pedido para editar
        public DataTable BD_Buscar_Pedidpo_para_Editar(string idpedido)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_Pedido_Para_Editar", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_Ped", idpedido);

                DataTable dato = new DataTable();
                da.Fill(dato);
                return dato;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar: " + ex.Message, "Cargar cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return null;
        }

        //Cargar pedidos valor
        public DataTable BD_Cargar_Pedidos_porValor(string IdPedido)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_buscar_Pedidos_porValor", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@valor", IdPedido);

                DataTable dato = new DataTable();
                da.Fill(dato);
                return dato;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al buscar pedido por valor: " + ex.Message, "Pedidos por valor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return null;
        }

        //Cargar pedidos fecha
        public DataTable BD_Cargar_Pedidos_porFecha(string tipo, DateTime xfecha)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Pedidos_porFecha", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@tipo", tipo);
                da.SelectCommand.Parameters.AddWithValue("@fecha", xfecha);

                DataTable dato = new DataTable();
                da.Fill(dato);
                return dato;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al buscar pedido por fecha: " + ex.Message, "Pedidos por fecha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return null;
        }

        //Leer pedidos fecha
        public DataTable BD_Cargar_Pedidos_porAtender()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Leer_Pedidos_PorAtender", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
           

                DataTable dato = new DataTable();
                da.Fill(dato);
                return dato;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al leer pedidos por fecha: " + ex.Message, "Pedidos por fecha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return null;
        }
    }
}
