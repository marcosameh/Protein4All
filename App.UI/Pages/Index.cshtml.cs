using App.Core.Managers;
using App.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.UI.Pages
{
    public class IndexModel : PageModel
    {
  
        private readonly CategoryManager categoryManager;
        private readonly ProductManager productManager;
        private readonly ArticleManager articleManager;
     
        public IQueryable<ProductCategory> Categories;
        public IQueryable<Product> Product;
        public  IQueryable<Product> AllProduct;
        public IQueryable<Articals> Articls;
        
     
        public IndexModel(CategoryManager categoryManager,ProductManager productManager,ArticleManager articleManager)
        {
            
            this.categoryManager = categoryManager;
            this.productManager = productManager;
            this.articleManager = articleManager;
          
        }

        public IActionResult OnGet()
        {
          
            Categories = categoryManager.GetActiveCategories();
            Articls = articleManager.GetAllArtical();
            AllProduct = productManager.GetActiveProduct();
           



            return Page();
        }
    }
}
