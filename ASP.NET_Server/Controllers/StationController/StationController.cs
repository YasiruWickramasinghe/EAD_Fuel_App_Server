using ASP.NET_Server.Models.StationModel;
using ASP.NET_Server.Services.StationService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NET_Server.Controllers.StationController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IStationServices stationService;

        public StationController(IStationServices stationService)
        {
            this.stationService = stationService;
        }
        // GET: api/<StationController>
        [HttpGet]
        public ActionResult<List<Station>> Get()
        {
            return stationService.Get();
        }

        // GET api/<StationController>/5
        [HttpGet("{id}")]
        public ActionResult<Station> Get(string id)
        {
            var station = stationService.Get(id);

            if (station == null) return NotFound($"Station with Id = {id} not Found");

            return station;
        }

        // POST api/<StationController>
        [HttpPost]
        public ActionResult<Station> Post([FromBody] Station station)
        {
            stationService.Create(station);

            return CreatedAtAction(nameof(Get), new { id = station.Id }, station);
        }

        // PUT api/<StationController>/5
        [HttpPut("{id}")]
        public ActionResult<Station> Put(string id, [FromBody] Station station)
        {
            var existingStation = stationService.Get(id);

            if (existingStation == null) return NotFound($"Station with Id = {id} not found");

            stationService.Update(id, station);

            return NoContent();
        }

        // DELETE api/<StationController>/5
        [HttpDelete("{id}")]
        public ActionResult<Station> Delete(string id)
        {
            var existingStation = stationService.Get(id);

            if (existingStation == null) return NotFound($"Station with Id = {id} not found");

            stationService.Remove(existingStation.Id);

            return Ok($"Station with ID = {id} deleted");
        }
    }
}
