using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using ServiceReference;
using System.Net;
using System.Net.Http;
using System.ServiceModel;

namespace Moonman.Function
{
    public class SOAPConsumerHttpTrigger1
    {
        private readonly ILogger<SOAPConsumerHttpTrigger1> _logger;

        public SOAPConsumerHttpTrigger1(ILogger<SOAPConsumerHttpTrigger1> logger)
        {
            _logger = logger;
        }

        // public HttpWebRequest CreateSOAPWebRequest()
        // {
        //     HttpWebRequest Req = (HttpWebRequest)WebRequest.Create("")
        // }

        [Function("SOAPConsumerHttpTrigger1")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation(req.Query["num"]);
            var client = new SOAPServiceClient(SOAPServiceClient.EndpointConfiguration.BasicHttpBinding_ISOAPService_soap);

            string? numFromQuery = req.Query["num"];

            if (numFromQuery == null)
            {
                return new ObjectResult("Please provide valid number in query params");
            }

            var result = await client.NumToWordsAsync(Int32.Parse(numFromQuery ?? "0"));

            _logger.LogInformation(result.Body.NumToWordsResult);

            return new OkObjectResult($"{numFromQuery} in words is {result.Body.NumToWordsResult}");
        }
    }
}
