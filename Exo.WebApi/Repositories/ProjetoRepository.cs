
using Exo.WebApi.Contexts;
using Exo.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Exo.WebApi.Repositories
{
    public class ProjetoRepository
    {
        private readonly ExoContext _context;

        public ProjetoRepository(ExoContext context)
        {
            _context = context;
        }

        // GET - Listar todos os projetos
        public List<Projeto> Listar()
        {
            return _context.Projetos
                .AsNoTracking()
                .ToList();
        }

        // GET - Buscar projeto pelo ID
        public Projeto BuscarPorId(int id)
        {
            return _context.Projetos.Find(id);
        }

        // POST - Cadastrar projeto
        public void Cadastrar(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            _context.SaveChanges();
        }

        // PUT - Atualizar projeto
        public bool Atualizar(int id, Projeto projeto)
        {
            Projeto projetoExistente = BuscarPorId(id);

            if (projetoExistente == null)
                return false;

            projetoExistente.NomeDoProjeto = projeto.NomeDoProjeto;
            projetoExistente.Area = projeto.Area;
            projetoExistente.Status = projeto.Status;

            _context.SaveChanges();
            return true;
        }

        // DELETE - Excluir projeto
        public bool Deletar(int id)
        {
            Projeto projeto = BuscarPorId(id);

            if (projeto == null)
                return false;

            _context.Projetos.Remove(projeto);
            _context.SaveChanges();

            return true;
        }
    }
}
