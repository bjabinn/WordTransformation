using System;
using System.Diagnostics;
using System.Text.Json;
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
