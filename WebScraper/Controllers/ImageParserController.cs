using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebScraper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageParserController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult GetImageCount()
        {
            string url = "https://onfido.com/";
            var response = Parser.CallUrl(url).Result;
            return Ok(Parser.ImageCount(response));
        }

        [HttpGet]
        public IActionResult Get()
        {
            string url = "https://onfido.com/";
            var response = Parser.CallUrl(url).Result;
            var imgList = Parser.ParseHTML(response);
            return Ok(imgList);
        }
    }
}