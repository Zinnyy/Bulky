using BulkyWeb_razor.Data;
using BulkyWeb_razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWeb_razor.Pages.Categories
{
        [BindProperties]
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;
       
        public Category Category { get; set; }
            public CreateModel(ApplicationDbContext db)
            {
                _db = db;
            }
            public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _db.Categories.Add(Category);
            _db.SaveChanges();
            TempData["Success"] = "Categorate created successfully";
            return RedirectToPage("Index");

        }
    }
}
