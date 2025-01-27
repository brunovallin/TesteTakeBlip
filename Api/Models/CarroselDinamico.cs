using System;
using Microsoft.AspNetCore.Http.Features;

namespace Api.Models;

public class CarroselDinamico
{
    public string itemType { get { return "application/vnd.lime.document-select+json"; } }
    public IEnumerable<Item> items { get; set; }

    public CarroselDinamico(IEnumerable<GithubInfos> infosGithub)
    {
        this.items = (from dados in infosGithub
                         select new Item()
                         {
                            header = new Header()
                            {
                                type = "application/vnd.lime.media-link+json",
                                value = new DadosCarossel()
                                {
                                    title = dados.name,
                                    text = dados.description,
                                    type = "image/png",
                                    uri = dados.owner.avatar_url
                                }
                            },
                            options = new List<Options>()
                         });
    }
}

public class Item
{
    public Header header { get; set; }
    public IEnumerable<Options> options { get; set; }
}

public class Options
{
}

public class Header
{
    public string type { get; set; }
    public DadosCarossel value { get; set; }
}

public class DadosCarossel
{
    public string title { get; set; }
    public string text { get; set; }
    public string type { get; set; }
    public string uri { get; set; }
}