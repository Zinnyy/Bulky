using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        { 
        
        if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display order cannot exactly match the name");
            }
            /* if (obj.Name != null && obj.Name.ToLower() == "test")
             {
                 ModelState.AddModelError("", "Name cannot contain test");
             } */
            if (ModelState.IsValid) { 
            _db.Categories.Add(obj);
            _db.SaveChanges();
                TempData["Success"] = "Category created successfully";
            return RedirectToAction("Index", "Category");
            }
            return View();
        }

        
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromdb = _db.Categories.Find(id);
            if(categoryFromdb == null)
            {
                return BadRequest();
            }


            return View(categoryFromdb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display order cannot exactly match the name");
            }
            
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromdb = _db.Categories.Find(id);
            if (categoryFromdb == null)
            {
                return BadRequest();
            }


            return View(categoryFromdb);
        }

        [HttpPost, ActionName ("Delete")]

        public IActionResult DeletePost(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
                _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["Success"] = "Category deleted successfully";
                return RedirectToAction("Index");
            
        }
    }

}

   

