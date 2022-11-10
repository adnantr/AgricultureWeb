using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class AdminManager : IAdminService
    {
		private readonly IAdminDal _adminDal;

		public AdminManager(IAdminDal adminDal)
		{
			_adminDal = adminDal;
		}

		void IGenericService<Admin>.Delete(Admin t)
		{
			_adminDal.Delete(t);
		}

		Admin IGenericService<Admin>.GetById(int id)
		{
			var result=_adminDal.GetById(id);
			return result;
		}

		List<Admin> IGenericService<Admin>.GetListAll()
		{
			return _adminDal.GetListAll();
		}

		void IGenericService<Admin>.Insert(Admin t)
		{
			_adminDal.Insert(t);
		}

		void IGenericService<Admin>.Update(Admin t)
		{
			_adminDal.Update(t);
		}
	}
}
