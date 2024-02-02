using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;
//using Logica;

namespace Persistencia
{
    public class PersistenciaViaje
    {
        // ================== AGREGAR VIAJE ================== //
        public static int Agregar(Viaje pViaje)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AgregarViaje", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@fecHoraSalida", pViaje.FechaHoraSalida);
            oComando.Parameters.AddWithValue("@fecHoraLlegada", pViaje.FechaHoraLlegada);
            oComando.Parameters.AddWithValue("@cantPasajeros", pViaje.MaxPasajeros);
            oComando.Parameters.AddWithValue("@precioBoleto", pViaje.PrecioBoleto);
            oComando.Parameters.AddWithValue("@anden", pViaje.Anden);
            oComando.Parameters.AddWithValue("@codigoViaje", pViaje.ViajeTerm.Codigo.ToUpper());
            oComando.Parameters.AddWithValue("@nombre", pViaje.ViajeComp.Nombre);

            
            SqlParameter oRetorno = new SqlParameter("@nroInterno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.Output;
            oComando.Parameters.Add(oRetorno);

            int resultado = 0;

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                resultado = (int)oRetorno.Value;

                if (resultado > 0)
                {
                    pViaje.CodigoViaje = resultado;
                }

                else if (resultado == -1)
                    throw new Exception("La terminal no existe");
                else if (resultado == -2)
                    throw new Exception("La compañía no existe");
                else if (resultado == -3)
                    throw new Exception("La cantidad de pasajeros debe estar entre 1 y 50");
                else if (resultado == -4)
                    throw new Exception("El precio del boleto debe ser mayor a cero");
                else if (resultado == -5)
                    throw new Exception("El anden debe estar entre 1 y 35");
                else if (resultado == -6)
                    throw new Exception("La fecha y hora de salida debe ser menor a la de llegada");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return resultado;
        }

        // ================== LISTADO DE VIAJES ================== //
        public static List<Viaje> ListarViajes(string codTerminal, int mes, int anio)
        {
            List<Viaje> colViajes = new List<Viaje>();

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListadoViajes", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {

                oComando.Parameters.AddWithValue("@mes", mes);
                oComando.Parameters.AddWithValue("@anio", anio);
                oComando.Parameters.AddWithValue("@codigoTerminal", codTerminal);


                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        int nroInterno = Convert.ToInt32(oReader["nroInterno"]);
                        DateTime fechaSalida = Convert.ToDateTime(oReader["fecHorSalida"]);
                        DateTime fechaLlegada = Convert.ToDateTime(oReader["fecHorLlegada"]);
                        int cantPasajeros = Convert.ToInt32(oReader["cantPasajeros"]);
                        double precioBoleto = Convert.ToDouble(oReader["precioBoleto"]);
                        int anden = Convert.ToInt32(oReader["anden"]);
                        string codigoTerminal = oReader["codigoViaje"].ToString();
                        string ciudadTerminal = oReader["ciudad"].ToString();
                        string nombreCompania = oReader["nombre"].ToString();
                        string direccionCompania = oReader["direccion"].ToString();
                        string telefonoCompania = oReader["telefono"].ToString();

                        Terminal terminal = new Terminal(codigoTerminal, ciudadTerminal);
                        Compania compania = new Compania(nombreCompania, direccionCompania, telefonoCompania);
                        compania.Nombre = nombreCompania;

                        Viaje oViaje = new Viaje(nroInterno, fechaSalida, fechaLlegada, cantPasajeros, precioBoleto, anden, terminal, compania);
                        colViajes.Add(oViaje);
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
            return colViajes;
        }

    }
}
