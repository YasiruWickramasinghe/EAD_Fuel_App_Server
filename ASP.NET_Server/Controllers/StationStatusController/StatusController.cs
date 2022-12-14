//Sri Lanka Institute of Information Technology
//   Year  :  4th Year 2nd Semester
//   Module Code  :  SE4040
//   Module  :  Enterprise Application Development
//   Group ID  :  25
//   Student Id Number  :  IT19051376
//   Name  :  Anjana W.W.M

using ASP.NET_Server.Models.StationModel;
using ASP.NET_Server.Models.StationStatus;
using ASP.NET_Server.Services.StationService;
using ASP.NET_Server.Services.StationStatus;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NET_Server.Controllers.StationStatusController
{
    [Route("api/station-status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService statusService;

        public StatusController(IStatusService statusService)
        {
            this.statusService = statusService;
        }

        // GET: api/<StatusController>
        [HttpGet]
        public ActionResult<List<Status>> Get()
        {
            return statusService.Get();
        }

        // GET: api/<StatusController>
        [HttpGet("station/{id}")]
        public ActionResult<List<Status>> GetByStation(string id)
        {
            return statusService.GetByStation(id);
        }


        // GET api/<StatusController>/5
        [HttpGet("{id}")]
        public ActionResult <Status> Get(string id)
        {
            return statusService.Get(id);
        }

        // POST api/<StatusController>
        [HttpPost]
        public ActionResult <Status> Post([FromBody] Status status)
        {
            var existingStatus1 = statusService.GetByDate(status.date);
            var existingStatus2 = statusService.GetByType(status.fuelType);

            if ((existingStatus1 != null) && (existingStatus2 != null)) return StatusCode(201, "Status for today is already Insertd");

            statusService.Create(status);
            CreatedAtAction(nameof(Get), new { id = status.Id }, status);
            return Ok("Successfully Added");

        }

        // PUT api/<StatusController>/5
        [HttpPut("{id}")]
        public ActionResult<Status> Put(string id, [FromBody] Status status)
        {
            var existingStatus = statusService.Get(id);

            if (existingStatus == null) return NotFound($"Status with Id = {id} not found");

            statusService.Update(id, status);

            return Ok($"Station with ID = {id} Updates");
        }

        // DELETE api/<StatusController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingStatus = statusService.Get(id);

            if (existingStatus == null) return NotFound($"Status with Id = {id} not found");

            statusService.Remove(existingStatus.Id);

            return Ok($"Station with ID = {id} deleted");
        }
    }
}
