using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Managers;
using App.Core.Models;
using App.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.UI.Pages.product
{
    public class editModel : PageModel
    {
        private readonly ProductManager _ProductManager;
        private readonly CategoryManager categoryManager;

        [BindProperty]
   
        public Product Product { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public IEnumerable<ProductCategory> Categories { get; set; }
        public SelectList CategoryList { get; set; }
        public editModel(ProductManager productManager, CategoryManager categoryManager)
        {
            _ProductManager = productManager;
            this.categoryManager = categoryManager;
            

        }
        public IActionResult OnGet(int Id)
        {
            Product = _ProductManager.GetOne(Id);
          

            
            Categories = categoryManager.GetAllCategories();
            CategoryList = new SelectList(Categories, "Id", "Name",Product.CategoryId);
            this.Id = Id;
            return Page();

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return OnGet(Id);
            }
            if (Product.PhotoFile != null)
            {
                string photopath = Directory.GetCurrentDirectory() + "/wwwroot/product-photo/";
                string photoname = Path.GetFileName(Product.PhotoFile.FileName);
                string finalpath = photopath + photoname;
                using (var stream = System.IO.File.Create(finalpath))
                {
                    await Product.PhotoFile.CopyToAsync(stream);
                }
                Product.Photo = photoname;
            }

            
            Product.Url = Product.Url.ToLower().Replace(" ", "-");
            Product.Url = Product.Url.ToLower().Replace("_", "-");

            
            _ProductManager.UpdateProduct(Product);
            return Redirect("/product/list");
        }
    }
}

