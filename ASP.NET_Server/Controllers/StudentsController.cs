using ASP.NET_Server.Models;
using ASP.NET_Server.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NET_Server.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentServvices studentServvices;

        public StudentsController(IStudentServvices studentServvices)
        {
            this.studentServvices = studentServvices;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            return studentServvices.Get();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(string id)
        {
           var student = studentServvices.Get(id);

            if (student == null) return NotFound($"Student with Id = {id} not Found");

            return student;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student student)
        {
            studentServvices.Create(student);

            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult<Student> Put(string id, [FromBody] Student student)
        {
            var existingStudent = studentServvices.Get(id);

            if (existingStudent == null) return NotFound($"Student with Id = {id} not found");

            studentServvices.Update(id, student);

            return NoContent();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Student> Delete(string id)
        {
            var existingStudent = studentServvices.Get(id);

            if (existingStudent == null) return NotFound($"Student with Id = {id} not found");

            studentServvices.Remove(existingStudent.Id);

            return Ok($"Student with ID = {id} deleted");
        }
    }
}
