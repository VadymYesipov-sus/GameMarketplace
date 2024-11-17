using InterviewMVCProject.Data;
using InterviewMVCProject.Models;
using MVCProject.Interfaces;

namespace MVCProject.Services
{
    public class PlayerService : IPlayerService, IEntityService<Player>

    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<Player> CreateAsync(Player player)
        {
            return await _playerRepository.CreateAsync(player);
        }

        public async Task<Player> DeleteAsync(int id)
        {
            return await _playerRepository.DeleteAsync(id);
        }

        public async Task<Player> DetailsAsync(int id)
        {
           return await _playerRepository.DetailsAsync(id);
        }

        public async Task<Player> EditAsync(Player player)
        {
            return await _playerRepository.EditAsync(player);
        }

        public async Task<Player?> GetByIdAsync(int id)
        {
            return await _playerRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            return await _playerRepository.GetAllAsync();
        }
    }
}
