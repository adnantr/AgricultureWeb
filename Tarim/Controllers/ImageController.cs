using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Tarim.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        public IActionResult Index()
        {
           var values= _imageService.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddImage(Image image)
        {
            //ImageValidation validationRules=new ImageValidation();
            //ValidationResult result = validationRules.Validate(image);
            _imageService.Insert(image);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteImage(int id)
        {
            var result = _imageService.GetById(id);
            _imageService.Delete(result);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult UpdateImage(int id)
        {
            var result = _imageService.GetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateImage(Image image)
        {
            if (ModelState.IsValid)
            {
                _imageService.Update(image);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
