using InventoryControl.Application.Ventas.Agregar;
using InventoryControl.Application.Ventas.Consultar;
using InventoryControl.Domain.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryControl.Api.Controllers
{
    [Route("api/venta")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthenticationService _authenticationService;
        public VentaController(IUnitOfWork unitOfWork, IAuthenticationService authenticationService)
        {
            _unitOfWork = unitOfWork;
            _authenticationService = authenticationService;
        }

        [Authorize]
        [HttpPost("agregar")]
        public async Task<ActionResult> Agregar(AgregarRequest Request)
        {
            var respuesta = await new AgregarCommand(_unitOfWork, _authenticationService).Handle(Request);
            if (respuesta.HuboError)
                return BadRequest(respuesta);
            return Ok(respuesta);
        }
        [Authorize]
        [HttpPost("consultar")]
        public async Task<ActionResult> Consultar()
        {
            var respuesta = await new ConsultarQuery(_unitOfWork, _authenticationService).Handle();
            if (respuesta.HuboError)
                return BadRequest(respuesta);
            return Ok(respuesta);
        }
    }
}
