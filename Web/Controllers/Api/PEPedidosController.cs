using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [Route("GetPEPedidos")]
        public async Task<IActionResult> GetPEPedidos()
        {
          
            var compras = await _dataContext2.PEPedidos
            
           .Where(o => o.Estado.ToLower() == "controlvsa")
           .OrderBy(o => o.NroPedidoObra)
           .ToListAsync();
            if (compras == null)
            {
                return BadRequest("No hay Compras.");
            }
            return Ok(compras);
        }

       
    }
}