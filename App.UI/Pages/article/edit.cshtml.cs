using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Managers;
using App.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.UI.Pages.article
{
    public class editModel : PageModel
    {
        private readonly ArticleManager _articleManager;
        private readonly ArticleCategoryManager articleCategoryManager;

        [BindProperty]

        public Articals article { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public IEnumerable<ArticleCategory> Categories { get; set; }
        public SelectList CategoryList { get; set; }
        public editModel(ArticleManager articleManager,ArticleCategoryManager articleCategoryManager)
        {
            _articleManager = articleManager;
            this.articleCategoryManager = articleCategoryManager;
        }
        public IActionResult OnGet(int Id)
        {
            article = _articleManager.GetOne(Id);

            Categories = articleCategoryManager.GetAllCategories();
            CategoryList = new SelectList(Categories, "Id", "Name", article.CategoryId);

            this.Id = Id;
            return Page();

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return OnGet(Id);
            }
            if (article.PhotoFile != null)
            {
                string photopath = Directory.GetCurrentDirectory() + "/wwwroot/artical-photos/";
                string photoname = Path.GetFileName(article.PhotoFile.FileName);
                string finalpath = photopath + photoname;
                using (var stream = System.IO.File.Create(finalpath))
                {
                    await article.PhotoFile.CopyToAsync(stream);
                }
                article.Photo = photoname;
            }


            article.Url = article.Url.ToLower().Replace(" ", "-");
            article.Url = article.Url.ToLower().Replace("_", "-");


            _articleManager.UpdateArtical(article);
            return Redirect("/article/list");
        }
    }
}
