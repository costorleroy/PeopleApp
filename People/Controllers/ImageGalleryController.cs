using Microsoft.AspNetCore.Mvc;

namespace People.Controllers
{
    public class ImageGalleryController : Controller
    {
        //Images are stored here
        private readonly string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//Images");

        public IActionResult Index()
        {
            //Create Directory
            bool dirExists = Directory.Exists(rootPath);

            if (!dirExists)
                Directory.CreateDirectory(rootPath);

            List<string?> imageNames = Directory.GetFiles(rootPath).Select(Path.GetFileName).ToList();

            return View(imageNames);
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            if (file != null)
            {
                //Get File Name - new file name
                var path = Path.Combine(rootPath, Guid.NewGuid() + Path.GetExtension(file.FileName));

                // upload file to directory
                using (var fs = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }

                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index");
            }

            return View();     //else //{  }
        }

        public async Task<IActionResult> DownloadImage(string imgName)
        {
            if (!string.IsNullOrEmpty(imgName))
            {
                var path = Path.Combine(rootPath, imgName);
                var memory = new MemoryStream();
                using (var fs = new FileStream(path, FileMode.Open))
                {
                    await fs.CopyToAsync(memory);
                }
                memory.Position = 0;
                var contentType = "application/octet-stream";
                var fileName = Path.GetFileName(path);
                return File(memory, contentType, fileName);
            }
            return View();
        }

        //public async Task<IActionResult> DeleteImage(string imgName)
        public IActionResult DeleteImage(string imgName)
        {
            if (!string.IsNullOrEmpty(imgName))
            {
                var path = Path.Combine(rootPath, imgName);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                return RedirectToAction(nameof(Index));
                //return RedirectToAction($"{nameof(DeleteImage)}");
            }
            return View();
        }
    }
}
