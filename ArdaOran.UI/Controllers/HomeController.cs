using ArdaOran.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArdaOran.UI.Controllers
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

        public IActionResult Indir()
        {
            string dosyaYolu = "C:\\Users\\ardao\\Desktop\\ardaorancom\\ArdaOran.UI\\wwwroot\\CV_ArdaOran.pdf";

            
            string dosyaAdi = System.IO.Path.GetFileName(dosyaYolu);

          
            var memoryStream = new MemoryStream();
            using (var stream = new FileStream(dosyaYolu, FileMode.Open))
            {
                stream.CopyTo(memoryStream);
            }
            memoryStream.Position = 0;

            return File(memoryStream, "application/octet-stream", dosyaAdi);
        }

    }
}