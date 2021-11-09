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
    public class addModel : PageModel
    {
        private readonly ArticleManager _ArticalManager;
        private readonly ArticleCategoryManager articleCategoryManager;

        [BindProperty]
        public Articals Artical { get; set; }
        public IEnumerable<ArticleCategory> Categories { get; set; }
        public SelectList CategoryList { get; set; }

        public addModel(ArticleManager ArticalManager,ArticleCategoryManager articleCategoryManager)
        {
            _ArticalManager = ArticalManager;
            this.articleCategoryManager = articleCategoryManager;
        }
        public IActionResult OnGet()
        {
            Categories = articleCategoryManager.GetAllCategories();
            CategoryList = new SelectList(Categories, "Id", "Name");
            return Page();

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return OnGet();
            }
            int _min = 100;
            int _max = 999;
            Random _rdm = new Random();
            int guid = _rdm.Next(_min, _max);
            string photopath = Directory.GetCurrentDirectory() + "/wwwroot/artical-photos/";
            string photoname = guid + Path.GetFileName(Artical.PhotoFile.FileName);
            string finalpath = photopath + photoname;
            using (var stream = System.IO.File.Create(finalpath))
            {
                await Artical.PhotoFile.CopyToAsync(stream);
            }

            Artical.Photo = photoname;
            Artical.Url = Artical.Url.ToLower().Replace(" ", "-");
            Artical.Url = Artical.Url.ToLower().Replace("_", "-");
            _ArticalManager.AddArtical(Artical);
            return Redirect("/article/list");
        }
    }
}

