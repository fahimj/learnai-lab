using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiLibrary;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebDemo.Controllers
{
    public class CustomVisionController : Controller
    {
        private readonly IHostingEnvironment _environment;

        // Constructor
        public CustomVisionController(IHostingEnvironment IHostingEnvironment)
        {
            _environment = IHostingEnvironment;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var response = await CustomVisionService.AnalyzeImage("wwwroot/demoImages/testImage.jpg");
            return View(response);
        }

        [HttpPost]
        public IActionResult UploadImage(List<IFormFile> files)
        {
            //long size = files.Sum(f => f.Length);

            // full path to file in temp location
            //var filePath = Path.GetTempFileName();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {

                    //Getting FileName
                    var fileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');

                    //Assigning Unique Filename (Guid)
                    var myUniqueFileName = "testImage"; //Convert.ToString(Guid.NewGuid());

                    //Getting file Extension
                    var FileExtension = Path.GetExtension(fileName);

                    // concating  FileName + FileExtension
                    var newFileName = myUniqueFileName + FileExtension;

                    // Combines two strings into a path.
                    fileName = Path.Combine(_environment.WebRootPath, "demoImages") + $@"/{newFileName}";

                    // if you want to store path of folder in database
                    var PathDB = "demoImages/" + newFileName;

                    using (FileStream fs = System.IO.File.Create(fileName))
                    {
                        formFile.CopyTo(fs);
                        fs.Flush();
                    }
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
            //return View("Index");
            return RedirectToAction("Index");
            //return Ok(new { tes = 22 });
        }

    }
}
