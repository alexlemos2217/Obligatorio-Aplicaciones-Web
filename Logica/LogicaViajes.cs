using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaViajes
    {
        // ================== AGREGAR VIAJE ================== //
        public static int Agregar(Viaje pViaje)
        {
            return PersistenciaViaje.Agregar(pViaje);
        }

        // ================== LISTAR VIAJES ================== //
        public static List<Viaje> ListarViajesPorTerminalMesAnio(string codigoTerminal, int mes, int anio)
        {
            try
            {
                return PersistenciaViaje.ListarViajes(codigoTerminal, mes, anio);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en lógica de viajes: " + ex.Message);
            }
        }
    }
}
