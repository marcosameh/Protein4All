using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using static ElasticEmailClient.Api;
using static ElasticEmailClient.ApiTypes;

namespace App.Core.Managers
{
    public class EmailManager
    {
       


       

        public async static Task<ElasticEmailClient.ApiTypes.EmailSend> SendEmail(string subject, string fromEmail, string fromName, string[] msgTo, string html, string text,string Api)
        {


            ApiKey = Api;
            try
            {
                return await ElasticEmailClient.Api.Email.SendAsync(subject, fromEmail, fromName, msgTo: msgTo, bodyHtml: html, bodyText: text);

            }
            catch (Exception ex)
            {
                if (ex is ApplicationException)
                    Console.WriteLine("Server didn't accept the request: " + ex.Message);
                else
                    Console.WriteLine("Something unexpected happened: " + ex.Message);

                return null;
            }
        }
    }
}
