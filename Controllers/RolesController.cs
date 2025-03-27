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
    }
}
