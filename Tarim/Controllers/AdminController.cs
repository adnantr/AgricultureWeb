using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tarim.Controllers
{
    public class AdminController : Controller
	{
        private readonly IAdminService _adminService;

		public AdminController(IAdminService adminService)
		{
			_adminService = adminService;
		}

		public IActionResult Index()
		{
			var values=_adminService.GetListAll();
			return View(values);
		}

        public IActionResult DeleteAdmin(int id)
        {
            var result = _adminService.GetById(id);
            _adminService.Delete(result);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAdmin(Admin c)
        {
            _adminService.Insert(c);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateAdmin(int id)
        {
            var result = _adminService.GetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateContact(Admin c)
        {
            _adminService.Update(c);
            return RedirectToAction("Index");
        }
}
}
