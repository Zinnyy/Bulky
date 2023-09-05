using BulkyWeb_razor.Data;
using BulkyWeb_razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWeb_razor.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            if(id != null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }

           
        }
        public IActionResult OnPost(int? id)
        {
                Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
                
            }

                _db.Categories.Remove(obj);
                _db.SaveChanges();

            TempData["Success"] = "Category deleted successfully";
            return RedirectToPage("Index");

            
        }
    }
}



