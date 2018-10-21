using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment _env;
        public HomeController(IHostingEnvironment env)
        {
            _env = env;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
        
        public string Get(int pointX, int pointY)
        {
            var path = _env.WebRootPath;
            Bitmap img = new Bitmap(Path.Combine(path,  "MOLA.png"));
            Color pixel = img.GetPixel(pointX, pointY);
            img.Dispose();
            if (pixel.R == pixel.G && pixel.G == pixel.B && pixel.R == 255)
            {
                return "https://sketchfab.com/models/fdc477133bd4490cbc9d81ed4e72f19e/embed?autostart=1";
            }
            else if (pixel.R == pixel.G && pixel.G == pixel.B && pixel.R == 0)
            {
                return "https://sketchfab.com/models/de4cf7d2962a4516b9c939ad71ee3900/embed?camera=0;autostart=1";
            }
            else if (pixel.R == pixel.G && pixel.G == pixel.B && pixel.R == 150)
            {
                return "https://sketchfab.com/models/0afc60acadbd4cabbd397e6fccbb7b12/embed?camera=0;autostart=1";
            }
            else if (pixel.R == pixel.G && pixel.G == pixel.B && pixel.R == 42)
            {
                return "https://sketchfab.com/models/575c8b51e6414c7fbdf5bb7f7836d85d/embed?autostart=1";
            }
            else if (pixel.R == 237 && pixel.G == 28 && pixel.R == 36)
            {
                return "https://sketchfab.com/models/4c4e1b5ac8b44c658da5229bab7b2845/embed?camera=0;autostart=1";
            }
            else
            {
                return "https://sketchfab.com/models/08aa501e044f44cda18f2625613f6d65/embed?autostart=1";
            }
        }
    }
}