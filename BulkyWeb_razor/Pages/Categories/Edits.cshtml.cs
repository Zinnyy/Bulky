using BulkyWeb_razor.Data;
using BulkyWeb_razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWeb_razor.Pages.Categories
{
    [BindProperties]
    public class EditsModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }
        public EditsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet(int? id)
        {
               Category = _db.Categories.Find(id);
            if (id == null || id == 0)
            {
                return NotFound();
            }
                
            return Page();

        }

        /*public IActionResult OnGet(int id)
        {
            var category = _db.Categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            Category = category;

            return Page();
        }*/

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {

                _db.Categories.Update(Category);
                _db.SaveChanges();
            }

            TempData["Success"] = "Category updated successfully";
                return RedirectToPage("Index");
        }
    }
}


    

