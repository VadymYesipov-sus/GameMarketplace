using InterviewMVCProject.Models;

namespace MVCProject.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();

        Task<Item> CreateAsync(Item item, int ownerId);

    }
}
