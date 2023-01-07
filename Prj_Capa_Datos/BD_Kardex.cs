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
    public class BD_Kardex : BDConexion
    {
        public static bool seguardo = false;
        public static bool detsaved = false;

        //REGISTRAR
        public void BD_Registrar_Kardex(string idkardex, string idproducto, string idprovee)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_crear_kardex", cn);
                cmd.CommandTimeout = 20;
               // cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idkardex", idkardex);
                cmd.Parameters.AddWithValue("@idprod", idproducto);
                cmd.Parameters.AddWithValue("@idprovee", idprovee);
               

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

        //Detalle de kardex
        public void BD_Registrar_Detalle_Kardex(EN_Kardex kr)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_registrar_detalle_kardex", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Krdx", kr.IdKardex); //18.41
                cmd.Parameters.AddWithValue("@Item", kr.Item);
                cmd.Parameters.AddWithValue("@Doc_Soport", kr.Doc_soporte);
                cmd.Parameters.AddWithValue("@Det_Operacion", kr.Det_Operacion);
                cmd.Parameters.AddWithValue("@Cantidad_In", kr.Cantidad_in);
                cmd.Parameters.AddWithValue("@Precio_Unt_In", kr.Precio_In);
                cmd.Parameters.AddWithValue("@Costo_Total_In", kr.Total_In);
                cmd.Parameters.AddWithValue("@Cantidad_Out", kr.Cantidad_Out);
                cmd.Parameters.AddWithValue("@Precio_Unt_Out", kr.Precio_out);
                cmd.Parameters.AddWithValue("@Importe_Total_Out", kr.Total_out);
                cmd.Parameters.AddWithValue("@Cantidad_Saldo", kr.Cantidad_saldo);
                cmd.Parameters.AddWithValue("@Promedio", kr.Promedio);
                cmd.Parameters.AddWithValue("@Costo_Total_Saldo", kr.Total_saldo);
          

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                detsaved = true;


            }
            catch (Exception ex)
            {
                detsaved = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar: " + ex.Message, "Capa Datos PROVEEDOR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //validar
        public bool BD_Verificar_Producto_siTienKardex(string idprod)
        {
            bool respuesta = false;
            Int32 getvalue = 0;
            SqlConnection cn = new SqlConnection();

            try
            {
               
                SqlCommand cmd = new SqlCommand();

                cn.ConnectionString = Conectar();
                cmd.CommandText = "Sp_Ver_sihay_Kardex";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                //parametros
                cmd.Parameters.AddWithValue("@Id_Prod", idprod);

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
                detsaved = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar: " + ex.Message, "Capa Datos PROVEEDOR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                respuesta = false;
            }
            return respuesta;

            
        }

        public DataTable BD_Buscar_KardexDetalle_porProducto(string idprod)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_DeKardex_Principal_yDetalle", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xvalor", idprod);

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

    }

   
}
