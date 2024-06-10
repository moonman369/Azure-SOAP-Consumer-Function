using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using ServiceReference;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceModel;
using Moonman.SOAP;
using System.Xml.Serialization;
using System.Text;

namespace Moonman.Function
{
    public class SOAPConsumerHttpTrigger1
    {
        private readonly ILogger<SOAPConsumerHttpTrigger1> _logger;
        private readonly HttpClient _client;

        public SOAPConsumerHttpTrigger1(ILogger<SOAPConsumerHttpTrigger1> logger, HttpClient client)
        {
            _logger = logger;
            _client = client;
        }

        // public HttpWebRequest CreateSOAPWebRequest()
        // {
        //     HttpWebRequest Req = (HttpWebRequest)WebRequest.Create("")
        // }

        [Function("SOAPConsumerHttpTrigger1")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            // try
            // {
            //     _logger.LogInformation(req.Query["num"]);

            //     // CALLING SOAP SERVICE USING ServiceReference
            //     // var client = new SOAPServiceClient(SOAPServiceClient.EndpointConfiguration.BasicHttpBinding_ISOAPService_soap);

            //     string? numFromQuery = req.Query["num"];

            //     if (numFromQuery == null)
            //     {
            //         return new ObjectResult("Please provide valid number in query params");
            //     }

            //     // var result = await client.NumToWordsAsync(int.Parse(numFromQuery ?? "0"));

            //     // _logger.LogInformation(result.Body.NumToWordsResult);

            //     // return new OkObjectResult($"{numFromQuery} in words is {result.Body.NumToWordsResult}");


            //     HttpClient client = new()
            //     {
            //         BaseAddress = new Uri("https://soapwebservice0.azurewebsites.net/NumToWords.asmx")
            //     };
            //     client.DefaultRequestHeaders.Accept.Clear();
            //     client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
            //     client.DefaultRequestHeaders.Add("SOAPAction", "http://tempuri.org/ISOAPService/NumToWords");

            //     NumToWords numToWords = new()
            //     {
            //         Num = int.Parse(numFromQuery ?? "0")
            //     };

            //     SoapBody soapBody = new()
            //     {
            //         Content = numToWords
            //     };

            //     SoapEnvelope soapEnvelope = new()
            //     {
            //         Body = soapBody
            //     };

            //     XmlSerializer xSer = new(typeof(SoapEnvelope));
            //     var xmlString = new StringWriter();
            //     xSer.Serialize(xmlString, soapEnvelope);

            //     HttpContent xmlContent = new StringContent(xmlString.ToString(), Encoding.UTF8, "text/xml");
            //     var response = await client.PostAsync("", xmlContent);

            //     return new OkObjectResult(response.Content);
            // }

            // catch (Exception e)
            // {
            //     _logger.LogError(e.Message);
            //     _logger.LogError(e.StackTrace);
            //     return new UnprocessableEntityObjectResult(e);
            // }






            _logger.LogInformation(req.Query["num"]);

            // CALLING SOAP SERVICE USING ServiceReference
            // var client = new SOAPServiceClient(SOAPServiceClient.EndpointConfiguration.BasicHttpBinding_ISOAPService_soap);

            string? numFromQuery = req.Query["num"];

            if (numFromQuery == null)
            {
                return new ObjectResult("Please provide valid number in query params");
            }

            // var result = await client.NumToWordsAsync(int.Parse(numFromQuery ?? "0"));

            // _logger.LogInformation(result.Body.NumToWordsResult);

            // return new OkObjectResult($"{numFromQuery} in words is {result.Body.NumToWordsResult}");


            // HttpClient client = new()
            // {
            //     BaseAddress = new Uri("https://soapwebservice0.azurewebsites.net/NumToWords.asmx")
            // };
            _client.BaseAddress = new Uri("https://soapwebservice0.azurewebsites.net/NumToWords.asmx");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
            _client.DefaultRequestHeaders.Add("SOAPAction", "http://tempuri.org/ISOAPService/NumToWords");

            NumToWords numToWords = new()
            {
                Num = int.Parse(numFromQuery ?? "0")
            };

            SoapBody soapBody = new()
            {
                Content = numToWords
            };

            SoapEnvelope soapEnvelope = new()
            {
                Body = soapBody
            };

            XmlSerializer xSer = new(typeof(SoapEnvelope));
            var xmlString = new Utf8StringWriter();
            xSer.Serialize(xmlString, soapEnvelope);

            _logger.LogInformation(xmlString.ToString());

            HttpContent xmlContent = new StringContent(xmlString.ToString(), Encoding.UTF8, "text/xml");
            var response = await _client.PostAsync("", xmlContent);
            _logger.LogInformation(response.Content.ReadAsStringAsync().Result);

            return new OkObjectResult(response.Content.ReadAsStringAsync().Result);


        }
    }
}
