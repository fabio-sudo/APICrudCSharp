using ApiRestCrud.Context;
using ApiRestCrud.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context; // Injeção do DbContext para acessar o banco de dados.

        // Construtor do controller, com injeção de dependência do contexto (AgendaContext).
        public ContatoController(AgendaContext agendaContext)
        {
            _context = agendaContext; // Armazena a instância injetada do banco para uso posterior.
        }


        #region End_Points Direto
        // Rota: POST api/contato
        // Método para criar um novo Contato no banco de dados.
        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);       // Adiciona o objeto 'contato' à memória do DbContext.
            _context.SaveChanges();      // Salva de fato no banco (executa o INSERT).

           // return Ok(contato);          // Retorna status 200 (OK) com o contato inserido como resposta.
           return CreatedAtAction(nameof(ObterPorId),new {id = contato.Id}, contato);//retorna rota para buscar contato add
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id,Contato contato) {

            var contatoBanco = _context.Contato.Find(id);

            if (contatoBanco == null) 
                return NotFound(); 

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Ativo = contato.Ativo;
            contatoBanco.Telefone = contato.Telefone;

            _context.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);
        
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contatoBanco = _context.Contato.Find(id);

            if (contatoBanco == null)
                return NotFound();

            _context.Remove(contatoBanco);
            _context.SaveChanges();

            //return Ok(contatoBanco);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contato = _context.Contato.Find(id);

            if (contato == null)
                return NotFound();


            return Ok(contato);
        }

        [HttpGet("ObterPorNome/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            var contatos = _context.Contato.Where(x=> x.Nome.Contains(nome)).ToList();  
            return Ok(contatos);
        }
        #endregion


    }
}
