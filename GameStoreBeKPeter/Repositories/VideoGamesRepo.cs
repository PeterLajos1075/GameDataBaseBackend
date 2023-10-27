using Microsoft.EntityFrameworkCore;
using GameStoreBeKPeter.Context;
using GameStoreBeKPeter.VideoGames;
using GameStoreBeKPeter.Controllers;

namespace GameStoreBeKPeter.Repositories
{
    public class VideoGamesRepo : ICrud<VideoGame>
    {
        private readonly ContextBasic _context;

        public VideoGamesRepo(ContextBasic context)
        {
            _context = context;
        }

        public async Task<List<VideoGame>> ReadAll() => await _context.VideoGames.ToListAsync();

        public async Task<List<VideoGame>> ReadById(int id) => await _context.VideoGames.Where(c => c.Id == id).ToListAsync();

        public async Task Create(VideoGame entity)
        {
            await _context.VideoGames.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var data = await _context.VideoGames.Where(s => s.Id == id).FirstOrDefaultAsync();
            if (data != null)
            {
                _context.VideoGames.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(int id, VideoGame entity)
        {
            var data = await _context.VideoGames.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (data != null)
            {
                data.Title = entity.Title;
                data.Description = entity.Description;
                data.Type = entity.Type;
                data.Price = entity.Price;
                data.Rating = entity.Rating;

                await _context.SaveChangesAsync();
            }
        }
    }
}
