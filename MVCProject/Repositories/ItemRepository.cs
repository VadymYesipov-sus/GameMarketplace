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

        public async Task<Item> DeleteAsync(int id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Item> DetailsAsync(int id)
        {
            var item = await _context.Items
                .FirstOrDefaultAsync(i => i.ItemId == id);
            return item;
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item?> GetByIdAsync(int id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task<Item> ChangePriceAsync(Item item)
        {
            var changedItem = await _context.Items.FirstOrDefaultAsync(i => i.ItemId == item.ItemId);
            changedItem.Price = item.Price;
            await _context.SaveChangesAsync();
            return changedItem;
        }

    }
}
