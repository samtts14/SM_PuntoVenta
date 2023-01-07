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
    public class BD_Marcas : BDConexion
    {
        public void BD_Registrar_Marca(string nomMarca)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_addMarca", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@marca", nomMarca);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("La Marca se ha registrado con exito.");
            }
            catch(Exception ex)
            {
                if(cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar.: " + ex.Message, "Capa Datos Categoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //EDITAR

        public void BD_Editar_Marca(int idmar, string nomMarca)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_Editar_Marca", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idmar", idmar);
                cmd.Parameters.AddWithValue("@nom_marca", nomMarca);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("La Marca se ha editado con exito.", "Registro de Marca.",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar.: " + ex.Message, "Capa Datos Categoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //CONSULTAR MARCAS

        public DataTable BD_Mostrar_Todas_Marcas()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Todos_Marcas", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable data = new DataTable();

                da.Fill(data);
                da = null;
                return data;
            }
            catch(Exception ex)
            {
                if(cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al consultar: " + ex.Message, "Capa Datos Categoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        //ELIMINAR

        public void BD_Eliminar_Marca(int idmar)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("sp_eliminar_Marca", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idmar", idmar);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("La Marca se ha eliminado con exito.", "Registro de Marca.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar: " + ex.Message, "Capa Datos Categoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
