using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sensores_API.Models;
using Sensores_API.Services;

namespace Sensores_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly SensorServices _SensorService;

        public SensorController(SensorServices SensorService)
        {
            _SensorService = SensorService;
        }

        [HttpGet]
        public ActionResult<List<Sensor>> Get() =>
            _SensorService.Get();

        [HttpGet("{id}")]
        public ActionResult<Sensor> Get(ObjectId id)
        {
            var Sensor = _SensorService.Get(id);

            if (Sensor == null)
            {
                return NotFound();
            }

            return Sensor;
        }

        [HttpPost]
        public ActionResult<Sensor> Post(Sensor Sensor)
        {
            _SensorService.Create(Sensor);

            return CreatedAtRoute("GetSensor", new { id = Sensor.id.ToString() }, Sensor);
        }

        [HttpPut("{id}")]
        public IActionResult Update(ObjectId id, Sensor SensorIn)
        {
            var Sensor = _SensorService.Get(id);

            if (Sensor == null)
            {
                return NotFound();
            }

            _SensorService.Update(id, SensorIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(ObjectId id)
        {
            var Sensor = _SensorService.Get(id);

            if (Sensor == null)
            {
                return NotFound();
            }

            _SensorService.Remove(Sensor.id);

            return NoContent();
        }
    }
}
