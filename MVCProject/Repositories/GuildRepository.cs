using InterviewMVCProject.Data;
using InterviewMVCProject.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MVCProject.Interfaces;

namespace MVCProject.Repositories
{
    public class GuildRepository : IGuildRepository
    {
        private readonly ApplicationDbContext _context;

        public GuildRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guild> CreateAsync(Guild guild)
        {
            //var guildOwner = await _context.Players.FindAsync(id);
            //guild.Players.Add(guildOwner);
            _context.Add(guild);
            await _context.SaveChangesAsync();
            return guild;
        }

        public async Task<IEnumerable<Guild>> GetAllAsync()
        {
            return await _context.Guilds.ToListAsync();
        }

        public async Task<Guild?> GetByIdAsync(int id)
        {
            return await _context.Guilds.FindAsync(id);
        }

        public async Task<string> KickPlayerAsync(int guildId, int playerId)
        {
            var guild = await _context.Guilds
                .Include(g => g.Players)
                .FirstOrDefaultAsync(g => g.GuildId == guildId);
            var player = await _context.Players.FindAsync(playerId);
            guild.Players.Remove(player);
            await _context.SaveChangesAsync();
            return $"Player {player.Name} kicked from guild";
        }
    }
}
