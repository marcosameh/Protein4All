using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Managers;
using App.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.UI.Pages.article
{
    [Authorize(Roles="Admin")]
    public class listModel : PageModel
    {
        private readonly ArticleManager _ArticalManager;
        private readonly ArticleCategoryManager articleCategoryManager;

        public SelectList CategoryList { get; set; }
        public IEnumerable<ArticleCategory> Categories { get; set; }
        public IQueryable<Articals> Articals { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }
        public listModel(ArticleManager ArticalManager ,ArticleCategoryManager articleCategoryManager)
        {
            _ArticalManager = ArticalManager;
            this.articleCategoryManager = articleCategoryManager;
        }
        public IActionResult OnGet(int?Id)
        {
            this.Id = Id;
            if (Id == null)
            {
                Categories = articleCategoryManager.GetAllCategories();
                CategoryList = new SelectList(Categories, "Id", "Name");
                Articals = _ArticalManager.GetAllArtical();
                return Page();
            }
            Categories = articleCategoryManager.GetAllCategories();
            CategoryList = new SelectList(Categories, "Id", "Name");
            Articals = _ArticalManager.GetArticals(Id);
            return Page();


        }

    }
}
