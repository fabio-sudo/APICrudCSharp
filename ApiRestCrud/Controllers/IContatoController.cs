using ApiRestCrud.Entities;
using ApiRestCrud.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IContatoController : ControllerBase
    {

        private readonly ContatoServico _servico;

        public  IContatoController(ContatoServico servico)
        {
            _servico = servico;
        }


        [HttpGet]
        public IActionResult GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var contatos = _servico.GetAll(pageNumber, pageSize);
            return Ok(contatos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contato = _servico.GetById(id);
            if (contato == null)
                return NotFound();

            return Ok(contato);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Contato contato)
        {
            var novoContato = _servico.Create(contato);
            return CreatedAtAction(nameof(GetById), new { id = novoContato.Id }, novoContato);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Contato contato)
        {
            if (id != contato.Id)
                return BadRequest("ID do contato não confere.");

            var atualizado = _servico.Update(contato);
            return Ok(atualizado);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contato = _servico.GetById(id);
            if (contato == null)
                return NotFound();

            var excluido = _servico.Delete(contato);
            return Ok(excluido);
        }
    }
}

