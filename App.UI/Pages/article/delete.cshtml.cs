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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.UI.Pages.article
{
    [Authorize(Roles ="Admin")]
    public class deleteModel : PageModel
    {
        private readonly ArticleManager _ArticleManager;
        private readonly ArticleCategoryManager articleCategoryManager;

        [BindProperty]

        public Articals article { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public IEnumerable<ArticleCategory> Categories { get; set; }
        public SelectList CategoryList { get; set; }

        public deleteModel(ArticleManager ArticleManager,ArticleCategoryManager articleCategoryManager)
        {

            _ArticleManager = ArticleManager;
            this.articleCategoryManager = articleCategoryManager;
        }
        public IActionResult OnGet(int Id)
        {

            article = _ArticleManager.GetOne(Id);

            Categories = articleCategoryManager.GetAllCategories();
            CategoryList = new SelectList(Categories, "Id", "Name", article.CategoryId);


            this.Id = Id;
            return Page();

        }
        public IActionResult OnPost()
        {

            var path = Path.Combine(Directory.GetCurrentDirectory(), article.Photo);
          

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }



            _ArticleManager.DeleteArtical(article.Id);
            return Redirect("/article/list");
        }
    }
}
