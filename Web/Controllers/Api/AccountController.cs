using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Web.Data;
using Common.Models.Request;
using Common.Models.Responses;
using Web.Data.Entities;

namespace Web.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _dataContext;
        private readonly DataContext2 _dataContext2;


        public AccountController(DataContext dataContext, DataContext2 dataContext2)
        {
            _dataContext = dataContext;
            _dataContext2 = dataContext2;
        }

        //-----------------------------------------------------------------------------------
        [HttpPost]
        [Route("GetUserByEmail")]
        public async Task<IActionResult> GetUser(UsuarioRequest userRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _dataContext.Usuarios.FirstOrDefaultAsync(o => o.Login.ToLower() == userRequest.Email.ToLower());

            var userInv = await _dataContext2.Usuarios.FirstOrDefaultAsync(o => o.IdUsuario == user.IDUsuario);

            var usuarioResponse = new UsuarioResponse
            {
                IDUsuario = user.IDUsuario,
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Login = user.Login,
                Estado = user.Estado,
                Contrasena = user.Contrasena,
                HabilitaAPP = user.HabilitaAPP,
                HabilitaFotos = user.HabilitaFotos,
                Modulo = user.Modulo,
                CodigoCausante = user.CodigoCausante,
                EstadoInv=userInv.Estado,
                Compras=userInv.Compras,
            };

            return Ok(usuarioResponse);
        }
    }
}