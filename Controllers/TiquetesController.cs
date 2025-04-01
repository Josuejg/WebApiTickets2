using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTikects.DataBase;
using WebApiTikects.Models;


namespace WebApiTikects.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiquetesController : ControllerBase
    {
        private readonly ContextoBD _contexto;


        public TiquetesController(ContextoBD contexto)
        {
            _contexto=contexto;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Tiquetes>>> GetTiquetes()

        {
            return await _contexto.Tiquetes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tiquetes>> GetTiquetes(int id)
        {

            var tick = await _contexto.Tiquetes.FindAsync(id);
            if (tick == null) return NotFound();
            return tick;
        }

        [HttpPost]
        public async Task<ActionResult<Tiquetes>> CreateTiquetes(Tiquetes tick)
        {
            tick.ti_fecha_adicion = DateTime.UtcNow;
            _contexto.Tiquetes.Add(tick);
            await _contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTiquetes), new { id = tick.ti_identificador }, tick);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTiquetes(int id, Tiquetes tick)
        {
            if (id != tick.ti_identificador) return BadRequest();
            var tickExistente = await _contexto.Tiquetes.FindAsync(tick.ti_identificador);
            if (tickExistente == null) return NotFound();

            tickExistente.ti_asunto = tick.ti_asunto;
            tickExistente.ti_ca_id = tick.ti_ca_id;
            tickExistente.ti_us_id_asigna = tick.ti_us_id_asigna;
            tickExistente.ti_estado = tick.ti_estado;
            tickExistente.ti_solucion = tick.ti_solucion;
            tickExistente.ti_fecha_adicion = tick.ti_fecha_adicion;
            tickExistente.ti_adicionado_por = tick.ti_adicionado_por;
            tickExistente.ti_fecha_modificacion = tick.ti_fecha_modificacion;
            tickExistente.ti_modificado_por = tick.ti_modificado_por;

            await _contexto.SaveChangesAsync();
            return Ok(); // o NoContent()
        }

        [HttpDelete("ti_identificador")]

        public async Task<ActionResult> DeleteTiquetes(int ti_identificador)
        {
            var tick = await _contexto.Tiquetes.FindAsync(ti_identificador);
            if (tick == null) return NotFound();

            _contexto.Tiquetes.Remove(tick);
            await _contexto.SaveChangesAsync();

            return NoContent();

        }
    }
}
