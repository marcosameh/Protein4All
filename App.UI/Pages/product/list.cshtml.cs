using System;

using System.Linq;
using App.Core.Managers;
using App.Core.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.UI.Pages.product
{
    [Authorize(Roles ="Admin")]
    public class listModel : PageModel
    {
        private readonly ProductManager _ProductManager;
     
        public IQueryable<Product> Products { get; set; }
        public listModel(ProductManager productManager)
        {
            _ProductManager = productManager;
            
        }
        public void OnGet()
        {
            Products = _ProductManager.GetAllProduct();
            

        }


        

        
    }
}

