using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Common.Helpers;
using Web.Data;
using Common.Models.Request;
using Web.Data.Entities;

namespace Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ObrasDocumentsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IFilesHelper _filesHelper;

        public ObrasDocumentsController(DataContext context, IFilesHelper filesHelper)
        {
            _context = context;
            _filesHelper = filesHelper;
        }

        //-------------------------------------------------------------------------------------
        [HttpPost]
        [Route("ObrasDocument")]
        public async Task<IActionResult> PostObrasDocument([FromBody] ObrasDocumentoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Foto
            var imageUrl1 = string.Empty;
            var stream = new MemoryStream(request.ImageArray);
            var guid = Guid.NewGuid().ToString();
            var file = $"{guid}.jpg";
            var folder = "wwwroot\\images\\Obras";
            var fullPath = $"~/images/Obras/{file}";
            var response = _filesHelper.UploadPhoto(stream, folder, file);

            if (response)
            {
                imageUrl1 = fullPath;
            }

            //Obra obra = await _context.Obras
            //    .FirstOrDefaultAsync(o => o.NroObra == request.NROOBRA);

            var obraDocumento = new ObrasDocumento
            {
                NROOBRA = request.NROOBRA,
                LINK = imageUrl1,
                FECHA = request.FECHA,
                IDObrasPostes = request.IDObrasPostes,
                OBSERVACION = request.OBSERVACION,
                Estante = request.Estante,
                GeneradoPor = request.GeneradoPor,
                MODULO = request.MODULO,
                NroLote = request.NroLote,
                Sector = request.Sector,
                Latitud = request.Latitud,
                Longitud = request.Longitud,
                FechaHsFoto = request.FechaHsFoto,
                TipoDeFoto = request.TipoDeFoto,
                DireccionFoto = request.DireccionFoto
            };

            _context.ObrasDocumentos.Add(obraDocumento);
            await _context.SaveChangesAsync();

            return Ok(obraDocumento);
        }

        //-------------------------------------------------------------------------------------
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObrasDocumento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var ObrasDocumento = await _context.ObrasDocumentos
                .FirstOrDefaultAsync(p => p.NROREGISTRO == id);
            if (ObrasDocumento == null)
            {
                return this.NotFound();
            }

            _context.ObrasDocumentos.Remove(ObrasDocumento);
            await _context.SaveChangesAsync();
            return Ok("ObrasDocumento borrado");
        }
    }
}

