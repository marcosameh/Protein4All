using App.Core.Models;
using App.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Managers
{

    public class SubscriptionManager
    {
        private Subscriptions subscriptionEntity = new Subscriptions();

        BaseRepo<Subscriptions> SubscriptionRepo;
        public SubscriptionManager(Protein4allContext Context)
        {
            SubscriptionRepo = new BaseRepo<Subscriptions>(Context);
        }

        public int FindEmail(string Email)
        {
            var result=SubscriptionRepo.GetOne(x => x.Email == Email);
            if (result == null)
            {
                return 0;
            }
           
                return 1;
           
           

        }
        public void AddSubscription(string Email)
        {

            subscriptionEntity.Email = Email;
            subscriptionEntity.SubscriptionDate = DateTime.Now.ToShortDateString();

            SubscriptionRepo.Add(subscriptionEntity);


        }
        public IQueryable<Subscriptions> GetSubscriptions()
        {
            return SubscriptionRepo.GetAll();
        }
    }
}
