using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.UI.Pages
{
    public class SubscriptionModel : PageModel
    {
        private readonly SubscriptionManager _SubscriptionManager;

        public SubscriptionModel(SubscriptionManager subscriptionManager)
        {
            _SubscriptionManager = subscriptionManager;
        }
        public JsonResult OnPost(string Email)
        {
            var result = _SubscriptionManager.FindEmail(Email);
            if (result == 0)
            {
                _SubscriptionManager.AddSubscription(Email);
                return new JsonResult(1);
            }
           
                return new JsonResult(0);
          
        }
    }
}
