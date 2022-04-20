using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
public enum EstadoEnvio
    {
        PENDIENTE = 1, ASIGNADO_REPARTIDOR = 2, EN_CAMINO = 3, ENTREGADO = 4, ERROR = 0
    }
}
