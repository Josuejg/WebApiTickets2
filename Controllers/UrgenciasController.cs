using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTikects.DataBase;
using WebApiTikects.Models;

namespace WebApiTikects.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrgenciasController : ControllerBase
    {
        private readonly ContextoBD _contexto;

        public UrgenciasController(ContextoBD contexto)
        {
            _contexto = contexto;
        }

        // GET: api/Urgencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Urgencias>>> GetUrgencias()
        {
            return await _contexto.Urgencias.ToListAsync();
        }

        // GET: api/Urgencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Urgencias>> GetUrgencia(int id)
        {
            var urgencia = await _contexto.Urgencias.FindAsync(id);
            if (urgencia == null) return NotFound();

            return urgencia;
        }

        // POST: api/Urgencias
        [HttpPost]
        public async Task<ActionResult<Urgencias>> CreateUrgencia(Urgencias urgencia)
        {
            _contexto.Urgencias.Add(urgencia);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUrgencia), new { id = urgencia.ur_identificador }, urgencia);
        }

        // PUT: api/Urgencias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUrgencia(int id, Urgencias urgencia)
        {
            if (id != urgencia.ur_identificador) return BadRequest();

            var urgenciaExistente = await _contexto.Urgencias.FindAsync(id);
            if (urgenciaExistente == null) return NotFound();

            urgenciaExistente.ur_nivel = urgencia.ur_nivel;
            await _contexto.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Urgencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUrgencia(int id)
        {
            var urgencia = await _contexto.Urgencias.FindAsync(id);
            if (urgencia == null) return NotFound();

            _contexto.Urgencias.Remove(urgencia);
            await _contexto.SaveChangesAsync();

            return NoContent();
        }
    }

}
