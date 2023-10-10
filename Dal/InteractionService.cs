using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
namespace Dal
{
    public class InteractionService
    {
        private readonly IMongoCollection<Interaction> _interactionCollection;

        public InteractionService(
            IOptions<RandomColorsStoreDatabaseSettings> randomColorsStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
               randomColorsStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                randomColorsStoreDatabaseSettings.Value.DatabaseName);

            _interactionCollection = mongoDatabase.GetCollection<Interaction>(
                randomColorsStoreDatabaseSettings.Value.InteractionCollectionName);
        }

        public async Task<List<Interaction>> GetAsync() =>
       await _interactionCollection.Find(_ => true).ToListAsync();

    }
}
