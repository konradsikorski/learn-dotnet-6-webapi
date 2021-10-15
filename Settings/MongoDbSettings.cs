namespace Catalog.Settings
{
    public class MongoDbSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string User {get; set;}
        public string Password { get; set; }

        // must be last in class, the order matters
        public string ConnectionString => $"mongodb://{User}:{Password}@{Host}:{Port}";
    }
}