using UniConnect.Data;
using UniConnect.Modals;
using Microsoft.EntityFrameworkCore;

namespace UniConnect.Services
{
    public class EventService
    {
        private readonly AppDbContext _context;

        public EventService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Event>> GetEventsAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event?> GetEventByIdAndCategoryAsync(int id, string category)
        {
            return await _context.Events
                .FirstOrDefaultAsync(e => e.Id == id && e.Category.ToLower() == category.ToLower());
        }

        public async Task AddEventAsync(Event newEvent)
        {
            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();
        }
    }
}