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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.UI.Pages.product
{
    [Authorize(Roles ="Admin")]
    public class addModel : PageModel
    {
        private readonly ProductManager _ProductManager;
        private readonly CategoryManager categoryManager;

        [BindProperty]
        public Product  Product { get; set; }
        public IEnumerable<ProductCategory> Categories { get; set; }
        public SelectList CategoryList { get; set; }
        public addModel(ProductManager productManager,CategoryManager categoryManager)
        {
            _ProductManager = productManager;
            this.categoryManager = categoryManager;
           
        }
        public IActionResult OnGet()
        {
            Categories = categoryManager.GetAllCategories();
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
            string photopath = Directory.GetCurrentDirectory() + "/wwwroot/product-photo/";
            string photoname = guid+Path.GetFileName(Product.PhotoFile.FileName);
            string finalpath = photopath + photoname;
            using (var stream = System.IO.File.Create(finalpath))
            {
                await Product.PhotoFile.CopyToAsync(stream);
            }
          
            Product.Photo = photoname;
            Product.Url = Product.Url.ToLower().Replace(" ", "-");
            Product.Url= Product.Url.ToLower().Replace("_", "-");
            _ProductManager.AddProduct(Product);
            return Redirect("/product/list");
        }
    }
}
