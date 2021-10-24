using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Managers;
using App.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.UI.Pages.article
{
    public class editModel : PageModel
    {
        private readonly ArticleManager _articleManager;
        

        [BindProperty]

        public Articals article { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
     
        public editModel(ArticleManager articleManager)
        {
            _articleManager = articleManager;
        


        }
        public IActionResult OnGet(int Id)
        {
            article = _articleManager.GetOne(Id);

           
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
                string photopath = Directory.GetCurrentDirectory() + "/wwwroot/product-photo/";
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
