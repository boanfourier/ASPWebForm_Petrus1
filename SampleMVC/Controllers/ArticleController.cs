using Microsoft.AspNetCore.Mvc;
using MyWebFormApp.BLL.Interfaces;
using MyWebFormApp.BLL.DTOs;
using MyWebFormApp.BLL;
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
            var model = _articleBLL.GetArticleWithCategory();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ArticleCreateDTO articleCreate)
        {
            try
            {
                _articleBLL.Insert(articleCreate);
                //ViewData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Add Data Category Success !</div>";
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Add Data Category Success !</div>";
            }
            catch (Exception ex)
            {
                //ViewData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
                TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var model = _articleBLL.GetArticleById(id);

            if (model == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Article Not Found !</div>";
                return RedirectToAction("Index");
            }

            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(int id, ArticleUpdateDTO articleEdit)
        {
            try
            {
                _articleBLL.Update(articleEdit);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Edit Data Category Success !</div>";
            }
            catch (Exception ex)
            {
                ViewData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
                return View(articleEdit);
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Search(string search)
        {

            return View("Index");

        }
        public IActionResult Delete(int id)
        {
            var model = _articleBLL.GetArticleWithCategory();
            if (model == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Category Not Found !</div>";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id, ArticleDTO article)
        {
            try
            {
                _articleBLL.Delete(id);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Delete Data Category Success !</div>";
            }
            catch (Exception ex)
            {
                TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
                return View(article);
            }
            return RedirectToAction("Index");
        }


        public IActionResult DisplayDropdownList()
        {
            var categories = _articleBLL.GetArticleWithCategory();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public IActionResult DisplayDropdownList(string ArticleID)
        {
            ViewBag.CategoryID = ArticleID;
            ViewBag.Message = $"You selected {ArticleID}";

            ViewBag.Categories = _articleBLL.GetArticleWithCategory();

            return View();
        }


    }
}
