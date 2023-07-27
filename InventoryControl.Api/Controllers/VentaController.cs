using InventoryControl.Application.Ventas.RealizarVenta;
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
        public async Task<ActionResult> agregar(RealizarVentaRequest Request)
        {
            var respuesta = await new RealizarVentaCommand(_unitOfWork, _authenticationService).Handle(Request);
            if (respuesta.HuboError)
                return BadRequest(respuesta);
            return Ok(respuesta);
        }
    }
}
