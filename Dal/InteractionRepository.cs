using Entities.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class InteractionRepository
    {
        private readonly IMongoCollection<Interaction> _interactionCollection;

        public InteractionRepository(IOptions<Entities.Models.RandomColorsStoreDatabaseSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionString);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _interactionCollection = database.GetCollection<Interaction>(mongoDBSettings.Value.InteractionCollectionName);
        }
        public async Task<List<Interaction>> GetAsync() =>
          await _interactionCollection.Find(new BsonDocument()).ToListAsync();

//        _ => true
        /*
        public InteractionRepository(string connectionString, string databaseName, string collectionName)
        {
            var mongoClient = new MongoClient(connectionString);
            var database = mongoClient.GetDatabase(databaseName);
            _interactionCollection = database.GetCollection<Interaction>(collectionName);
        }

      
        */
    }
}
