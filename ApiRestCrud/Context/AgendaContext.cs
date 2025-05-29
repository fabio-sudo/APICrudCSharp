using ApiRestCrud.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiRestCrud.Context
{
    public class AgendaContext:DbContext
    {
        // Construtor da classe AgendaContext que recebe as opções de configuração do DbContext
        public AgendaContext(DbContextOptions<AgendaContext> options)
            : base(options) // Passa as opções recebidas para a classe base (DbContext)
        {

        }

        // Representa a tabela de Contatos no banco de dados.
        // Essa propriedade permite realizar operações como inserir, atualizar, excluir e consultar contatos.
        public DbSet<Contato> Contato { get; set; }
    }
}
