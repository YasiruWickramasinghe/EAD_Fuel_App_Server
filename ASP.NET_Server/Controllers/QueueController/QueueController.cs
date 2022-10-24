using ASP.NET_Server.Models.QueueModel;
using ASP.NET_Server.Services.QueueService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NET_Server.Controllers.QueueController
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly IQueueServices queueService;

        public QueueController(IQueueServices queueService)
        {
            this.queueService = queueService;
        }
        // GET: api/<QueueController>
        [HttpGet]
        public ActionResult<List<Queue>> Get()
        {
            return queueService.Get();
        }

        // GET api/<QueueController>/5
        [HttpGet("{id}")]
        public ActionResult<Queue> Get(string id)
        {
            var queue = queueService.Get(id);

            if (queue == null) return NotFound($"Queue with Id = {id} not Found");

            return queue;
        }

        // GET api/<QueueController>/5
        [HttpGet("station/{id}")]
        public ActionResult<List<Queue>> GetByStation(string id)
        {
            return queueService.GetByStation(id);
        }

        // POST api/<QueueController>
        [HttpPost]
        public ActionResult<Queue> Post([FromBody] Queue queue)
        {
            queueService.Create(queue);

            return CreatedAtAction(nameof(Get), new { id = queue.Id }, queue);
        }

        // PUT api/<QueueController>/5
        [HttpPut("{id}")]
        public ActionResult<Queue> Put(string id, [FromBody] Queue queue)
        {
            var existingQueue = queueService.Get(id);

            if (existingQueue == null) return NotFound($"Queue with Id = {id} not found");

            queueService.Update(id, queue);

            return NoContent();
        }

        // DELETE api/<QueueController>/5
        [HttpDelete("{id}")]
        public ActionResult<Queue> Delete(string id)
        {
            var existingQueue = queueService.Get(id);

            if (existingQueue == null) return NotFound($"Queue with Id = {id} not found");

            queueService.Remove(existingQueue.Id);

            return Ok($"Queue with ID = {id} deleted");
        }
    }
}
