using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTikects.DataBase;
using WebApiTikects.Models;

namespace WebApiTikects.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportanciasController : ControllerBase
    {
        private readonly ContextoBD _contexto;

        public ImportanciasController(ContextoBD contexto)
        {
            _contexto = contexto;
        }

        // GET: api/Importancias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Importancias>>> GetImportancias()
        {
            return await _contexto.Importancias.ToListAsync();
        }

        // GET: api/Importancias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Importancias>> GetImportancia(int id)
        {
            var importancia = await _contexto.Importancias.FindAsync(id);
            if (importancia == null) return NotFound();

            return importancia;
        }

        // POST: api/Importancias
        [HttpPost]
        public async Task<ActionResult<Importancias>> CreateImportancia(Importancias importancia)
        {
            _contexto.Importancias.Add(importancia);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction(nameof(GetImportancia), new { id = importancia.im_identificador }, importancia);
        }

        // PUT: api/Importancias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImportancia(int id, Importancias importancia)
        {
            if (id != importancia.im_identificador) return BadRequest();

            var importanciaExistente = await _contexto.Importancias.FindAsync(id);
            if (importanciaExistente == null) return NotFound();

            importanciaExistente.im_nivel = importancia.im_nivel;
            await _contexto.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Importancias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImportancia(int id)
        {
            var importancia = await _contexto.Importancias.FindAsync(id);
            if (importancia == null) return NotFound();

            _contexto.Importancias.Remove(importancia);
            await _contexto.SaveChangesAsync();

            return NoContent();
        }
    }

}
