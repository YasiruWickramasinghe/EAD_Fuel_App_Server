using ASP.NET_Server.Models.QueueModel;
using MongoDB.Driver;


namespace ASP.NET_Server.Services.QueueService
{
    public class QueueService : IQueueServices
    {
        private readonly IMongoCollection<Queue> _queue;

        public QueueService(IQueueStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _queue = database.GetCollection<Queue>(settings.QueueCollectionName);
        }
        public Queue Create(Queue queue)
        {
            _queue.InsertOne(queue);
            return queue;
        }

        public List<Queue> Get()
        {
            return _queue.Find(queue => true).ToList();
        }

        public Queue Get(string id)
        {
            return _queue.Find(queue => queue.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _queue.DeleteOne(queue => queue.Id == id);
        }

        public void Update(string id, Queue queue)
        {
            _queue.ReplaceOne(queue => queue.Id == id, queue);
        }
    }
}
