using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EntidadesCompartidas
{
    public class Compania
    {
        // Atributos de instancia
        private string nombre;
        private string direccion;
        private string telefono;

        // Propiedades
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value.Trim() == "")
                {
                    throw new Exception("El nombre no puede estar vacío");
                }
                else if (value.Trim().Length > 30)
                {
                    throw new Exception("El nombre no puede superar los 30 caracteres");
                }

                nombre = value;
            }
        }

        public string Direccion
        {
            get { return direccion; }
            set
            {
                if (value.Trim() == "")
                {
                    throw new Exception("La dirección no puede estar vacía");
                }
                else if (value.Trim().Length > 40)
                {
                    throw new Exception("La dirección no puede superar los 40 caracteres");
                }

                direccion = value;
            }
        }

        public string Telefono
        {
            get { return telefono; }
            set
            {
                if (value == null || value.Trim() == "")
                {
                    throw new Exception("El teléfono no puede estar vacío");
                }

                string telefonoFormateado = value.TrimStart('0');

                if (!Regex.IsMatch(telefonoFormateado, @"^\d{7,8}$"))
                {
                    throw new Exception("El teléfono debe tener 8 o 9 números");
                }

                telefono = telefonoFormateado;
            }
        }


        // Constructor
        public Compania(string cNombre, string cDireccion, string cTelefono)
        {
            Nombre = cNombre;
            Direccion = cDireccion;
            Telefono = cTelefono;
        }
        public override string ToString()
        {
            return ("Nombre: " + Nombre + "\nDrección: " + Direccion + "\nTeléfono: " + Telefono);
        }
    }
}
