using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTikects.DataBase;
using WebApiTikects.Models;

namespace WebApiTikects.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ContextoBD _contexto;

        public UsuariosController(ContextoBD contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsuarios()
        {
            return await _contexto.Usuarios.ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuarios(int id)
        {

            var user = await _contexto.Usuarios.FindAsync(id);
            if (user == null) return NotFound();
            return user;
        }


        [HttpPost]

        public async Task<ActionResult<Usuarios>> CreateUsuarios(Usuarios user)
        {

            user.us_fecha_adicion = DateTime.UtcNow;
            _contexto.Usuarios.Add(user);
            await _contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateUsuarios), new { us_fecha_adicion = user.us_fecha_adicion }, user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUsuarios(int id, Usuarios user)
        {
            if (id != user.us_identificador) return BadRequest();
            var userExistente = await _contexto.Usuarios.FindAsync(user.us_identificador);
            if (userExistente == null) return NotFound();

            userExistente.us_nombre_completo = user.us_nombre_completo;
            userExistente.us_correo = user.us_correo;
            userExistente.us_clave = user.us_clave;
            userExistente.us_ro_identificador = user.us_ro_identificador;
            userExistente.us_estado = user.us_estado;
            userExistente.us_fecha_adicion = user.us_fecha_adicion;
            userExistente.us_adicionado_por = user.us_adicionado_por;
            userExistente.us_fecha_modificacion = user.us_fecha_modificacion;
            userExistente.us_modificado_por = user.us_modificado_por;

            await _contexto.SaveChangesAsync();
            return Ok(); // o NoContent()
        }

        [HttpDelete("us_identificador")]

        public async Task<ActionResult> DeleteUsuarios(int us_identificador)
        {
            var User = await _contexto.Usuarios.FindAsync(us_identificador);
            if (User == null) return NotFound();

            _contexto.Usuarios.Remove(User);
            await _contexto.SaveChangesAsync();

            return NoContent();

        }

    }
}