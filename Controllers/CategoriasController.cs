using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTikects.DataBase;
using WebApiTikects.Models;

namespace WebApiTikects.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ContextoBD _contexto;

        public CategoriasController(ContextoBD contexto)
        {
            _contexto = contexto;
        }

        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorias>>> GetCategorias()
        {
            return await _contexto.Categorias.ToListAsync();
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categorias>> GetCategoria(int id)
        {
            var categoria = await _contexto.Categorias.FindAsync(id);
            if (categoria == null) return NotFound();

            return categoria;
        }

        // POST: api/Categorias
        [HttpPost]
        public async Task<ActionResult<Categorias>> CreateCategoria(Categorias categoria)
        {
            _contexto.Categorias.Add(categoria);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.ca_identificador }, categoria);
        }

        // PUT: api/Categorias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoria(int id, Categorias categoria)
        {
            if (id != categoria.ca_identificador) return BadRequest();

            var categoriaExistente = await _contexto.Categorias.FindAsync(id);
            if (categoriaExistente == null) return NotFound();

            categoriaExistente.ca_nombre = categoria.ca_nombre;
            await _contexto.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _contexto.Categorias.FindAsync(id);
            if (categoria == null) return NotFound();

            _contexto.Categorias.Remove(categoria);
            await _contexto.SaveChangesAsync();

            return NoContent();
        }
    }

}
