//using AspNetCore;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Tarim.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var values = _contactService.GetListAll();
            return View(values);
        }
        public IActionResult DeleteContact(int id)
        {
            var result = _contactService.GetById(id);
            _contactService.Delete(result);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddContact()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult AddContact(Contact c)
        {
            _contactService.Insert(c);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
            var result = _contactService.GetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateContact(Contact c)
        {
            _contactService.Update(c);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var value=_contactService.GetById(id);
            return View(value);
        }
    }
}
