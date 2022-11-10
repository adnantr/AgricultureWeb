using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Tarim.ViewComponents
{
	public class _ServicePartial:ViewComponent
	{
		private readonly IServiceDal _serviceDal;

		public _ServicePartial(IServiceDal serviceDal)
		{
			_serviceDal = serviceDal;
		}

		public IViewComponentResult Invoke()
		{
			var value = _serviceDal.GetListAll();
			return View(value);
		}
	}
}
