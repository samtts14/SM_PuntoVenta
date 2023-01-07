using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Prj_Capa_Entidad;
using System.Windows.Forms;

namespace Prj_Capa_Datos
{
    public class BD_Productos : BDConexion
    {

        public static bool seguardo = false;
        public static bool seedito = false;

        //REGISTRAR
        public void BD_Registrar_Producto(EN_Producto pro)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_registrar_Producto", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", pro.Idprod);
                cmd.Parameters.AddWithValue("@idprove", pro.Idproveedor);
                cmd.Parameters.AddWithValue("@descripcion", pro.DescripcionGeneral);
                cmd.Parameters.AddWithValue("@frank", pro.Frank);
                cmd.Parameters.AddWithValue("@Pre_compraSol", pro.PreCompra_Sol);
                cmd.Parameters.AddWithValue("@pre_CompraDolar", pro.PreCompra_Dlr);
                cmd.Parameters.AddWithValue("@StockActual", pro.Stock);
                cmd.Parameters.AddWithValue("@idCat", pro.Idcat);
                cmd.Parameters.AddWithValue("@idMar", pro.Idmark);
                cmd.Parameters.AddWithValue("@Foto", pro.Foto);
                cmd.Parameters.AddWithValue("@Pre_Venta_Menor", pro.PreVenta_Mnr);
                cmd.Parameters.AddWithValue("@Pre_Venta_Mayor", pro.PreVenta_Myr);
                cmd.Parameters.AddWithValue("@Pre_Venta_Dolar", pro.PreVenta_Dolr);
                cmd.Parameters.AddWithValue("@UndMdida", pro.UndMedida);
                cmd.Parameters.AddWithValue("@PesoUnit", pro.PesoUnit);
                cmd.Parameters.AddWithValue("@Utilidad", pro.UtilidadUnity);
                cmd.Parameters.AddWithValue("@TipoProd", pro.TipoProducto);
                cmd.Parameters.AddWithValue("@ValorporProd", pro.ValorGeneral);

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
                MessageBox.Show("Error al guardar: " + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //EDITAR
        public void BD_Editar_Producto(EN_Producto pro)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Editar_Producto", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", pro.Idprod);
                cmd.Parameters.AddWithValue("@idprove", pro.Idproveedor);
                cmd.Parameters.AddWithValue("@descripcion", pro.DescripcionGeneral);
                cmd.Parameters.AddWithValue("@frank", pro.Frank);
                cmd.Parameters.AddWithValue("@Pre_compraSol", pro.PreCompra_Sol);
                cmd.Parameters.AddWithValue("@pre_CompraDolar", pro.PreCompra_Dlr);
                cmd.Parameters.AddWithValue("@idCat", pro.Idcat);
                cmd.Parameters.AddWithValue("@idMar", pro.Idmark);
                cmd.Parameters.AddWithValue("@Foto", pro.Foto);
                cmd.Parameters.AddWithValue("@Pre_Venta_Menor", pro.PreVenta_Mnr);
                cmd.Parameters.AddWithValue("@Pre_Venta_Mayor", pro.PreVenta_Myr);
                cmd.Parameters.AddWithValue("@Pre_Venta_Dolar", pro.PreVenta_Dolr);
                cmd.Parameters.AddWithValue("@UndMdida", pro.UndMedida);
                cmd.Parameters.AddWithValue("@PesoUnit", pro.PesoUnit);
                cmd.Parameters.AddWithValue("@Utilidad", pro.UtilidadUnity);
                cmd.Parameters.AddWithValue("@TipoProd", pro.TipoProducto);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seedito = true;


            }
            catch (Exception ex)
            {
                seedito = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar: " + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //MOSTRAR
        public DataTable BD_Mostrar_Todos_Productos()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_cargar_Todos_Productos", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable data = new DataTable();

                da.Fill(data);
                da = null;
                return data;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al consultar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        //BUSCAR
        public DataTable BD_Buscar_Productos(string valor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_buscador_Productos", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@valor", valor);
                DataTable data = new DataTable();

                da.Fill(data);
                da = null;
                return data;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al consultar: " + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        //DAR DE BAJA
        public void BD_darBaja_Producto(string idprod)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Darbaja_Producto", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idprod);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seedito = true;


            }
            catch (Exception ex)
            {
                seedito = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar: " + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //ELIMINAR
        public void BD_Eliminar_Producto(string idprod)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Eliminar_Producto", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idprod);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seedito = true;


            }
            catch (Exception ex)
            {
                seedito = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar: " + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //CONTROL DE STOCK
        //suma
        public void BD_Sumar_Stock_Producto(string idprod, double stock)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_SumarStock", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idprod);
                cmd.Parameters.AddWithValue("@stock", stock);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seedito = true;


            }
            catch (Exception ex)
            {
                seedito = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar: " + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //resta
        public void BD_Restar_Stock_Producto(string idprod, double stock)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Restar_Stock", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idprod);
                cmd.Parameters.AddWithValue("@stock", stock);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seedito = true;


            }
            catch (Exception ex)
            {
                seedito = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar: " + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //ACTUALIZAR PRECIOS DE COMPRA Y VENTA
        public void BD_Actualizar_PrecioCompra_Producto(string idprod, double precompraPesos, double preVenta_mnor, double utilidad, double valoralmacen)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Actulizar_Precios_CompraVenta_Producto", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Pro", idprod);
                cmd.Parameters.AddWithValue("@Pre_CompraS", precompraPesos);
                cmd.Parameters.AddWithValue("@Pre_vntaxMenor", preVenta_mnor);
                cmd.Parameters.AddWithValue("@Utilidad", utilidad);
                cmd.Parameters.AddWithValue("@ValorAlmacen", valoralmacen);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                seedito = true;


            }
            catch (Exception ex)
            {
                seedito = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar: " + ex.Message, "Capa Datos Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
