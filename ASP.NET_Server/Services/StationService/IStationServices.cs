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
