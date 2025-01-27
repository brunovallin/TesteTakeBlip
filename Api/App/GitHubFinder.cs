using System;
using System.Net.Http.Headers;
using System.Text.Json;
using Api.Models;

namespace Api.App;

public class GitHubFinder
{
    public HttpClient client { get; set; }

    public async Task<GitHubRequest> BuscarInfos(string url, string tokenGithub)
    {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
            client.DefaultRequestHeaders.Add("User-Agent", "brunovallin");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{tokenGithub}");
            HttpResponseMessage response = await client.GetAsync(url);
            var json = JsonSerializer.Deserialize<GitHubRequest>(response.Content.ReadAsStream());
            
            return json;
    }
}