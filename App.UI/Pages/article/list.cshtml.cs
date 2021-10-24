using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Managers;
using App.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.UI.Pages.article
{
    [Authorize(Roles="Admin")]
    public class listModel : PageModel
    {
        private readonly ArticleManager _ArticalManager;

        public IQueryable<Articals> Articals { get; set; }
        public listModel(ArticleManager ArticalManager)
        {
            _ArticalManager = ArticalManager;

        }
        public void OnGet()
        {
            Articals = _ArticalManager.GetAllArtical ();


        }

    }
}
