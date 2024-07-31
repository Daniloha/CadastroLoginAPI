using APICadastro.Buisness;
using APICadastro.Models;
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
        private IPersonBuisness _personBuisness;

        public CadastroController(ILogger<CadastroController> logger, IPersonBuisness personBusiness)
        {
            _logger = logger;
            _personBuisness = personBusiness;
        }

        [HttpGet]// Retorna todos os dados
        public IActionResult Get()
        {
            try
            {
                var pessoas = _personBuisness.FindAll();
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
            var pessoa = _personBuisness.FindByID(ID);
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

            return Ok(_personBuisness.Create(pessoa));
        }

        [HttpPut]// Atualiza um dado
        public IActionResult Put([FromBody] Pessoa pessoa)
        {
            if (pessoa == null) return BadRequest();
            return Ok(_personBuisness.Update(pessoa));
        }

        [HttpDelete("{ID}")]// Deleta um dado
        public IActionResult Delete(long ID)
        {
            if (ID <= 0) return BadRequest();
            
            _personBuisness.Delete(ID);
            return NoContent();
        }
    }
}
