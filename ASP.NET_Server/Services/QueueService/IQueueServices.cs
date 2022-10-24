using ASP.NET_Server.Models.QueueModel;

namespace ASP.NET_Server.Services.QueueService
{
    public interface IQueueServices
    {
        List<Queue> Get();
        Queue Get(string id);
        Queue Create(Queue queue);
        void Update(string id, Queue queue);
        void Remove(string id);
    }
}
