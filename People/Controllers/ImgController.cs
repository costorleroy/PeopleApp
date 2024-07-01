using Microsoft.AspNetCore.Mvc;
using People.Models;
namespace People.Controllers
{
    public class ImgController : Controller
    {
        //Images are stored here
        //private readonly string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//Images");

        private readonly IWebHostEnvironment _iweb;

        public ImgController(IWebHostEnvironment iweb)
        {
            _iweb = iweb;
        }


        public IActionResult Index()
        {
            ImageClass ic = new ImageClass();
            var displaying = Path.Combine(_iweb.WebRootPath, "Images");
            DirectoryInfo di = new DirectoryInfo(displaying);
            FileInfo[] fileInfo = di.GetFiles();
            ic.Fileimage = fileInfo;
            return View(ic);
        }


        [HttpPost]
        public async Task<IActionResult> Index(IFormFile imgfile)
        {
            //string ext = Path.GetExtension(imgfile.FileName.ToLower());
            string ext = Path.GetExtension(imgfile.FileName.ToLower());

            if (ext == ".jpg" || ext == ".JPG" || ext == ".gif" || ext == ".GIF" || ext == ".pmg" || ext == ".PMG")
            {
                //var imgsave=Path.Combine(_iweb.WebRootPath, imgfile.FileName);
                var imgsave = Path.Combine(_iweb.WebRootPath, "Images", imgfile.FileName);
                var stream = new FileStream(imgsave, FileMode.Create);
                await imgfile.CopyToAsync(stream);
                stream.Close();
            }
            return RedirectToAction("Index");
        }

        //public IActionResult Delete(string imgName)
        //{
        //    if (!string.IsNullOrEmpty(imgName))
        //    {
        //        var path = Path.Combine(rootPath, imgName);
        //        //var imgdel = Path.Combine(_iweb.WebRootPath, "Images", imgdel);
        //        if (System.IO.File.Exists(path))
        //        {
        //            System.IO.File.Delete(path);
        //        }
        //        return RedirectToAction(nameof(Index));
        //        //return RedirectToAction($"{nameof(DeleteImage)}");
        //    }
        //    return View();
        //}

        public IAsyncResult Delete(string imgdel)
        {
            imgdel = Path.Combine(_iweb.WebRootPath, "Images", imgdel);
            FileInfo fi = new FileInfo(imgdel);
            if (fi != null)
            {
                System.IO.File.Delete(imgdel);
                fi.Delete();
            }
            //return View("Index");
            return (IAsyncResult)RedirectToAction("Img");
            //return (IAsyncResult)RedirectToAction("Index");
        }
        
    }
}
