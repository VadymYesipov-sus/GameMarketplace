using InterviewMVCProject.Models;

namespace MVCProject.Interfaces
{
    public interface IPlayerService : IEntityService<Player>
    {
        Task<Player> CreateAsync(Player player);

        Task<Player> EditAsync(Player player);
        Task<Player> DeleteAsync(int id);
        Task<Player> DetailsAsync(int id);
        Task<IEnumerable<Player>> GetAllAsync();

    }
}
