using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL.Interfaces;
using MyWebFormApp.BLL.DTOs;
namespace SampleMVC.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleBLL _articleBLL;
        public ArticleController(IArticleBLL articleBLL)
        {
            _articleBLL = articleBLL;
        }
            public IActionResult Index()
        {
            var models = _articleBLL.GetArticleWithCategory();
            return View(models);
        }

        public IActionResult Detail(int id)
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ArticleDTO article)
        {

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {

            return View();
        }

        [HttpPost]
        public IActionResult Edit(ArticleDTO article)
        {

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Search(string search)
        {

            return View("Index");

        }

        public IActionResult Delete(int id)
        {

            return RedirectToAction("Index");
        }


    }
}
