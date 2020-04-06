using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensores_API.Models;

namespace Sensores_API.Services
{
    interface ISensorServices
    {
        Sensor AdicionarSensor(Sensor item);
        IList<Sensor> ObterTodos();
        Sensor ObterPorId(int id);
    }
}
