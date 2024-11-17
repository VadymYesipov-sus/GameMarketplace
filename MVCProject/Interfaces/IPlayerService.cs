using InterviewMVCProject.Models;

namespace MVCProject.Interfaces
{
    public interface IPlayerService : IEntityService<Player>
    {
        public Task<Player> CreateAsync(Player player);

        public Task<Player> EditAsync(Player player);
        public Task<Player> DeleteAsync(int id);
        public Task<Player> DetailsAsync(int id);
        public Task<IEnumerable<Player>> GetAllAsync();

    }
}
