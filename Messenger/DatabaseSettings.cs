namespace Messenger
{
    public class DatabaseSettings
    {
        public string EventStoreUri { get; set; }
        public string Production_EventStoreUri { get; set; }
        public string MongoDBUri { get; set; }
        public string Production_MongoDBUri { get; set; }
        public string DatabaseReadModels { get; set; }
        public string EventstoreUser { get; set; }
        public string EventstorePW { get; set; }

        public DatabaseSettings()
        {
        }

        public DatabaseSettings(string eventStoreUri, string mongoDbUri, string databaseReadModels, string eventstoreUser,
            string eventstorePw, string productionEventStoreUri, string productionMongoDbUri)
        {
            EventStoreUri = eventStoreUri;
            MongoDBUri = mongoDbUri;
            DatabaseReadModels = databaseReadModels;
            EventstoreUser = eventstoreUser;
            EventstorePW = eventstorePw;
            Production_EventStoreUri = productionEventStoreUri;
            Production_MongoDBUri = productionMongoDbUri;
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