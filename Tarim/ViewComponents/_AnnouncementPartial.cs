using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Tarim.ViewComponents
{
	public class _AnnouncementPartial : ViewComponent
	{
		private readonly IAnnouncementService _announcementService;

		public _AnnouncementPartial(IAnnouncementService announcementService)
		{
			_announcementService = announcementService;
		}

		public IViewComponentResult Invoke(int id)
		{
			var result = _announcementService.GetListAll();
			return View(result);
		}

	}
}
