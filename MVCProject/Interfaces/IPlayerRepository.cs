using InterviewMVCProject.Models;

namespace MVCProject.Interfaces
{
    public interface IPlayerRepository
    {
        Task<IEnumerable<Player>> GetAllAsync();
        Task<Player?> GetByIdAsync(int id);
        Task<Player> CreateAsync(Player player);
        Task<Player> EditAsync(Player player);
        Task<Player> DeleteAsync(int id);
        Task<Player> DetailsAsync(int id);
        
    }
}
