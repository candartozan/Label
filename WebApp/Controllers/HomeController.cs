using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static string[] sRows;
        private string sourcePath = "C:\\Users\\Candar\\Desktop\\source.csv";
        private string destinationPath = "C:\\Users\\Candar\\Desktop\\destination.csv";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //GetSource();
        }

        public IActionResult Index()
        {
            try
            {
                var value = sRows[0].Split(",");
                var model = new Label { Number = value[0], Department = value[5], Project = value[6] };
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Save(Label value)
        {
            System.IO.File.AppendAllText(destinationPath, value.ToString() + Environment.NewLine);
            sRows = sRows.Skip(1).ToArray();
            return RedirectToAction("Index");
        }

        public IActionResult Pass()
        {
            sRows = sRows.Skip(1).ToArray();
            return RedirectToAction("Index");
        }

        public IActionResult GetSource()
        {
            GetSource(0);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void GetSource(int number)
        {
            var destination = System.IO.File.ReadAllLines(destinationPath);
            var lastNumber = destination.LastOrDefault()?.Split(',')[0];

            sRows = System.IO.File
                .ReadAllLines(sourcePath)
            .Where(x =>
            {
                int number = int.Parse(lastNumber);
                string sNumber = x.Split(',')[0];

                try
                {
                    if (int.Parse(sNumber) > number)
                    {
                        return true;
                    }
                    return false;
                }
                catch
                {
                    return false;
                }

            })
            .ToArray();
        }
    }
}