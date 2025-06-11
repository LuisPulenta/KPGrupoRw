using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Web.Data;

namespace Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PEPedidosController : ControllerBase
    {
        private readonly DataContext2 _dataContext2;
        

        public PEPedidosController(DataContext2 dataContext2)
        {
            _dataContext2 = dataContext2;
        }

        //-----------------------------------------------------------------------------------
        [HttpPost]
        [Route("GetPEPedidos/{idUsuario}")]
        
        public async Task<IActionResult> GetPEPedidos([FromRoute] int idUsuario)
        
        {
          
            var compras = await _dataContext2.VistaPEPedidosFirmasPendientes
            
           .Where(o => o.IDUSUARIO==idUsuario)
           .OrderBy(o => o.NroPedidoObra)
           .ToListAsync();
            if (compras == null)
            {
                return BadRequest("No hay Compras.");
            }
            return Ok(compras);
        }

        //-------------------------------------------------------------------------------------
        [HttpPut]
        [Route("PutPedidosFirma/{id}")]
        public async Task<IActionResult> PutPedidosFirma([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oldPedidosFirma = await _dataContext2.PEPedidosFirmas.FindAsync(id);
            if (oldPedidosFirma == null)
            {
                return BadRequest("El PedidoFirma no existe.");
            }

            oldPedidosFirma.FECHA = DateTime.Now;
            oldPedidosFirma.HS = DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
            oldPedidosFirma.MEDIOFIRMA = "App";

            _dataContext2.PEPedidosFirmas.Update(oldPedidosFirma);
            await _dataContext2.SaveChangesAsync();
            return Ok();
        }
    }
}