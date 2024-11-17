using InterviewMVCProject.Data;
using InterviewMVCProject.Models;
using Microsoft.EntityFrameworkCore;
using MVCProject.Interfaces;
using MVCProject.Services;

namespace MVCProject.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext _context;

        public PlayerRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<Player> CreateAsync(Player player)
        {
            _context.Add(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<Player> DeleteAsync(int id)
        {
            var player = await _context.Players.FindAsync(id);
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<Player> DetailsAsync(int id)
        {
            var player = await _context.Players
                .Include(p => p.Items)
                .FirstOrDefaultAsync(p => p.PlayerId == id);
            return player;
        }

        public async Task<Player> EditAsync(Player editPlayer)
        {
            var player = await _context.Players.FirstOrDefaultAsync(p => p.PlayerId == editPlayer.PlayerId);
            player.Name = editPlayer.Name ?? player.Name;
            player.MoneyAmount = editPlayer.MoneyAmount;
            await _context.SaveChangesAsync();
            return editPlayer;
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task<Player?> GetByIdAsync(int id)
        {
            return await _context.Players.FindAsync(id);
        }
    }
}
