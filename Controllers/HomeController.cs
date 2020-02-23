using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WordTransformation.Models;

namespace WordTransformation.Controllers
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

            return View();
        }

        public IActionResult WordTransformation()
        {

            var jsonString = System.IO.File.ReadAllText("wordTransformationSource.json");

            Regex regex = new Regex(@"<q id=\d{1,2}>");

            foreach (Match match in regex.Matches(jsonString))
            {
                string id = match.Value.Replace("<q id=", "").Replace(">", "");
                jsonString = jsonString.Replace($"<q id={id}>", $"<span class=\\\"nowrap\\\"><strong>{id}</strong> <input type=\\\"text\\\" id=\\\"q{id}\\\" size=\\\"10\\\" maxlength=\\\"50\\\"></span>");
            }



            var jsonModel = JsonSerializer.Deserialize<RootObject>(jsonString);
            var random = new Random();
            int randomNumberBetweenAvailableTexts= random.Next(0, jsonModel.CAE.Count);


            var chosenText = jsonModel.CAE[randomNumberBetweenAvailableTexts]; 
            return View(chosenText);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
