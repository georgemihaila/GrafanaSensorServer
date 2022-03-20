using GrafanaSensorServer.Infra.Database;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrafanaSensorServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorController : ControllerBase
    {
        private readonly GrafanaSensorsContext _context;

        public SensorController(GrafanaSensorsContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("SetState")]
        public IActionResult SetState(string sensor, string state)
        {
            if (!_context.Sensors.Any(x => x.Name == sensor))
            {
                _context.Sensors.Add(new Sensor()
                {
                    Name = sensor,
                    State = state
                });
            }
            else
            {
                var x = _context.Sensors.First(x => x.Name == sensor);
                x.State = state;
                _context.Update(x);
            }
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route("AddReading")]
        public IActionResult AddReading(string sensor, float value)
        {
            if (!_context.Sensors.Any(x => x.Name == sensor))
            {
                _context.Sensors.Add(new Sensor()
                {
                    Name = sensor
                });
            }
            _context.SaveChanges();
            var targetSensor = _context.Sensors.First(x => x.Name == sensor);
            _context.Values.Add(new Value()
            {
                ReadingTime = DateTime.Now,
                Sensor = targetSensor.Name,
                Value1 = value
            });
            _context.SaveChanges();
            return Ok();
        }
    }
}
