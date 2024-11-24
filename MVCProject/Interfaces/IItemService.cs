using InterviewMVCProject.Models;

namespace MVCProject.Interfaces
{
    public interface IItemService : IEntityService<Item>
    {
        Task<IEnumerable<Item>> GetAllAsync();
        Task<Item> CreateAsync(Item item, int ownerId);
        Task<Item> DeleteAsync(int id);
        Task<Item> DetailsAsync(int id);
        Task<Item> ChangePriceAsync(Item item);
    }
}
