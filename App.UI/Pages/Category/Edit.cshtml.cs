
using App.Core.Managers;
using App.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Threading.Tasks;

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
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Category.PhotoFile != null)
            {
                string photopath = Directory.GetCurrentDirectory() + "/wwwroot/category-photos/";
                string photoname = Path.GetFileName(Category.PhotoFile.FileName);
                string finalpath = photopath + photoname;
                using (var stream = System.IO.File.Create(finalpath))
                {
                    await Category.PhotoFile.CopyToAsync(stream);
                }
                Category.Photo = photoname;
            }

            _CategoryManager.UpdateCategory(Category);
            return Redirect("/category/list");
        }


    }
}
