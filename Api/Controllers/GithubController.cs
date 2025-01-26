using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Teste_Blip.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GithubController : ControllerBase
    {
        public HttpClient client { get; set; }

        const string urlGitHub = "https://api.github.com/search/repositories?q=takenet+in:name+language:csharp&order:asc";
        const string token = "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";

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
                client.DefaultRequestHeaders.Add("User-Agent", "brunovallin");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");
                HttpResponseMessage response = await client.GetAsync(urlGitHub);
                var json = JsonSerializer.Deserialize<GitHubRequest>(response.Content.ReadAsStream());

                IEnumerable<GithubInfos> items = (from githubitems in json.items
                                                orderby githubitems.created_at ascending
                                                select githubitems).Take(5);
                
                CarroselDinamico carrosel = new CarroselDinamico(items);

                return Ok(carrosel);
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possível conectar aos diretórios {ex.Message}");
            }   
        }
    }
}