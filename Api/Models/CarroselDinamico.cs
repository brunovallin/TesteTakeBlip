using System;
using Microsoft.AspNetCore.Http.Features;

namespace Api.Models;

public class CarroselDinamico
{
    public string itemType { get { return "application/vnd.lime.document-select+json";}}
    public IEnumerable<Item> items { get; set; }

    public CarroselDinamico(IEnumerable<GithubInfos> infosGithub)
    {
        items = new List<Item>();

        items = (from dados in infosGithub
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
                    }

                 });

        // foreach(GithubInfos info in infosGithub)
        // {
        //     items.Append(new Item()
        //     {
        //         header = new Header()
        //         {
        //             type = "application/vnd.lime.media-link+json",
        //             value = new DadosCarossel()
        //             {
        //                 title = info.name,
        //                 text = info.description,
        //                 type = "image/png",
        //                 uri = info.owner.avatar_url
        //             }
        //         }
        //     });
        // }
    }
}

public class Item
{
    public Header header { get; set; }
    public Option option{ get; set; }
}

public class Header
{
    public string type { get; set; }
    public DadosCarossel value { get; set; }
}

public class Option
{
    
}

public class DadosCarossel
{
    public string title { get; set; }
    public string text { get; set; }
    public string type { get; set; }
    public string uri { get; set; }
}