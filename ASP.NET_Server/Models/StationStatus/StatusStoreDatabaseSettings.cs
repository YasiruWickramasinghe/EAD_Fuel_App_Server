//Sri Lanka Institute of Information Technology
//   Year  :  4th Year 2nd Semester
//   Module Code  :  SE4040
//   Module  :  Enterprise Application Development
//   Group ID  :  25
//   Student Id Number  :  IT19051376
//   Name  :  Anjana W.W.M

namespace ASP.NET_Server.Models.StationStatus
{
    public class StatusStoreDatabaseSettings : IStatusStoreDatabaseSettings
    {
        public string StatusCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
