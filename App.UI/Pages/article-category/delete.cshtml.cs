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
    public class deleteModel : PageModel
    {
        private readonly ArticleCategoryManager _CategoryManager;
        [BindProperty]
        public ArticleCategory Category { get; set; }
        public deleteModel(ArticleCategoryManager categoryManager)
        {
            _CategoryManager = categoryManager;
        }
        public void OnGet(int Id)
        {
            Category = _CategoryManager.GetOne(Id);
        }
        public IActionResult OnPost()
        {

            _CategoryManager.DeleteCategory(Category.Id);
            return Redirect("/article-category/list");
        }

    }
}

