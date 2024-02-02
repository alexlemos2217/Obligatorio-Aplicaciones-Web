using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Internacional : Terminal
    {
        // Atributos
        private string pais;

        // Propiedades
        public string Pais
        {
            get { return pais; }
            set
            {
                if (value == "")
                {
                    throw new Exception("El nombre de la ciudad no puede estar vacío");
                }
                if (value.Trim().Length > 30)
                {
                    throw new Exception("El nombre de la ciudad no puede superar los 30 caracteres");
                }

                pais = value;
            }
        }

        // Constructor
        public Internacional(string tCodigo, string tCiudad, string tiPais)
            : base(tCodigo, tCiudad)
        {
            Pais = tiPais;
        }

        // Operaciones
        public override string ToString()
        {
            return base.ToString() + "\nPais: " + Pais;
        }
    }
}
