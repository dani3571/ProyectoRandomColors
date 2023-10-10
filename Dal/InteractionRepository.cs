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



        public async Task CreateAsync(Interaction interaction)
        {
            try
            {
                await _interactionCollection.InsertOneAsync(interaction);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        private string GenerarColorConRedesNeuronales()
        {
            // Lógica para generar un color utilizando redes neuronales
            // Puedes implementar aquí tu algoritmo de generación de colores
            // y devolver el color en un formato adecuado (por ejemplo, como un código hexadecimal).
            return "#FFAABB"; // Ejemplo de un color hexadecimal
        }
    }
}
