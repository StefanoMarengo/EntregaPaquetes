using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Persona
    {
        public int DNI { get; set; }
        public string NombreApellido { get; set; }
        public int CodigoPostal { get; set; }
        public int Latitud { get; set; }
        public int Longitud { get; set; }
        public Nullable<int> Telefono { get; set; }
    }
}
