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
        private readonly IMongoCollection<Users> _usersCollection;

        public InteractionRepository(IOptions<Entities.Models.RandomColorsStoreDatabaseSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionString);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _interactionCollection = database.GetCollection<Interaction>(mongoDBSettings.Value.InteractionCollectionName);
            _usersCollection = database.GetCollection<Users>(mongoDBSettings.Value.InteractionCollectionName);
        }
        public async Task<List<Interaction>> GetAsync() =>
          await _interactionCollection.Find(new BsonDocument()).ToListAsync();
        public async Task<Users> GetUserAsync(string email)
        {
            Users user = await _usersCollection.Find(new BsonDocument("Email", email)).FirstOrDefaultAsync();
            return user;
        }
        public async Task<UserRequest> GetReactionAsync(string email)
        {
            Users user = await _usersCollection.Find(new BsonDocument("Email", email)).FirstOrDefaultAsync();
            UserRequest userReq = new UserRequest();
            userReq.hasReaction = false;
            if (user != null)
            {
                userReq.hasReaction = true;
                return userReq;
            }
            return userReq;
        }

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
        public async Task CreateNewUserAsync(Users user)
        {
            try
            {
                await _usersCollection.InsertOneAsync(user);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
