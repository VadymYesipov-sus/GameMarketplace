using InterviewMVCProject.Models;

namespace MVCProject.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();

        Task<Item> CreateAsync(Item item, int ownerId);
        Task<Item?> GetByIdAsync(int id);
        Task<Item> DeleteAsync(int id);
        Task<Item> DetailsAsync(int id);

    }
}
