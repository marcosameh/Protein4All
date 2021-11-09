
using App.Core.Managers;
using App.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace App.UI.Pages
{
    public class blogModel :  PageModel
    {
        private readonly ArticleManager _NewsManager;

        public Articals News { get; set; }

        //[BindProperty(SupportsGet =true)]
        //public NewsFilter NewsFilter { get; set; }


       

        public blogModel(ArticleManager newsManager)
        {
            _NewsManager = newsManager;
            
            
        }
        public void OnGet(string Url)
        {
            News = _NewsManager.GetArticleDetails(Url);
        }
    }
}