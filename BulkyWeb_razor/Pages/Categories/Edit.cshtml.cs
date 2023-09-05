using BulkyWeb_razor.Data;
using BulkyWeb_razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWeb_razor.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int? id)
        {
         
            if(id != null && id != 0)
            {
                Category? categoryFromdb  = _db.Categories.Find(id);
            }
               

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {

            _db.Categories.Update(Category);
            _db.SaveChanges();
            return RedirectToPage("Index");
            }
            return Page();
        }
      
    }
}