//Sri Lanka Institute of Information Technology
//   Year  :  4th Year 2nd Semester
//   Module Code  :  SE4040
//   Module  :  Enterprise Application Development
//   Group ID  :  25
//   Student Id Number  :  IT19051376
//   Name  :  Anjana W.W.M

using ASP.NET_Server.Models.StationModel;
using ASP.NET_Server.Models.StationStatus;

namespace ASP.NET_Server.Services.StationStatus
{
    public interface IStatusService
    {
        List<Status> Get();
        List<Status> GetByStation(string id);
        Status Get(string id);
        Status GetByDate(string date);
        Status GetByType(string fuelType);
        Status Create(Status station);
        void Update(string id, Status station);
        void Remove(string id);
}
}
