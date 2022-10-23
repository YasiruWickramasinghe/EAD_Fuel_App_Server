namespace ASP.NET_Server.Models
{
    public interface IStudentStoreDatabaseSettings
    {
        string StudentCcourseCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
