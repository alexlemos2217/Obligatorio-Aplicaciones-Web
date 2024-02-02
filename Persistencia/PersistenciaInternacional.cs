using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;


namespace Persistencia
{
    public class PersistenciaInternacional
    {
        // ================== AGREGAR TERMINAL INTERNACIONAL ================== //
        public static void Agregar(Internacional tInternacional)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AgregarTerminalInternacional", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@Codigo", tInternacional.Codigo);
            oComando.Parameters.AddWithValue("@NombreCiudad", tInternacional.Ciudad);
            oComando.Parameters.AddWithValue("@Pais", tInternacional.Pais);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = (int)oRetorno.Value;

                if (resultado == -1)
                    throw new Exception("Ya existe una terminal con ese código");

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

        // ================== MODIFICAR TERMINAL INTERNACIONAL ================== //
        public static void Modificar(Internacional tInternacional)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarTerminalInternacional", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@Codigo", tInternacional.Codigo);
            oComando.Parameters.AddWithValue("@NombreCiudad", tInternacional.Ciudad);
            oComando.Parameters.AddWithValue("@Pais", tInternacional.Pais);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = (int)oRetorno.Value;

                if (resultado == -1)
                    throw new Exception("No existe la terminal, no se modifica");

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

        // ================== ELIMINAR TERMINAL INTERNACIONAL ================== //
        public static void Eliminar(Internacional tInternacional)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("EliminarTerminal", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            // Otra forma de crear parámetro de entrada - no tiene que ser así
            SqlParameter oCodigo = new SqlParameter("@Codigo", tInternacional.Codigo);
            oCodigo.Direction = ParameterDirection.Input;

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oCodigo);
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = (int)oRetorno.Value;

                if (resultado == -1)
                    throw new Exception("No existe una terminal con ese código");

                else if (resultado == -2)
                    throw new Exception("Hay viajes asociados - No se elimina");

                else if (resultado == -3)
                    throw new Exception("No se encontraron registros en Terminales Internacionales para eliminar");

                else if (resultado == -4)
                    throw new Exception("No se encontró la terminal para eliminar");

                else if (resultado == -5)
                    throw new Exception("Hay viajes asociados - No se puede eliminar");

                else if (resultado == -6)
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

        // ================== BUSCAR TERMINAL INTERNACIONAL ================== //
        public static Internacional Buscar(string tInternacional)
        {
            if (!Regex.IsMatch(tInternacional, "^[a-zA-Z]{6}$"))
            {
                throw new Exception("El código debe tener exactamente 6 letras.");
            }

            string ciudad, pais;

            Internacional oInternacional = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarTerminalInternacional", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@Codigo", tInternacional);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        ciudad = (string)oReader["Ciudad"];
                        pais = (string)oReader["Pais"];

                        oInternacional = new Internacional(tInternacional, ciudad, pais);
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
            return oInternacional;

        }

        // ================== LISTADO DE TERMINALES INTERNACIONALES ================== //
        public static List<Internacional> ListarTerminalesInternacionales()
        {
            string codigo, ciudad, pais;

            List<Internacional> colTerminales = new List<Internacional>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarTerminalesInternacionales", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        codigo = oReader["codigo"].ToString();
                        ciudad = oReader["ciudad"].ToString();
                        pais = oReader["pais"].ToString();

                        Internacional oInternacional = new Internacional(codigo, ciudad, pais);
                        colTerminales.Add(oInternacional);
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
            return colTerminales;
        }
    }
}
