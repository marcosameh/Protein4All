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

namespace App.UI.Pages.article
{
    [Authorize(Roles ="Admin")]
    public class deleteModel : PageModel
    {
        private readonly ArticleManager _ArticleManager;
       

        [BindProperty]

        public Articals article { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
      
        public deleteModel(ArticleManager ArticleManager)
        {

            _ArticleManager = ArticleManager;


        }
        public IActionResult OnGet(int Id)
        {
            article = _ArticleManager.GetOne(Id);



           
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
