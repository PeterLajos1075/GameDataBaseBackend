using GameStoreBeKPeter.VideoGames;
using Microsoft.AspNetCore.Mvc;
using GameStoreBeKPeter.Repositories;
using Microsoft.AspNetCore.Identity;

namespace GameStoreBeKPeter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoGamesController : ControllerBase
    {
        private readonly ICrud<VideoGame> _videoGameRepo;

        public  VideoGamesController(ICrud<VideoGame> VideoGameRepo)
        {
            _videoGameRepo = VideoGameRepo;
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<VideoGame>> ReadAll()
        {
            var all = await _videoGameRepo.ReadAll();
            return all;
        }


        [HttpGet]
        [Route("GetById/{id}")]
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
        [Route("Create")]

        public async Task<ActionResult> Create(VideoGame videoGame)
        {
            await _videoGameRepo.Create(videoGame);
            return NoContent();
        }


        [HttpPut]
        [Route("Update/{id}")]

        public async Task<IActionResult> Update(int id,VideoGame entity)
        {
           if(id > 0)
           {
               await _videoGameRepo.Update(id, entity);
               return Ok();
           }
           return BadRequest();
        }

       
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _videoGameRepo.Delete(id);
            return NoContent();
        }
    }
}
