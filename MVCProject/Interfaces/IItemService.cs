using InterviewMVCProject.Models;

namespace MVCProject.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAllAsync();
        Task<Item> CreateAsync(Item item, int ownerId);
    }
}
