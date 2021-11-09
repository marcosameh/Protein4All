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
    public class editModel : PageModel
    {
        private ArticleCategoryManager _CategoryManager { get; }

        [BindProperty]
        public ArticleCategory Category { get; set; }
        public editModel(ArticleCategoryManager categoryManager)
        {
            _CategoryManager = categoryManager;
        }

        public void OnGet(int Id)
        {
            Category = _CategoryManager.GetOne(Id);
        }
        public  IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
       
           

            _CategoryManager.UpdateCategory(Category);
            return Redirect("/article-category/list");
        }
    }
}
