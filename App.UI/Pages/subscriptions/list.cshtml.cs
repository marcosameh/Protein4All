using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Managers;
using App.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.UI.Pages.subscriptions
{
    public class listModel : PageModel
    {
        private readonly SubscriptionManager subscriptionManager;

        public IQueryable<Subscriptions> Subscriptions { get; set; }
        public listModel(SubscriptionManager subscriptionManager)
        {
            this.subscriptionManager = subscriptionManager;
        }
        public void OnGet()
        {
            Subscriptions = subscriptionManager.GetSubscriptions();

        }
    }
}
