using System;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using PostmarkDotNet;
using PostmarkDotNet.Model;


namespace Function
{
    public static class Function1
    {
        [FunctionName("Function1")]

        public  static async void Run([TimerTrigger("0 * * * * *")] TimerInfo myTimer, ILogger log)
        {

            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        
        HttpClient client = new HttpClient();


            var res =  client.GetAsync("http://active2.azurewebsites.net/api/values");
            
            string activeFlag = await res.Result.Content.ReadAsStringAsync();

            log.LogInformation($"Message was {activeFlag}");

            if (activeFlag == "true")
            {

                var message = new PostmarkMessage()
                {
                    To = "support@happyatwork.se",
                    From = "info@happyatwork.se",
                    Subject = "Coding exercise",
                    TextBody = "Hello!",
                };

                string postmarkToken = Environment.GetEnvironmentVariable("POSTMARK_TOKEN");

                var pmClient = new PostmarkClient(postmarkToken);
                var sendResult = await pmClient.SendMessageAsync(message);

                if (sendResult.Status == PostmarkStatus.Success) { log.LogInformation("Success"); }
                else
                {
                    log.LogError("Error occured");
                    log.LogError($"{sendResult.ErrorCode}");
                    log.LogError($"{sendResult.Message}");
                }

            }

        }

    }

}