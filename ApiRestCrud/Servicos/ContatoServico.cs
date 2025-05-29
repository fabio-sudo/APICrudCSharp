using ApiRestCrud.Context;
using ApiRestCrud.Entities;
using ApiRestCrud.Interface;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ApiRestCrud.Servicos
{
    public class ContatoServico : IContato
    {
        private readonly AgendaContext _contexto;

        public ContatoServico(AgendaContext agendaContext)
        {
            _contexto = agendaContext;
        }

        public Contato Create(Contato contato)
        {
            _contexto.Add(contato);
            _contexto.SaveChanges();
            return contato;
        }

        public Contato Delete(Contato contato)
        {
            _contexto.Remove(contato);
            _contexto.SaveChanges();
            return contato;
        }

        public List<Contato> GetAll(int pageNumber, int pageSize)
        {
            return _contexto.Contato
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
        }

        public Contato GetById(int id)
        {
            // Busca contato pelo id ou retorna null se não encontrar
            return _contexto.Contato.FirstOrDefault(c => c.Id == id);
        }

        public Contato Update(Contato contato)
        {
            // Atualiza um contato existente
            _contexto.Contato.Update(contato);
            _contexto.SaveChanges();
            return contato;
        }
    }
}
