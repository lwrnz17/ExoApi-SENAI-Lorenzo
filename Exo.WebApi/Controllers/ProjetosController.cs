
using Microsoft.AspNetCore.Mvc;
using Exo.WebApi.Models;
using Exo.WebApi.Repositories;

namespace Exo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetosController : ControllerBase
    {
        private readonly ProjetoRepository _repository;

        public ProjetosController(ProjetoRepository repository)
        {
            _repository = repository;
        }

        // GET - Listar todos
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_repository.Listar());
        }

        // GET - Buscar por ID
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var projeto = _repository.BuscarPorId(id);

            if (projeto == null)
                return NotFound("Projeto não encontrado.");

            return Ok(projeto);
        }

        // POST - Cadastrar
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Projeto projeto)
        {
            _repository.Cadastrar(projeto);

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { id = projeto.Id },
                projeto
            );
        }

        // PUT - Atualizar
        [HttpPut("{id}")]
        public IActionResult Atualizar(
            int id,
            [FromBody] Projeto projeto)
        {
            bool atualizado = _repository.Atualizar(id, projeto);

            if (!atualizado)
                return NotFound("Projeto não encontrado.");

            return NoContent();
        }

        // DELETE - Excluir
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            bool deletado = _repository.Deletar(id);

            if (!deletado)
                return NotFound("Projeto não encontrado.");

            return NoContent();
        }
    }
}
