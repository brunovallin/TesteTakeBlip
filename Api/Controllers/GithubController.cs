using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Api.App;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Teste_Blip.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GithubController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                CarroselBuilder builder = new CarroselBuilder();
                return Ok(builder.ConstruirNovoCarrosel());
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível conectar aos diretórios.");
            }   
        }
    }
}