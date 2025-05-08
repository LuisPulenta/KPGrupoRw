using Common.Helpers;
using Common.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Web.Data;
using Web.Data.Entities;

namespace Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObrasController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IFilesHelper _filesHelper;

        public ObrasController(DataContext dataContext,IFilesHelper filesHelper)
        {
            _dataContext = dataContext;
            _filesHelper = filesHelper;
        }

        //-------------------------------------------------------------------------------------
        [HttpPut]
        [Route("PutDatosObra/{id}")]
        public async Task<IActionResult> PutDatosObra([FromRoute] int id, [FromBody] ObraDatosRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != request.NroObra)
            {
                return BadRequest();
            }

            var oldObra = await _dataContext.Obras.FindAsync(request.NroObra);
            if (oldObra == null)
            {
                return BadRequest("La Obra no existe.");
            }

            oldObra.POSX = request.POSX;
            oldObra.POSY = request.POSY;
            oldObra.Direccion = request.Direccion;
            oldObra.TextoLocalizacion = request.TextoLocalizacion;
            oldObra.TextoClase = request.TextoClase;
            oldObra.TextoTipo = request.TextoTipo;
            oldObra.TextoComponente = request.TextoComponente;
            oldObra.CodigoDiametro = request.CodigoDiametro;
            oldObra.Motivo = request.Motivo;
            oldObra.Planos = request.Planos;

            _dataContext.Obras.Update(oldObra);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }

        //-----------------------------------------------------------------------------------
        [HttpPost]
        [Route("GetObras/{ProyectoModulo}")]
        public async Task<IActionResult> GetObras(string ProyectoModulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var obras = await _dataContext.Obras
            .Include(p => p.ObrasDocumentos)
           .Where(o => (o.Finalizada == 0 && o.ULTIMAACTA == 0)
           && (o.Modulo == ProyectoModulo))
           .OrderBy(o => o.NroObra)
           .ToListAsync();
            if (obras == null)
            {
                return BadRequest("No hay Obras.");
            }
            return Ok(obras);
        }

        //-----------------------------------------------------------------------------------
        [HttpGet("{id}")]
        [Route("GetObra/{id}")]
        public async Task<ActionResult<Obra>> GetObra(int id)
        {
            Obra obra = await _dataContext.Obras
                .Include(x => x.ObrasDocumentos)
                .FirstOrDefaultAsync(x => x.NroObra == id);
            if (obra == null)
            {
                return NotFound();
            }
            return obra;
        }
    }
}