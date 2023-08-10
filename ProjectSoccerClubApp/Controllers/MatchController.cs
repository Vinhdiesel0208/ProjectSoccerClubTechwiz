using Microsoft.AspNetCore.Mvc;
using ProjectModels;
using ProjectSoccerClubApp.Repositories;

namespace ProjectSoccerClubApp.Controllers
{
    public class MatchController : Controller
    {
        private IMatchService service;
        public MatchController(IMatchService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            var models = await service.GetMatchList();
            return View(models);
        }
        public IActionResult Details(Match match) {
            var models = service.GetMatchById(match.Id);
            return View(models);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Match newMatch) {
            try
            {
                if (ModelState.IsValid)
                { 
                    service.addMatch(newMatch);
                    return RedirectToAction("Index", "Match");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(String.Empty, ex.Message);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var match = service.GetMatchById(id);
            if (match != null)
            {
                service.removeMatch(id);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var match = service.GetMatchById(id);
            return View(match);
        }
        [HttpPost]
        public IActionResult Update(Match editMatch) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.updateMatch(editMatch);
                    return RedirectToAction("Index", "Match");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(String.Empty, ex.Message);
            }
            return View();
        }
    }
}
