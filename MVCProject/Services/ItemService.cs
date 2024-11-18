using InterviewMVCProject.Models;
using MVCProject.Interfaces;

namespace MVCProject.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Item> CreateAsync(Item item, int ownerId)
        {
            return await _itemRepository.CreateAsync(item, ownerId);
        }

        public async Task<Item> DeleteAsync(int id)
        {
            return await _itemRepository.DeleteAsync(id);
        }

        public async Task<Item> DetailsAsync(int id)
        {
            return await _itemRepository.DetailsAsync(id);
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _itemRepository.GetAllAsync();
        }

        public async Task<Item?> GetByIdAsync(int id)
        {
            return await _itemRepository.GetByIdAsync(id);
        }
    }
}
