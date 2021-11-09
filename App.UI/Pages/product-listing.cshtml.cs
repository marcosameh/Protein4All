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
    public class product_listingModel : PageModel
    {
        private readonly ProductManager productManager;


        public PaginatedList<Product> Products { get; set; }
        
        public product_listingModel(ProductManager productManager)
        {
            this.productManager = productManager;
            
        }
        public void OnGet(int Id,int? PageIndex=1)
        {
           

                 Products = PaginatedList<Product>.GetData(productManager.GetProduct(Id), PageIndex.Value, 9);

        }
       
    }
}
