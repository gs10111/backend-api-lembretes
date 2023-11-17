using WebApplication4.Models;

namespace WebApplication4.Services
{
    public interface IReminderService
    {
        Task<IEnumerable<Reminder>> GetAllAsync();
        Task<Reminder> GetById(string id);
        Task CreateAsync(Reminder reminder);
        Task UpdateAsync(String id, Reminder reminder);
        Task DeleteAsync(string id);

    }
}