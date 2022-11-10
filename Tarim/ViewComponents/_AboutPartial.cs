using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Tarim.ViewComponents
{
	public class _AboutPartial : ViewComponent
    {
		private readonly IAboutService _aboutservice;

		public _AboutPartial(IAboutService aboutservice)
		{
            _aboutservice = aboutservice;
		}

		public IViewComponentResult Invoke()
		{
			var result = _aboutservice.GetListAll();
			return View(result);
		}
	}
}
