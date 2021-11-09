
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace App.UI.Configurations
{
    public static class Routes
    {
        public static IServiceCollection AddCustomizedRoutes(this IServiceCollection services)
        {
            services.AddRazorPages(options =>
            {
                
                //options.Conventions.AddPageRoute("/contact-us", "{culture:culture}/contact-us");
                //options.Conventions.AddPageRoute("/about-us", "{culture:culture}/about-us");
                //options.Conventions.AddPageRoute("/error", "{culture:culture}/error");
                //options.Conventions.AddPageRoute("/faqs", "{culture:culture}/faqs");
                options.Conventions.AddPageRoute("/product-details", "/product-details/{UrlName}");
                options.Conventions.AddPageRoute("/news-details", "/news-details/{Url}");
                options.Conventions.AddPageRoute("/product-listing", "/product-listing/{Id}/{PageIndex?}");
                options.Conventions.AddPageRoute("/news-listing", "/news-listing/{Id}/{PageIndex?}");
                //options.Conventions.AddPageRoute("/blog", "{culture:culture}/blog/{year?}/{month?}");
                //options.Conventions.AddPageRoute("/article", "/blog/{ArticleUrlName:regex(^[[a-zA-Z]])}");
                //options.Conventions.AddPageRoute("/article", "{culture:culture}/blog/{ArticleUrlNameregex(^[[a-zA-Z]])}");
            });

            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;

            });

            return services;
        }


    }
}
