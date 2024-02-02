using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EntidadesCompartidas
{
    public class Terminal
    {
        // Atributos
        private string codigo;
        private string ciudad;

        // Propiedades
        public string Codigo
        {
            get { return codigo; }
            set
            {
                if (!Regex.IsMatch(value, "^[a-zA-Z]{6}$"))
                    throw new Exception("El código debe estar compuesto por seis letras");

                codigo = value;
            }
        }

        public string Ciudad
        {
            get { return ciudad; }
            set
            {
                if (value == "")
                {
                    throw new Exception("El nombre de la ciudad no puede estar vacío");
                }
                else if (value.Trim().Length > 30)
                {
                    throw new Exception("El nombre de la ciudad no puede superar los 30 caracteres");
                }

                ciudad = value;
            }

        }

        // Constructores
        public Terminal(string tCodigo, string tCiudad)
        {
            Codigo = tCodigo;
            Ciudad = tCiudad;
        }

        public override string ToString()
        {
            return ("Código: " + Codigo + "\nCiudad: " + Ciudad);
        }
    }
}
