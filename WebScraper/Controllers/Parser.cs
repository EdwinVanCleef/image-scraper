using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System;
using WebScraper.Models;

namespace WebScraper.Controllers
{
    public class Parser
    {
        public static async Task<string> CallUrl(string fullUrl)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(fullUrl);
            return response;
        }

        public static int ImageCount(string html)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var images = htmlDoc.DocumentNode.SelectNodes("//img");
            return images.Count;
        }

        public static List<ImageInfo> ParseHTML(string html)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var images = htmlDoc.DocumentNode.SelectNodes("//img");
            List<ImageInfo> imageList = new List<ImageInfo>();

            foreach (var item in images)
            {
                var imageInfo = new ImageInfo
                {
                    Url = item.OuterHtml.ToString(),
                    Size = 0
                };

                imageList.Add(imageInfo);
            }

            return imageList;
        }

        
    }
}
