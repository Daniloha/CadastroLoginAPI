using APICadastro.Models;
using APICadastro.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace APICadastro.Controllers
{

    
    [ApiVersion("1.0")]// Versão da API
    [ApiController]// Controlador
    [Route("api/[controller]/v{version:apiVersion}")]// Rota
    public class CadastroController : ControllerBase
    {
       //Logger de logs de erros
        private readonly ILogger<CadastroController> _logger;

        //Serviço de dados
        private IPersonService _personService;

        public CadastroController(ILogger<CadastroController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]// Retorna todos os dados
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
         [HttpGet("{ID}")]// Retorna apenas um dado
        public IActionResult Get(long ID)
        {
            var pessoa = _personService.FindByID(ID);
            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }

        [HttpPost]// Cria um novo dado
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            if (pessoa == null) return BadRequest();

            return Ok(_personService.Create(pessoa));
        }

        [HttpPut]// Atualiza um dado
        public IActionResult Put([FromBody] Pessoa pessoa)
        {
            if (pessoa == null) return BadRequest();
            return Ok(_personService.Update(pessoa));
        }

        [HttpDelete("{ID}")]// Deleta um dado
        public IActionResult Delete(long ID)
        {
            if (ID <= 0) return BadRequest();
            
            _personService.Delete(ID);
            return NoContent();
        }
    }
}
