using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaCompanias
    {
        // ================== AGREGAR COMPAÑÍA ================== //
        public static void Agregar(Compania cCompania)
        {
            PersistenciaCompania.Agregar(cCompania);
        }

        // ================== MODIFICAR COMPAÑÍA ================== //
        public static void Modificar(Compania cCompania)
        {
            PersistenciaCompania.Modificar(cCompania);
        }

        // ================== ELIMINAR COMPAÑÍA ================== //
        public static void Eliminar(Compania cCompania)
        {
            PersistenciaCompania.Eliminar(cCompania);
        }

        // ================== BUSCAR COMPAÑÍA ================== //
        public static Compania Buscar(string cCompania)
        {
            Compania oCompania = PersistenciaCompania.Buscar(cCompania);

            return oCompania;
        }

        // ================== LISTAR COMPAÑÍAS ================== //
        public static List<Compania> ListarCompanias() 
        {
            return PersistenciaCompania.ListarCompanias();
        }
    }
}
