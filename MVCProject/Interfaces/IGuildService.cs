﻿using InterviewMVCProject.Models;

namespace MVCProject.Interfaces
{
    public interface IGuildService
    {
        Task<Guild> CreateAsync(Guild guild);
        Task<Guild?> GetByIdAsync(int id);
        Task<IEnumerable<Guild>> GetAllAsync();
        Task<string> KickPlayerAsync(int guildId, int playerId);
    }
}
