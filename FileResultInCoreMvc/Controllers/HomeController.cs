using FileResultInCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mime;

namespace FileResultInCoreMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public FileResult Index()
        {
            //Get the file path
            string filePath = Directory.GetCurrentDirectory() + "\\wwwroot\\PDFDocuments\\Test.pdf";

            //Convert to byte array
            byte[] fileBytes=System.IO.File.ReadAllBytes(filePath);

            //Setting File Download Options
            var contentDisposition = new ContentDisposition
            {
                FileName="Test.pdf",
                Inline= false // Set to true if you want to display the file in the browser
            };

            Response.Headers.Add("Content-Disposition", contentDisposition.ToString());

            //Return the byte array
            //return File(fileBytes, "application/pdf", "Test.pdf");

            //Returning a PDF for Display
            //return File(fileBytes, "application/pdf");

            //Return the Physical File
            return PhysicalFile(filePath, "application/pdf");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}