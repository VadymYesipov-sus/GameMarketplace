using InterviewMVCProject.Models;
using MVCProject.Interfaces;

namespace MVCProject.Services
{
    public class GuildService : IGuildService
    {
        private readonly IGuildRepository _guildRepository;

        public GuildService(IGuildRepository guildRepository)
        {
            _guildRepository = guildRepository;
        }

        public async Task<Guild> CreateAsync(Guild guild)
        {
            return await _guildRepository.CreateAsync(guild);
        }

        public async Task<IEnumerable<Guild>> GetAllAsync()
        {
            return await _guildRepository.GetAllAsync();
        }

        public async Task<Guild?> GetByIdAsync(int id)
        {
            return await _guildRepository.GetByIdAsync(id);
        }

        public async Task<string> KickPlayerAsync(int guildId, int playerId)
        {
            //make logic for owner kick and authorized user can kick only
            await _guildRepository.KickPlayerAsync(guildId, playerId);
            return "Kick completed.";
        }
    }
}
