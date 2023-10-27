using Microsoft.AspNetCore.Mvc;
using GameStoreBeKPeter.Users;

namespace GameStoreBeKPeter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControllerBasic : ControllerBase
    {
        private readonly ICrud<User> _userRepository;

        [HttpGet]
           public async Task<IEnumerable<User>> Read() => await _userRepository.Read();
 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User entity)
        {
            if(id > 0)
            {
                await _userRepository.Update(id, entity);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            _userRepository.Create(user);
            return NoContent();
        }
        
        
        [HttpDelete("{id}")]
        public async Task<AcceptedResult> Delete(int id)
        {
            await _userRepository.Delete(id);
            return NoContent();
        }
    }
}