using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace EnvioPaqueteria
{
    //Las listas deberían trabajarse directamente con JSON
    //Instalar newtonSoft y etc

    public class Main
    {
        List<Persona> Personas = new List<Persona>();
        List<Envio> Envios = new List<Envio>();
        public string AltaEnvio(int dniDestinatario, DateTime fechaEstimada, string descripcion)
        {
            if (ValidarPersona(dniDestinatario).Item1 != "")
                throw new Exception(ValidarPersona(dniDestinatario).Item1);
            Persona destinatario = ValidarPersona(dniDestinatario).Item2;
            if (destinatario.Telefono == null)
                return "Cargue su número de telefono";

            //Validar Destinatario
            //Hacer que JSON retorne 201 o 400
            //En caso de cualquier incumplimiento retornar error o un coigo 0000000
            Envio envioNuevo = new Envio(new Random().Next().ToString(),
                destinatario, EstadoEnvio.PENDIENTE, fechaEstimada, descripcion);
            Envios.Add(envioNuevo);
            return envioNuevo.Nro;
        }
        /*Se necesita un servicio que permita actualizar un envío, recibiendo el código
         * de seguimiento como parámetro. Se recibe como cuerpo de la solicitud el estado
         * actual. Se debe validar que el nuevo estado sea válido con la lógica 
         * correspondiente. En el caso que el estado sea “ENTREGADO” calcular y almacenar 
         * la comisión del repartidor y la fecha efectiva de entrega.*/
        public EstadoEnvio ObtenerEstadoEnvio(string numeroEnvio)
        {
            if (ValidarEnvio(numeroEnvio).Item1 != "")
                throw new Exception(ValidarEnvio(numeroEnvio).Item1);
            return ValidarEnvio(numeroEnvio).Item2.Estado;
        }
        public void ActualizarEnvio(string numeroEnvio)
        {
            if (ValidarEnvio(numeroEnvio).Item1 != "")
                throw new Exception(ValidarEnvio(numeroEnvio).Item1);

            Envio envioActualizar = ValidarEnvio(numeroEnvio).Item2;
            if (ObtenerEstadoEnvio(numeroEnvio) == EstadoEnvio.PENDIENTE && envioActualizar.Repartidor != null)
                envioActualizar.Estado = EstadoEnvio.ASIGNADO_REPARTIDOR;
            //SEGUIR

            //Buscar el radio de la Tierra

        }
        public (string, Envio) ValidarEnvio(string nroEnvio)
        {
            Envio envio = (Envio)Envios.Where(x => x.Nro == nroEnvio);
            if (envio == null)
                return ("El envío con ese número no existe", envio);
            return ("", envio);
        }
        public (string, Persona) ValidarPersona(int dniDestinatario)
        {
            Persona persona = (Persona)Personas.Where(x => x.DNI == dniDestinatario);
            if (persona == null)
                return ("El destinatario con ese número de documento no existe", persona);
            return ("", persona);
        }
        /*
         Se necesita un servicio que asigne un repartidor a un envío enviado 
        como parámetro utilizando la menor distancia entre ambos, es decir, 
        se debe asignar el repartidor que menor distancia tenga con el destinatario. 
        Retornar como respuesta todos los datos del repartidor asignado.*/
        public Repartidor AsignarRepartidor(string nroEnvio)
        {
            if (ValidarEnvio(nroEnvio).Item1 != "")
                throw new Exception(ValidarEnvio(nroEnvio).Item1);
            List<Repartidor> ListaRepartidores = GetRepartidores();
            List<Persona> ListaDestinatarios = GetDestinatarios();

            //Calculo de Distancia con lo que está en el Word

        }
        public List<Repartidor> GetRepartidores()
        {
            return (List<Repartidor>)Personas.Where(x => x is Repartidor);
        }
        public List<Persona> GetDestinatarios()
        {
            return Personas.Where(x => !(x is Repartidor)).ToList();
        }
        /*
         Se necesita un servicio que retorne una lista de repartidores indicando
        únicamente (nombre y apellido, total ganado por comisiones, cantidad de envíos 
        realizados), filtrando los envíos por fecha desde / hasta 
        (usar la fecha de creación del envio y no la de entrega final, usar solamente 
        los envíos entregados.)
         */

    }
}
