using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Domain;
using App.Core.Managers;
using App.Core.Models;
using App.UI.InfraStructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace App.UI.Pages
{
    public class product_detailsModel : PageModel
    {
        private readonly ProductManager productManager;
        [BindProperty(SupportsGet =true)]
        public string UrlName { get; set; }
        public Product CurrentProduct { get; set; }
        public IQueryable<Product> RelatedProducts { get; set; }
        [BindProperty]
        public Email Email { get; set; }

        private readonly IConfiguration config;
        public product_detailsModel(ProductManager  productManager,IConfiguration config)
        {
            
            this.productManager = productManager;
            this.config = config;
        }

       

        public IActionResult OnGet(string UrlName)
        {
            this.UrlName = UrlName;
            CurrentProduct = productManager.GetProduct(UrlName);
            RelatedProducts = productManager.GetRelatedProduct(CurrentProduct);
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                TempData["alert"] = 0;

                return OnGet(UrlName);
            }
            if (!ReCaptcha.ReCaptchaPassed(Request.Form["g-recaptcha-response"], config.GetSection("GoogleReCaptcha:SecretKey").Value))
            {
                TempData["alert"] = 0;
                ModelState.AddModelError(string.Empty, "You failed the CAPTCHA.");
                return OnGet(UrlName);
            }
            string ApiKey= config.GetSection("MailSettings:APIKey").Value;
            
            string FromName= config.GetSection("MailSettings:FromName").Value;
            string FromEmail= config.GetSection("MailSettings:FromEmail").Value;
            string Domin= config.GetSection("Path:Domin").Value;
            string ToEmail = config.GetSection("MailSettings:ToEmail").Value;
            String[] msgTo = new String[1];
             msgTo[0] = ToEmail;
            Email.ProductUrl= ""+Domin+"product-details/"+UrlName+"";
           var Response=  await EmailManager.SendEmail("ContactUsEmail", FromEmail ,FromName,msgTo, "<tr> <td align='left' style='font-family: 'Open Sans', Arial, sans-serif; font-size:13px; color:#7f8c8d;'> Dear Administrator, <br /><br /> <b>The following email has been sent by:</b>"+Email.Name+ " <br /> <br /> <b>Email:</b> " + Email.email + " <br /> <b>Phone:</b> " + Email.PhoneNumber + " <br />  <b>Product:</b> " + Email.ProductUrl + " <br /> <b>Message:</b> " + Email.Message + " <br /> <br /> Please don't reply directly to this email, this is a system generated message. </td> </tr>", "test",ApiKey);
            if (Response == null)
            {
                TempData["alert"] = 0;

                return OnGet(UrlName);
            }

            TempData["alert"] = 1;
            return OnGet(UrlName);








        }
    }
}
