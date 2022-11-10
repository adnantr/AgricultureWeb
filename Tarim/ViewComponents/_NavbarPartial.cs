using Microsoft.AspNetCore.Mvc;

namespace Tarim.ViewComponents
{
	public class _NavbarPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
