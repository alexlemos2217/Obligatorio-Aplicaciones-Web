using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaCompania
    {
        // ================== AGREGAR COMPAÑÍA ================== //
        public static void Agregar(Compania cCompania)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AgregarCompania", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@Nombre", cCompania.Nombre);
            oComando.Parameters.AddWithValue("@Direccion", cCompania.Direccion);
            oComando.Parameters.AddWithValue("@Telefono", cCompania.Telefono);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = (int)oRetorno.Value;

                if (resultado == -1)
                    throw new Exception("La compañía ya existe en el sistema");
                else if (resultado == -2)
                    throw new Exception("Ocurrió un error inesperado");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        // ================== MODIFICAR COMPAÑÍA ================== //
        public static void Modificar(Compania cCompania)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarCompania", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@Nombre", cCompania.Nombre);
            oComando.Parameters.AddWithValue("@Direccion", cCompania.Direccion);
            oComando.Parameters.AddWithValue("@Telefono", cCompania.Telefono);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = (int)oRetorno.Value;

                if (resultado == -1)
                    throw new Exception("No existe una compañía con ese nombre, no se modifica");
                else if (resultado == -2)
                    throw new Exception("Ocurrió un error inesperado");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        // ================== ELIMINAR COMPAÑÍA ================== //
        public static void Eliminar(Compania cCompania)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("EliminarCompania", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oNombre = new SqlParameter("@Nombre", cCompania.Nombre);
            oNombre.Direction = ParameterDirection.Input;

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oNombre);
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = (int)oRetorno.Value;

                if (resultado == -1)
                    throw new Exception("No existe una publicación con ese nombre");

                else if (resultado == -2)
                    throw new Exception("Hay viajes asociados - No se elimina");
                else if (resultado == -3)
                    throw new Exception("Ocurrió un error inesperado");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        // ================== BUSCAR COMPAÑIA ================== //
        public static Compania Buscar(string cCompania)
        { 
            string direccion;
            string telefono;
            Compania oCompania = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarCompania", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@Nombre", cCompania);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        direccion = (string)oReader["Direccion"];
                        telefono = (string)oReader["Telefono"];

                        oCompania = new Compania(cCompania, direccion, telefono);
                    }
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return oCompania;
        }

        // ================== LISTADO DE COMPAÑÍAS ================== //
        public static List<Compania> ListarCompanias()
        {
            List<Compania> colCompanias = new List<Compania>();

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarCompanias", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;


            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        string nombre = oReader["Nombre"].ToString();
                        string direccion = oReader["Direccion"].ToString();
                        string telefono = oReader["telefono"].ToString();

                        Compania oCompania = new Compania(nombre, direccion, telefono);
                        colCompanias.Add(oCompania);
                    }
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return colCompanias;
        }
    }
}
