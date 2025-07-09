using UniConnect.Modals;
using UniConnect.Data;
using Microsoft.EntityFrameworkCore;

namespace UniConnect.Services
{
    public class LostFoundService
    {
        private readonly AppDbContext _context;

        public LostFoundService(AppDbContext context)
        {
            _context = context;
        }

        public event Action? OnChange;

        public async Task<List<LostFoundItem>> GetByTypeAsync(string type)
        {
            return await _context.LostFoundItems
                .Where(i => i.Type.ToLower() == type.ToLower())
                .OrderByDescending(i => i.PostedAt)
                .ToListAsync();
        }

        public async Task<LostFoundItem?> GetByIdAsync(int id)
        {
            return await _context.LostFoundItems.FindAsync(id);
        }

        public async Task AddItemAsync(LostFoundItem item)
        {
            if (item != null)
            {
                _context.LostFoundItems.Add(item);
                await _context.SaveChangesAsync();
                OnChange?.Invoke();
            }
        }

        public async Task DeleteItemAsync(int id)
        {
            var item = await _context.LostFoundItems.FindAsync(id);
            if (item != null)
            {
                _context.LostFoundItems.Remove(item);
                await _context.SaveChangesAsync();
                OnChange?.Invoke();
            }
        }
    }
}
