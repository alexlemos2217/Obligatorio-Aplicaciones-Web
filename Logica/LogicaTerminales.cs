using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;


namespace Logica
{
    public class LogicaTerminales
    {
        // ================== AGREGAR TERMINALES ================== //
        public static void Agregar(Terminal pTerminal)
        {
            if (pTerminal is Nacional)
                PersistenciaNacional.Agregar((Nacional)pTerminal);
            else
                PersistenciaInternacional.Agregar((Internacional)pTerminal);
        }

        // ================== MODIFICAR TERMINALES ================== //
        public static void Modificar(Terminal pTerminal)
        {
            if (pTerminal is Nacional)
                PersistenciaNacional.Modificar((Nacional)pTerminal);
            else
                PersistenciaInternacional.Modificar((Internacional)pTerminal);
        }

        // ================== ELIMINAR TERMINALES ================== //
        public static void Eliminar(Terminal pTerminal)
        {
            if (pTerminal is Nacional)
                PersistenciaNacional.Eliminar((Nacional)pTerminal);
            else
                PersistenciaInternacional.Eliminar((Internacional)pTerminal);
        }

        // ================== BUSCAR TERMINALES ================== //
        public static Terminal Buscar(string pCodigo)
        {
            Terminal oTerminal = PersistenciaNacional.Buscar(pCodigo);

            if (oTerminal == null)
                oTerminal = PersistenciaInternacional.Buscar(pCodigo);

            return oTerminal;
        }

        // ================== LISTAR TERMINALES ================== //
        public static List<Terminal> ListarTerminales()
        {
            List<Terminal> colAuxiliar = new List<Terminal>();

            colAuxiliar.AddRange(PersistenciaNacional.ListarTerminalesNacionales());
            colAuxiliar.AddRange(PersistenciaInternacional.ListarTerminalesInternacionales());

            return colAuxiliar;
        }
    }
}
