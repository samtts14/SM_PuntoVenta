using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Prj_Capa_Entidad;

namespace Prj_Capa_Datos
{
    public class BD_Cliente :BDConexion
    {
        //validar
        public bool BD_Verificar_NroDni(string NroDni)
        {
            bool respuesta = false;
            Int32 getvalue = 0;
            SqlConnection cn = new SqlConnection();

            try
            {

                SqlCommand cmd = new SqlCommand();

                cn.ConnectionString = Conectar();
                cmd.CommandText = "sp_Validar_NroDNI";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                //parametros
                cmd.Parameters.AddWithValue("@dni", NroDni);

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
        public static bool saved = false;
        public static bool edited = false;
        //insertar
        public void BD_Insertar_Cliente(EN_Cliente cli)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Cliente", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcliente", cli.Idcliente);
                cmd.Parameters.AddWithValue("@razonsocial", cli.Razonsocial);
                cmd.Parameters.AddWithValue("@dni", cli.Cedula);
                cmd.Parameters.AddWithValue("@direccion", cli.Direccion);
                cmd.Parameters.AddWithValue("@telefono", cli.Telefono);
                cmd.Parameters.AddWithValue("@email", cli.Email);
                cmd.Parameters.AddWithValue("@idDis", cli.Ididis);
                cmd.Parameters.AddWithValue("@fechaAniver", cli.Fechaaniver);
                cmd.Parameters.AddWithValue("@contacto", cli.Contacto);
                cmd.Parameters.AddWithValue("@limiteCred", cli.LimiteCredito);               

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                saved = true;


            }
            catch (Exception ex)
            {
                saved = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar: " + ex.Message, "Insertar cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //editar
        public void BD_Editar_Cliente(EN_Cliente cli)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Modificar_Cliente", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcliente", cli.Idcliente);
                cmd.Parameters.AddWithValue("@razonsocial", cli.Razonsocial);
                cmd.Parameters.AddWithValue("@dni", cli.Cedula);
                cmd.Parameters.AddWithValue("@direccion", cli.Direccion);
                cmd.Parameters.AddWithValue("@telefono", cli.Telefono);
                cmd.Parameters.AddWithValue("@email", cli.Email);
                cmd.Parameters.AddWithValue("@idDis", cli.Ididis);
                cmd.Parameters.AddWithValue("@fechaAniver", cli.Fechaaniver);
                cmd.Parameters.AddWithValue("@contacto", cli.Contacto);
                cmd.Parameters.AddWithValue("@limiteCred", cli.LimiteCredito);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                edited = true;


            }
            catch (Exception ex)
            {
                edited = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar: " + ex.Message, "Editar cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Cargar Todos los Clientes
        public DataTable BD_CargarTodos_Clientes(string estado)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Todos_Clientes",cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@estado", estado);

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

        //para buscar por valor
        public DataTable BD_Buscar_Clientes(string valor, string estado)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_Cliente_porValor", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Valor", valor);
                da.SelectCommand.Parameters.AddWithValue("@estado", estado);

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

        //dar debaja a cliente
        public static bool baja = false;
        public void BD_dardeBaja_Cliente(string @idcliente)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_DarBajar_Cliente", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcliente", idcliente);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                edited = true;


            }
            catch (Exception ex)
            {
                baja = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar: " + ex.Message, "Editar cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //eliminar
        public void BD_Eliminar_Cliente(string @idcliente)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conectar();
                SqlCommand cmd = new SqlCommand("Sp_Eliminar_Cliente", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcliente", idcliente);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                edited = true;


            }
            catch (Exception ex)
            {
                baja = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar: " + ex.Message, "Editar cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
