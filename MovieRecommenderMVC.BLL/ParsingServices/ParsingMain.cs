using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using MovieRecommenderMVC.BLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieRecommenderMVC.BLL.ParsingServices
{
    public class ParsingMain
    {
        //public async Task<List<HtmlNode>> ParseMain()
        //{
        //    var httpClient = new HttpClient();
        //    var html = await httpClient.GetStringAsync(Urls.HABR);

        //    var htmlDocument = new HtmlDocument();
        //    htmlDocument.LoadHtml(html);

        //    var newsList = htmlDocument.DocumentNode.Descendants("ul")
        //        .Where(node => node.GetAttributeValue("class", "").Contains("content-list_posts"))
        //        .ToList();

        //    return new Task<List<HtmlNode>>(newsList);
        //}
    }
}
