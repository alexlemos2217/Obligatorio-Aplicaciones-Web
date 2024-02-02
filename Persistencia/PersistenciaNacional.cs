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
    public class PersistenciaNacional
    {
        // ================== AGREGAR TERMINAL NACIONAL ================== //
        public static void Agregar(Nacional tNacional)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AgregarTerminalNacional", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@Codigo", tNacional.Codigo);
            oComando.Parameters.AddWithValue("@NombreCiudad", tNacional.Ciudad);
            oComando.Parameters.AddWithValue("@Taxi", tNacional.Taxi);

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
            catch (FormatException)
            {
                throw new Exception();
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

        // ================== MODIFICAR TERMINAL NACIONAL ================== //
        public static void Modificar(Nacional tNacional)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarTerminalNacional", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@Codigo", tNacional.Codigo);
            oComando.Parameters.AddWithValue("@NombreCiudad", tNacional.Ciudad);
            oComando.Parameters.AddWithValue("@Taxi", tNacional.Taxi);

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

        // ================== ELIMINAR TERMINAL NACIONAL ================== //
        public static void Eliminar(Nacional tNacional)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("EliminarTerminal", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            // Otra forma de crear parámetro de entrada - no tiene que ser así
            SqlParameter oCodigo = new SqlParameter("@Codigo", tNacional.Codigo);
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
                    throw new Exception("No se encontraron registros en Terminales Nacionales para eliminar");

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

        // ================== BUSCAR TERMINAL NACIONAL ================== //
        public static Nacional Buscar(string tNacional)
        {
            if (!Regex.IsMatch(tNacional, "^[a-zA-Z]{6}$"))
            {
                throw new Exception("El código debe tener exactamente 6 letras.");
            }

            string ciudad;
            bool taxi;

            Nacional oNacional = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarTerminalNacional", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@Codigo", tNacional);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        ciudad = (string)oReader["ciudad"];
                        taxi = Convert.ToBoolean(oReader["taxis"]);

                        oNacional = new Nacional (tNacional, ciudad, taxi);
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
            return oNacional;
        }

        // ================== LISTADO DE TERMINALES NACIONALES ================== //
        public static List<Nacional> ListarTerminalesNacionales()
        {
            string codigo, ciudad;
            bool taxi;

            List<Nacional> colTerminales = new List<Nacional>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListarTerminalesNacionales", oConexion);
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
                        taxi = Convert.ToBoolean(oReader["taxis"]);

                        Nacional oNacional = new Nacional(codigo, ciudad, taxi);
                        colTerminales.Add(oNacional);
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
