using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Managers;
using App.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.UI.Pages.Category
{
    [Authorize(Roles ="Admin")]
    public class ListModel : PageModel
    {
        private readonly CategoryManager _CategoryManager;

        public IQueryable<ProductCategory> Categories{get;set;}
        public ListModel(CategoryManager categoryManager)
        {
            _CategoryManager = categoryManager;
        }
        public void OnGet()
        {
            Categories = _CategoryManager.GetAllCategories();
        }
    }
}
