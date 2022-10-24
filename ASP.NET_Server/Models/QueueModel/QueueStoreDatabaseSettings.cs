namespace ASP.NET_Server.Models.QueueModel
{
    public class QueueStoreDatabaseSettings : IQueueStoreDatabaseSettings
    {
        public string QueueCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
