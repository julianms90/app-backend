using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Backend.Domain.IServices;
using Backend.Domain.Models;
using Backend.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            try
            {
                var validateExistance = await _clienteService.ValidateExistence(cliente);
                if (validateExistance)
                    return BadRequest(new { message = "El cliente " + cliente.NombreCompleto + " ya existe" });

                await _clienteService.AddClient(cliente);
                return Ok(new { message = "Cliente registrado con exito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("GetListClientes")]
        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            try
            {
                var listCliente = await _clienteService.GetClients();
                return Ok(listCliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{idCliente}")]
        public async Task<IActionResult> Get(int idCliente)
        {
            try
            {
                var cliente = await _clienteService.GetClientById(idCliente);

                return cliente == null
                    ? Ok(new { message = "El cliente no existe" })
                    : Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{idCliente}")]
        public async Task<IActionResult> Delete(int idCliente)
        {
            try
            {
                await _clienteService.DeleteClient(idCliente);

                return Ok(new { message = "El cliente fue eliminado con exito" }); }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Cliente cliente)
        {
            try
            {
                var validateExistance = await _clienteService.ValidateExistence(cliente);
                if (validateExistance)
                    return BadRequest(new { message = "Ya existe un cliente con el nombre " + cliente.NombreCompleto});

                await _clienteService.UpdateClient(cliente);

                return Ok(new { message = "El cliente modificado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[Route("getClientFileter")]

        //[HttpGet("{nombreCliente}")]
        //public async Task<IActionResult> GetClientFilter(string nombreCliente)
        //{
        //    try
        //    {
        //        var clientes = await _clienteService.GetClientFilter(nombreCliente);

        //        return clientes.Count == 0
        //            ? Ok(new { message = "No hay clientes para mostrar" })
        //            : Ok(clientes);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}


    }
}
