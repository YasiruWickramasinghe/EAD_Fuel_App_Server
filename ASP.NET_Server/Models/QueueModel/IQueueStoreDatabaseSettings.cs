namespace ASP.NET_Server.Models.QueueModel
{
    public interface IQueueStoreDatabaseSettings
    {
        string QueueCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
