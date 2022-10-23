using ASP.NET_Server.Models;

namespace ASP.NET_Server.Services
{
    public interface IStudentServvices
    {
        List<Student> Get();
        Student Get(string id);
        Student Create(Student student);
        void Update(string id, Student student);
        void Remove(string id);
    }
}
