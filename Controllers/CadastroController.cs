using APICadastro.Models;
using APICadastro.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace APICadastro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CadastroController : ControllerBase
    {
       
        private readonly ILogger<CadastroController> _logger;
        private IPersonService _personService;

        public CadastroController(ILogger<CadastroController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var pessoas = _personService.FindAll();
                return Ok(pessoas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar dados: {ex.Message}");
            }
        }
         [HttpGet("{ID}")]
        public IActionResult Get(long ID)
        {
            var pessoa = _personService.FindByID(ID);
            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            if (pessoa == null) return BadRequest();

            return Ok(_personService.Create(pessoa));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Pessoa pessoa)
        {
            if (pessoa == null) return BadRequest();
            return Ok(_personService.Update(pessoa));
        }

        [HttpDelete("{ID}")]
        public IActionResult Delete(long ID)
        {
            if (ID <= 0) return BadRequest();
            
            _personService.Delete(ID);
            return NoContent();
        }
    }
}
