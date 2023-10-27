using GameStoreBeKPeter.VideoGames;
using Microsoft.AspNetCore.Mvc;
using GameStoreBeKPeter.Repositories;
using Microsoft.AspNetCore.Identity;

namespace GameStoreBeKPeter.Controllers
{
    public class VideoGamesController : ControllerBase
    {
        private readonly ICrud<VideoGame> _videoGameRepo;

        public  VideoGamesController(ICrud<VideoGame> VideoGameRepo)
        {
            _videoGameRepo = VideoGameRepo;
        }


        [HttpGet]
        public async Task<IEnumerable<VideoGame>> ReadAll()
        {
            var all = await _videoGameRepo.ReadAll();
            return all;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> ReadById(int id)
        {
            var videogame = await _videoGameRepo.ReadById(id);
            if (videogame == null)
            {
                return NotFound();
            }
            return Ok();
        } 


        [HttpPost]
        public async Task<ActionResult> Create(VideoGame videoGame)
        {
            await _videoGameRepo.Create(videoGame);
            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,VideoGame entity)
        {
           if(id > 0)
           {
               await _videoGameRepo.Update(id, entity);
               return Ok();
           }
           return BadRequest();
        }

       
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _videoGameRepo.Delete(id);
            return NoContent();
        }
    }
}
