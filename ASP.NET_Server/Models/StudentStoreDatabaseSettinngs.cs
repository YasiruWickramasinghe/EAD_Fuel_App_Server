namespace ASP.NET_Server.Models
{
    public class StudentStoreDatabaseSettinngs : IStudentStoreDatabaseSettings
    {
        public string StudentCcourseCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
