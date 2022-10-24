using ASP.NET_Server.Models.VehicleModel;
using ASP.NET_Server.Services.VehicleService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NET_Server.Controllers.VehicleController
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleServices vehicleService;

        public VehicleController(IVehicleServices vehicleService)
        {
            this.vehicleService = vehicleService;
        }
        // GET: api/<VehicleController>
        [HttpGet]
        public ActionResult<List<Vehicle>> Get()
        {
            return vehicleService.Get();
        }

        // GET api/<VehicleController>/5
        [HttpGet("{id}")]
        public ActionResult<Vehicle> Get(string id)
        {
            var vehicle = vehicleService.Get(id);

            if (vehicle == null) return NotFound($"Vehicle with Id = {id} not Found");

            return vehicle;
        }

        // POST api/<VehicleController>
        [HttpPost]
        public ActionResult<Vehicle> Post([FromBody] Vehicle vehicle)
        {
            vehicleService.Create(vehicle);

            return CreatedAtAction(nameof(Get), new { id = vehicle.Id }, vehicle);
        }

        // PUT api/<VehicleController>/5
        [HttpPut("{id}")]
        public ActionResult<Vehicle> Put(string id, [FromBody] Vehicle vehicle)
        {
            var existingVehicle = vehicleService.Get(id);

            if (existingVehicle == null) return NotFound($"Vehicle with Id = {id} not found");

            vehicleService.Update(id, vehicle);

            return NoContent();
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{id}")]
        public ActionResult<Vehicle> Delete(string id)
        {
            var existingVehicle = vehicleService.Get(id);

            if (existingVehicle == null) return NotFound($"Vehicle with Id = {id} not found");

            vehicleService.Remove(existingVehicle.Id);

            return Ok($"Vehicle with ID = {id} deleted");
        }
    }
}
