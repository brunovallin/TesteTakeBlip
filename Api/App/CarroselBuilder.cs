using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Api.Models;

namespace Api.App
{

    public class CarroselBuilder
    {
        const string urlGitHub = "https://api.github.com/search/repositories?q=takenet+in:name+language:csharp&order:asc";

        public CarroselDinamico ConstruirNovoCarrosel()
        {
            var gitHubFinder = new GitHubFinder();
            var json = gitHubFinder.BuscarInfos(urlGitHub);

            if(json is null) throw new Exception();
            
            IEnumerable<GithubInfos> items = (from githubitems in json.Result.items
                                              orderby githubitems.created_at ascending
                                              select githubitems).Take(5);
            
            CarroselDinamico novo = new CarroselDinamico(items);
            return novo;
        }
    }
}