using InterviewMVCProject.Models;

namespace MVCProject.Interfaces
{
    public interface IPlayerRepository
    {
        public Task<IEnumerable<Player>> GetAllAsync();

        public Task<Player?> GetByIdAsync(int id);
        public Task<Player> CreateAsync(Player player);
        public Task<Player> EditAsync(Player player);
        public Task<Player> DeleteAsync(int id);
        public Task<Player> DetailsAsync(int id);
        
    }
}
