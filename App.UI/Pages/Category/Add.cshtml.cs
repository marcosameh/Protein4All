using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Managers;
using App.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.UI.Pages.Category
{
    [Authorize(Roles ="Admin")]
    public class AddModel : PageModel
    {
        private readonly CategoryManager _CategoryManager;
        [BindProperty]
        public ProductCategory Category { get; set; }
        public AddModel(CategoryManager categoryManager)
        {
            _CategoryManager = categoryManager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            int _min = 100;
            int _max = 999;
            Random _rdm = new Random();
            int guid = _rdm.Next(_min, _max);
            string photopath = Directory.GetCurrentDirectory() + "/wwwroot/category-photos/";
            string photoname = guid + Path.GetFileName(Category.PhotoFile.FileName);
            string finalpath = photopath + photoname;
            using (var stream = System.IO.File.Create(finalpath))
            {
                await Category.PhotoFile.CopyToAsync(stream);
            }

            Category.Photo = photoname;
            _CategoryManager.AddCategory(Category);
            return Redirect("/category/list");
        }

    }
}
