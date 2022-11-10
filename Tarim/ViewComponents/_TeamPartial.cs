using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Tarim.ViewComponents
{
	public class _TeamPartial:ViewComponent
	{

		private readonly ITeamService _teamService;

		public _TeamPartial(ITeamService teamService)
		{
			this._teamService = teamService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _teamService.GetListAll();
			return View(values);
		}
	}
}
