using System;
using System.Collections.Generic;
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
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _CategoryManager.AddCategory(Category);
            return Redirect("/category/list");
        }

    }
}
