using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Tarim.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            var values = _teamService.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTeam(Team team)
        {
            _teamService.Insert(team);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteTeam(int id)
        {
            var result = _teamService.GetById(id);
            _teamService.Delete(result);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult UpdateTeam(int id)
        {
            var result = _teamService.GetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateTeam(Team team)
        {
            if (ModelState.IsValid)
            {
                _teamService.Update(team);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
