using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace tagi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var tagsData = new List<TagData>();
            for (int i = 1; i <= 10; i++) //the API does not allow queries larger than 100 in one batch
            {
               tagsData= tagsData.Concat(new TagDataDownloader(page: 1).Download()).ToList();
            }

            ViewData["tagsArray"] = tagsData;
            ViewData["allUses"] = tagsData.Sum(data => data.count);
            return View("Index");
        }

       
        
    }
}