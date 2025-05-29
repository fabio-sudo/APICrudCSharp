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

            return Ok(contato);          // Retorna status 200 (OK) com o contato inserido como resposta.
        }



        #endregion


    }
}
