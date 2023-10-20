using Microsoft.AspNetCore.Mvc;

namespace GameStoreBeKPeter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControllerBasic : ControllerBase
    {
        private readonly ICrud<ModelBasic> _repositori;

        public ControllerBasic(ICrud<ModelBasic> repositori)
        {
            _repositori = repositori;
        }
        [HttpGet]
        public async Task<IEnumerable<ModelBasic>> Read() => await _repositori.Read();

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ModelBasic entity)
        {
            {

            }
            return BadRequest();
        }
    }
}