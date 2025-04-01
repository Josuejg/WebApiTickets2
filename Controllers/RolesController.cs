using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTikects.DataBase;
using WebApiTikects.Models;

namespace WebApiTikects.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private readonly ContextoBD _contexto;

        public RolesController(ContextoBD contexto)
        {
            _contexto = contexto;

        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Roles>>> GetRoles()

        {
            return await _contexto.Roles.ToListAsync();
        }

        [HttpGet("{ro_identificador}")]
        public async Task<ActionResult<Roles>> GetRoles(int ro_identificador)
        {

            var rol = await _contexto.Roles.FindAsync(ro_identificador);
            if (rol == null) return NotFound();
            return rol;
        }


        [HttpPost]

        public async Task<ActionResult<Roles>> CreateRoles(Roles rol)
        {

            rol.ro_fecha_adicion = DateTime.UtcNow;
            _contexto.Roles.Add(rol);
            await _contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRoles), new { ro_identificador = rol.ro_identificador }, rol);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRoles(int id, Roles rol)
        {
            if (id != rol.ro_identificador) return BadRequest();
            var rolExistente = await _contexto.Roles.FindAsync(rol.ro_identificador);
            if (rolExistente == null) return NotFound();

            rolExistente.ro_descripcion = rol.ro_descripcion;
            rolExistente.ro_fecha_adicion = rol.ro_fecha_adicion;
            rolExistente.ro_adicionado_por = rol.ro_adicionado_por;
            rolExistente.ro_fecha_modificacion = rol.ro_fecha_modificacion;
            rolExistente.ro_modificado_por = rol.ro_modificado_por;

            await _contexto.SaveChangesAsync();
            return Ok(); // o NoContent()
        }

        [HttpDelete("id")]

        public async Task<ActionResult> DeleteRoles(int id) 
        {
            var rol = await _contexto.Roles.FindAsync(id);
            if (rol == null) return NotFound();

            _contexto.Roles.Remove(rol);
            await _contexto.SaveChangesAsync();

            return NoContent();

        }

    }
}
