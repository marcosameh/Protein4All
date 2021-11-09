using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Managers;
using App.Core.Models;
using App.UI.InfraStructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.UI.Pages
{
    public class news_listingModel : PageModel
    {
        private readonly ArticleManager _NewsManager;

        public PaginatedList<Articals> News { get; set; }
        public news_listingModel(ArticleManager newsManager)
        {
          
            _NewsManager = newsManager;
        }
        public IActionResult OnGet(int Id,int PageIndex = 1)
        {



            News = PaginatedList<Articals>.GetData(_NewsManager.GetArticals(Id), PageIndex, 3);

           
            return Page();

        }

    }
}
