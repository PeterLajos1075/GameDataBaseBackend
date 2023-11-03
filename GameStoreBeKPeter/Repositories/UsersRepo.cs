using GameStoreBeKPeter.Users;
using GameStoreBeKPeter.Context;
using Microsoft.EntityFrameworkCore;
using GameStoreBeKPeter.VideoGames;

namespace GameStoreBeKPeter.Repositories
{
    public class UsersRepo : ICrud<User>
    {
        private readonly ContextBasic _context;
         
        public UsersRepo(ContextBasic context)
        {
            _context = context;
        }
        
        public async Task<List<User>> ReadAll() => await _context.Users.Include(c => c.VideoGames).ToListAsync();

        public async Task<List<User>> ReadById(int id) => await _context.Users.Where(c => c.Id == id).ToListAsync();


        public async Task Create(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id , User entity)
        {
            var data = await _context.Users.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (data != null)
            {
                data.Email = entity.Email;
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var data = await _context.Users.Where(s => s.Id == id).FirstOrDefaultAsync();
            if (data != null)
            {
                _context.Users.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        



    }
}
