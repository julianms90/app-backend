﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Backend.Domain.IServices;
using Backend.Domain.Models;
using Backend.DTO;
using Backend.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            try
            {
                var validateExistance = await _usuarioService.ValidateExistence(usuario);
                if (validateExistance)
                    return BadRequest(new { message = "El usuario " + usuario.NombreUsuario + " ya existe" });

                usuario.Password = Encriptar.EncriptarPassword(usuario.Password);
                await _usuarioService.SaveUser(usuario);
                return Ok(new { message = "Usuario registrado con exito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("CambiarPassword")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<IActionResult> CambiarPassword(CambiarPasswordDTO cambiarPassword)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;

                int usuarioId = JwtConfigurator.GetTokenIdUsuario(identity);
                string passwordEncriptado = Encriptar.EncriptarPassword(cambiarPassword.passwordAnterior);
                var usuario = await _usuarioService.ValidatePassword(usuarioId, passwordEncriptado);

                if (usuario == null) return BadRequest(new { message = "La contraseña es incorrecta" });

                usuario.Password = Encriptar.EncriptarPassword(cambiarPassword.passwordNuevo);
                await _usuarioService.UpdatePassword(usuario);
                return Ok(new { message = "La contraseña fue actualizada con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
