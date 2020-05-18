namespace Messenger
{
    public class DatabaseSettings
    {
        public string EventStoreUri { get; }
        public string MongoDBUri { get; }
        public string DatabaseReadModels { get; }
        public string EventstoreUser { get; }
        public string EventstorePW { get; }

        public DatabaseSettings()
        {
        }

        public DatabaseSettings(string eventStoreUri, string mongoDbUri, string databaseReadModels,
            string eventstoreUser,
            string eventstorePw)
        {
            EventStoreUri = eventStoreUri;
            MongoDBUri = mongoDbUri;
            DatabaseReadModels = databaseReadModels;
            EventstoreUser = eventstoreUser;
            EventstorePW = eventstorePw;
        }
    }
}