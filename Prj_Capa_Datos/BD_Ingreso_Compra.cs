using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Prj_Capa_Entidad;

namespace Prj_Capa_Datos
{
    public class BD_Ingreso_Compra : BDConexion
    {
        public static bool seguardo = false;
        public static bool detseguardo = false;

        //insertar
        public void BD_Ingresar_Registrocompra(EN_IngresoCompra com)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Compra", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCom", com.Idcompra);
                cmd.Parameters.AddWithValue("@Nro_Fac_Fisico", com.Nro_Fac_Fisico);
                cmd.Parameters.AddWithValue("@IdProvee", com.Idproveedor);
                cmd.Parameters.AddWithValue("@SubTotal_Com", com.Subtotal);
                cmd.Parameters.AddWithValue("@FechaIngre", com.FechaIngreso);
                cmd.Parameters.AddWithValue("@TotalCompra", com.Totalcompra);
                cmd.Parameters.AddWithValue("@IdUsu", com.Idusu);
                cmd.Parameters.AddWithValue("@ModalidadPago", com.Modali_Pago);
                cmd.Parameters.AddWithValue("@TiempoEspera", com.TiempoEspera);
                cmd.Parameters.AddWithValue("@FechaVence", com.FechaVence);
                cmd.Parameters.AddWithValue("@EstadoIngre", com.EstadoIngreso);
                cmd.Parameters.AddWithValue("@RecibiConforme", com.RecibiConforme);
                cmd.Parameters.AddWithValue("@Datos_Adicional", com.Datos_Adicional);
                cmd.Parameters.AddWithValue("@Tipo_Doc_Compra", com.TipoDoc_Compra);

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
                MessageBox.Show("Error al guardar: " + ex.Message, "Insertar cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Guardar detalle
        public void BD_Ingresar_Detalle_Registrocompra(EN_Det_IngresoCompra det)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Insert_Detalle_ingreso", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_ingreso", det.Idingreso);
                cmd.Parameters.AddWithValue("@Id_Pro", det.Idproducto);
                cmd.Parameters.AddWithValue("@Precio", det.Precio);
                cmd.Parameters.AddWithValue("@Cantidad", det.Cantidad);
                cmd.Parameters.AddWithValue("@Importe", det.Importe);
                

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
                MessageBox.Show("Error al guardar: " + ex.Message, "Insertar cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //validar
        public bool BD_Verificar_NroDoc_Fisico(string idfisico)
        {
            bool respuesta = false;
            Int32 getvalue = 0;
            SqlConnection cn = new SqlConnection();

            try
            {

                SqlCommand cmd = new SqlCommand();

                cn.ConnectionString = Conectar();
                cmd.CommandText = "sp_validar_NroFisico_Compra";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                //parametros
                cmd.Parameters.AddWithValue("@Nro_Doc_fisico", idfisico);

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
                MessageBox.Show("Error al guardar: " + ex.Message, "Capa Datos PROVEEDOR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                respuesta = false;
            }
            return respuesta;
        }

        //********************consultas*******************
        //para buscar por valor
        public DataTable BD_Buscar_Compras_Explorador(string valor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_Gnral_deCompras", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xvalor", valor);
               

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

        //todos
        //para buscar por valor
        public DataTable BD_cargar_Todas_Compras()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Leer_Todas_Facturas_Compras", cn);
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
                MessageBox.Show("Error al guardar: " + ex.Message, "Cargar cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return null;
        }

        //por mes
        public DataTable BD_Buscar_Compras_Explorador_Pormes_Dia(string tipo, DateTime fechames)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Facturas_Ingresadas_alDia", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@tipo", tipo);
                da.SelectCommand.Parameters.AddWithValue("@fecha", fechames);


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
        //borrar
        public void BD_borrar_Compra(string idcompra)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("SP_Borrar_Factura_Ingresada", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Fac", idcompra);
             
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
                MessageBox.Show("Error al guardar: " + ex.Message, "Insertar cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
