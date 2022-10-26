//Sri Lanka Institute of Information Technology
//   Year  :  4th Year 2nd Semester
//   Module Code  :  SE4040
//   Module  :  Enterprise Application Development
//   Group ID  :  25
//   Student Id Number  :  IT19051376
//   Name  :  Anjana W.W.M

namespace ASP.NET_Server.Models.StationStatus
{
    public interface IStatusStoreDatabaseSettings
    {
        string StatusCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
