using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Envio
    {
        public string Nro { get; set; }
        public Persona Destinatario { get; set; }
        public Persona Repartidor { get; set; }
        public EstadoEnvio Estado { get; set; }
        public DateTime FechadeAlta { get; private set; }
        public DateTime FechaEstimadaEntrega { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public Envio(string nro, Persona destinatario, EstadoEnvio estado, DateTime fechaEstimadaEntrega, string descripcion)
        {
            Nro = nro;
            Destinatario = destinatario;
            Estado = estado;
            FechaEstimadaEntrega = fechaEstimadaEntrega;
            Descripcion = descripcion;
            FechadeAlta = DateTime.Now;
        }
    }
}
