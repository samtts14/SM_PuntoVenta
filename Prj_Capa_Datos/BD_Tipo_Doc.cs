using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Prj_Capa_Datos
{
    public class BD_Tipo_Doc : BDConexion
    {
        public static string BD_NroID(int idtipo)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Listado_Tipo", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Tipo", idtipo);

                string NroDoc;
                cn.Open();
                NroDoc = Convert.ToString(cmd.ExecuteScalar());
                cn.Close();

                return NroDoc;
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Advertencia de seguridad.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (cn.State == ConnectionState.Open) cn.Close();
                cn.Dispose();
                cn = null;
                return null;

            }
        }    

        public static void BD_Actualizar_SiguienteNro_Correlativo(int idtipo)
        {
            SqlConnection cn = new SqlConnection();
         

            try
            {
                cn.ConnectionString = Conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Actualiza_Tipo_Doc", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Tipo", idtipo);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open) cn.Close();
                
                MessageBox.Show("Algo salió mal: " + ex.Message, "Advertensia de seguridad.", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        //actualizar
        public static void BD_Actualizar_SiguienteNro_CorrelativoProducto(int idtipo)
        {
            SqlConnection cn = new SqlConnection();


            try
            {
                cn.ConnectionString = Conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Actualiza_Tipo_Prodcto", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Tipo", idtipo);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open) cn.Close();

                MessageBox.Show("Algo salió mal: " + ex.Message, "Advertensia de seguridad.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Editar tipo de cambio
        public static void BD_Actualizar_TipoCambio(int idtipo, double TipoCambio)
        {
            SqlConnection cn = new SqlConnection();


            try
            {
                cn.ConnectionString = Conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Editar_Tipo_Cambio", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idtipo", idtipo);
                cmd.Parameters.AddWithValue("@numero", TipoCambio);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open) cn.Close();

                MessageBox.Show("Algo salió mal: " + ex.Message, "Advertensia de seguridad.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //LEER TIPO DE CMBIO DEL DOLAR
        public static double BD_Leer_TipoCambio(int idtipo)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Listar_TipoCambio", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Tipo", idtipo);

                double TipoCambio;
                cn.Open();
                TipoCambio = Convert.ToDouble(cmd.ExecuteScalar());
                cn.Close();

                return TipoCambio;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "Advertencia de seguridad.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (cn.State == ConnectionState.Open) cn.Close();
                cn.Dispose();
                cn = null;
                return 0;

            }
        }

    }
}
