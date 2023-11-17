using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApplication4.Models;

namespace WebApplication4.Services
{
    public class ReminderService : IReminderService
    {
        private readonly IMongoCollection<Reminder> _remindersCollection;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public ReminderService(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _remindersCollection = mongoDatabase.GetCollection<Reminder>
                (dbSettings.Value.RemindersCollectionName);
        }

        public async Task<IEnumerable<Reminder>> GetAllAsync()
        {
            var reminders = await _remindersCollection.Find(_ => true).ToListAsync();
            return reminders;
        } 

        public async Task<Reminder> GetById(string id)
        {
            var reminder = await _remindersCollection.Find(a => a.Id == id).FirstOrDefaultAsync();
            return reminder;
        }

        public async Task CreateAsync(Reminder reminder)
        {
            await _remindersCollection.InsertOneAsync(reminder);
        }

        public async Task UpdateAsync(String id, Reminder reminder)
        {
            await _remindersCollection.
                FindOneAndReplaceAsync(a => a.Id == id, reminder);
        }

        public async Task DeleteAsync(string id)
        {
            await _remindersCollection.DeleteOneAsync(a => a.Id.Equals(id));
        }
    }
}
