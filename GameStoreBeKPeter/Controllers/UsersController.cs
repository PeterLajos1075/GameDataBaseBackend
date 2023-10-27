using Microsoft.AspNetCore.Mvc;
using GameStoreBeKPeter.Users;

namespace GameStoreBeKPeter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ICrud<User> _userRepository;

        public UserController(ICrud<User> userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<User>> ReadAll()
        {
           var all = await _userRepository.ReadAll();
           return all;
        }
        


        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult> ReadById(int id)
        {
            var User = await _userRepository.ReadById(id);
            if(User == null)
            {
                return NotFound();
            }
            return Ok(User);
        }



        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create(User user)
        {
             await _userRepository.Create(user);
            return NoContent();
        }


 
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(int id, User entity)
        {
            if(id > 0)
            {
                await _userRepository.Update(id, entity);
                return Ok();
            }
            return BadRequest();
        }

        
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userRepository.Delete(id);
            return NoContent();
        }
    }
}