using System;
using System.Collections.Generic;
using System.Linq;
using App.Core.Managers;
using App.Core.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.UI.Pages.product
{
    [Authorize(Roles ="Admin")]
    public class listModel : PageModel
    {
        private readonly ProductManager _ProductManager;
        private readonly CategoryManager _categoryManager;

        public IQueryable<Product> Products { get; set; }
        public SelectList CategoryList { get; set; }
        public IEnumerable<ProductCategory> Categories { get; set; }
        [BindProperty(SupportsGet =true)]
        public int? Id { get; set; }
        public listModel(ProductManager productManager, CategoryManager categoryManager)
        {
            _ProductManager = productManager;
            _categoryManager = categoryManager;
        }
        public IActionResult OnGet(int?Id)
        {
            this.Id =Id;
            if (Id == null)
            {
                Categories = _categoryManager.GetAllCategories();
                CategoryList = new SelectList(Categories, "Id", "Name");
                Products = _ProductManager.GetAllProduct();
                return Page();
            }
            Categories = _categoryManager.GetAllCategories();
            CategoryList = new SelectList(Categories, "Id", "Name");
            Products = _ProductManager.GetProduct(Id);
            return Page();
        }

        public IActionResult OnPost(string productname)
        {

            if (String.IsNullOrEmpty(productname)) 
            {
                
                return OnGet(Id);
            }
            Categories = _categoryManager.GetAllCategories();
            CategoryList = new SelectList(Categories, "Id", "Name");
            Products = _ProductManager.GetProductByName(productname);
            return Page();
        }




    }
}

