
using App.Core.Managers;
using App.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.UI.Pages.Category
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private CategoryManager _CategoryManager { get; }

        [BindProperty]
        public ProductCategory Category { get; set; }
        public EditModel(CategoryManager categoryManager)
        {
            _CategoryManager = categoryManager;
        }

        public void OnGet(int Id)
        {
            Category = _CategoryManager.GetOne(Id);
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _CategoryManager.UpdateCategory(Category);
            return Redirect("/category/list");
        }


    }
}
