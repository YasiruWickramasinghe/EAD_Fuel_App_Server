using ASP.NET_Server.Models.StationModel;
using ASP.NET_Server.Models.StationStatus;

namespace ASP.NET_Server.Services.StationStatus
{
    public interface IStatusService
    {
        List<Status> Get();
        Status Get(string id);
        Status GetByDate(string date);
        Status Create(Status station);
        void Update(string id, Status station);
        void Remove(string id);
}
}
