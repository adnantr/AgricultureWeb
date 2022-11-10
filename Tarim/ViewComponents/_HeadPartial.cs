

using Microsoft.AspNetCore.Mvc;

namespace Tarim.ViewComponents
{ 
	public class _HeadPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
