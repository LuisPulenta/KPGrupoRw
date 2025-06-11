using Common.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Web.Data;
using Web.Data.Entities;

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

        //-----------------------------------------------------------------------------------
        [HttpPost]
        [Route("GetPEPedidosByNroPedido/{nroPedido}")]

        public async Task<IActionResult> GetPEPedidosByNroPedido([FromRoute] int nroPedido)

        {
            var compras = await _dataContext2.VistaPEPedidosFirmasPendientes

           .Where(o => o.NroPedido == nroPedido)
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
        public async Task<IActionResult> PutPedidosFirma([FromRoute] int id, [FromBody] PedidosFirmaRequest request)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oldPedidosFirma = await _dataContext2.PEPedidosFirmas.FindAsync(request.IDFIRMA);
            if (oldPedidosFirma == null)
            {
                return BadRequest("El PedidoFirma no existe.");
            }

            string hora = DateTime.Now.Hour.ToString();
            string minutos = DateTime.Now.Minute.ToString();
            string segundos = DateTime.Now.Second.ToString();
            if(hora.Length==1)
            {
                hora = "0" + hora;
            }
            if (minutos.Length == 1)
            {
                minutos = "0" + minutos;
            }
            if (segundos.Length == 1)
            {
                segundos = "0" + segundos;
            }

            oldPedidosFirma.FECHA = DateTime.Now;
            oldPedidosFirma.HSTexto = hora + minutos + segundos;
            oldPedidosFirma.MEDIOFIRMA = "App";

            _dataContext2.PEPedidosFirmas.Update(oldPedidosFirma);
            await _dataContext2.SaveChangesAsync();
            return Ok();
        }

        //-------------------------------------------------------------------------------------

        [HttpPut]
        [Route("PutPEPPedido/{id}")]
        public async Task<IActionResult> PutPEPPedidosEstado([FromRoute] int id, [FromBody] PedidoRequest request)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oldPEPedido = await _dataContext2.PEPedidos.FindAsync(request.NroPedido);
            if (oldPEPedido == null)
            {
                return BadRequest("El Pedido no existe.");
            }

            oldPEPedido.Estado = "OCAprobada";
            oldPEPedido.FechaFirma3 = DateTime.Now;

            _dataContext2.PEPedidos.Update(oldPEPedido);
            await _dataContext2.SaveChangesAsync();
            return Ok();
        }
    }
}