using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.IServices;
using Backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosAdicionalesController : ControllerBase
    {
        private readonly IDatosAdicionalesService _datosAdicionalesService;

        public DatosAdicionalesController(IDatosAdicionalesService datosAdicionalesService)
        {
            _datosAdicionalesService = datosAdicionalesService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{clienteId}")]
        public async Task<IActionResult> Get(int clienteId)
        {
            try
            {
                var datosAdicionales = await _datosAdicionalesService.GetDatosByClientId(clienteId);

                return Ok(datosAdicionales);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

