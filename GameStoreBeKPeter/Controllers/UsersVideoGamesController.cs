using Microsoft.AspNetCore.Mvc;
using GameStoreBeKPeter.Users;
using GameStoreBeKPeter.Repositories;
using GameStoreBeKPeter.VideoGamesUsers;
using GameStoreBeKPeter.Context;
using Microsoft.EntityFrameworkCore;

namespace GameStoreBeKPeter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserVideoGameController : ControllerBase
    {
        private readonly ContextBasic _userGameRepository;

        public UserVideoGameController(ContextBasic userGameRepository)
        {
            _userGameRepository = userGameRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task < IActionResult > GetUserVideoGame()
        {
           return Ok(await _userGameRepository.VideoGamesUsers.ToListAsync()) ;
            
        }

        [HttpPost]
        [Route("Create")]
        public async Task < IActionResult > AddUserVideoGame(VideoGamesUser user)
        {
           await _userGameRepository.VideoGamesUsers.AddAsync(user);
           await _userGameRepository.SaveChangesAsync();  
           return Ok();
            
        }

    }

    
}