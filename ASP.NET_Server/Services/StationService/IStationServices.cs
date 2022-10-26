
//Sri Lanka Institute of Information Technology
//   Year  :  4th Year 2nd Semester
//   Module Code  :  SE4040
//   Module  :  Enterprise Application Development
//   Group ID  :  25
//   Student Id Number  :  IT19051376
//   Name  :  Anjana W.W.M

using ASP.NET_Server.Models.StationModel;

namespace ASP.NET_Server.Services.StationService
{
    public interface IStationServices
    {
        List<Station> Get();
        Station Get(string id);
        Station Create(Station station);
        void Update(string id, Station station);
        void Remove(string id);
    }
}
