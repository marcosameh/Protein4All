using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Managers;
using App.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.UI.Pages.article_category
{
    [Authorize(Roles = "Admin")]
    public class addModel : PageModel
    {
       
        private readonly ArticleCategoryManager _CategoryManager;
        [BindProperty]
        public ArticleCategory Category { get; set; }
        public addModel(ArticleCategoryManager categoryManager)
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
            return Redirect("/article-category/list");
        }
    }
}
