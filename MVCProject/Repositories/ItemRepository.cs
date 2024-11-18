using InterviewMVCProject.Data;
using InterviewMVCProject.Models;
using Microsoft.EntityFrameworkCore;
using MVCProject.Interfaces;

namespace MVCProject.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Item> CreateAsync(Item item, int ownerId)
        {
            item.PlayerId = ownerId;
            Console.WriteLine($"Owner ID: {ownerId}, Player ID: {item.PlayerId}");
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.Items.ToListAsync();
        }


    }
}
