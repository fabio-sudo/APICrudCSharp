using ApiRestCrud.Entities;

namespace ApiRestCrud.Interface
{
    public interface IContato
    {
        List<Contato> GetAll(int pageNumber, int pageSize);                     // Retorna todos os contatos
        Contato GetById(int id);                    // Retorna um contato pelo ID
        Contato Create(Contato contato);            // Cria um novo contato
        Contato Update(Contato contato);            // Atualiza um contato existente
        Contato Delete(Contato contato);            // Remove um contato
    }
}
