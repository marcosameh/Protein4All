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
    public class listModel : PageModel
    {
        private readonly ArticleCategoryManager _CategoryManager;

        public IQueryable<ArticleCategory> Categories { get; set; }
        public listModel(ArticleCategoryManager categoryManager)
        {
            _CategoryManager = categoryManager;
        }
        public void OnGet()
        {
            Categories = _CategoryManager.GetAllCategories();
        }
    }
}
