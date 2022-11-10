using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Tarim.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IActionResult Index()
        {
            var values = _addressService.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddAddress()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAddress(Address t)
        {
            _addressService.Insert(t);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAddress(int id)
        {
            var values = _addressService.GetById(id);
            _addressService.Delete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateAddress(int id)
        {
            var values=_addressService.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateAddress(Address t)
        {
            _addressService.Update(t);
            return RedirectToAction("Index");
        }
    }
}
