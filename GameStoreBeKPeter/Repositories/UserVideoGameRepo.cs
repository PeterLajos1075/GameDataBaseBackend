using GameStoreBeKPeter.Context;
using GameStoreBeKPeter.Users;
using GameStoreBeKPeter.VideoGames;
using GameStoreBeKPeter.VideoGamesUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStoreBeKPeter.Repositories
{
    public class UserVideoGameRepo : VideoGamesUser
    {
        private readonly ContextBasic _context;

        private UserVideoGameRepo(ContextBasic context)
        {
            _context = context;
        }

        public async Task<List<VideoGamesUser>> ReadAll() => await _context.VideoGamesUsers.ToListAsync();


        public async Task Create(VideoGamesUser entity)
        {
            await _context.VideoGamesUsers.AddAsync(entity);
            await _context.SaveChangesAsync();
        }


    }
}
