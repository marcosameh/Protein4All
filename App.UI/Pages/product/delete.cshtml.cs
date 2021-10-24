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
    [Authorize(Roles="Admin")]
    public class deleteModel : PageModel
    {

        private readonly ProductManager _ProductManager;
        private readonly CategoryManager categoryManager;

        [BindProperty]

        public Product Product { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public IEnumerable<ProductCategory> Categories { get; set; }
        public SelectList CategoryList { get; set; }
        public deleteModel(ProductManager productManager, CategoryManager categoryManager)
        {
            _ProductManager = productManager;
            this.categoryManager = categoryManager;


        }
        public IActionResult OnGet(int Id)
        {
            Product = _ProductManager.GetOne(Id);



            Categories = categoryManager.GetAllCategories();
            CategoryList = new SelectList(Categories, "Id", "Name", Product.CategoryId);
            this.Id = Id;
            return Page();

        }
        public  IActionResult OnPost()
        {


            var path = Path.Combine(Directory.GetCurrentDirectory(), Product.Photo);


            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }


            _ProductManager.DeleteProduct(Product.Id);
            return Redirect("/product/list");
        }
    }
}
