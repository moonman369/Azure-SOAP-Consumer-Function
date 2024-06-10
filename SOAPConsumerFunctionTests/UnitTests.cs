using Xunit;
using Moq;
using Moq.Protected;
using Microsoft.Extensions.Logging;
using Moonman.Function;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Moonman.UnitTests
{
    public class FunctionUnitTests
    {
        private readonly Mock<ILogger<SOAPConsumerHttpTrigger1>> _mockLogger;
        private readonly Mock<HttpMessageHandler> _mockMessageHandler;

        public FunctionUnitTests()
        {
            _mockLogger = new Mock<ILogger<SOAPConsumerHttpTrigger1>>();
            _mockMessageHandler = new Mock<HttpMessageHandler>();
        }

        [Fact]
        public async Task Run_Should_Return_OkResult()
        {
            // Arrange
            var context = new DefaultHttpContext();
            var request = context.Request;

            // Set up any necessary mock behavior or input data
            request.QueryString = new QueryString("?num=9830225");

            // Moq HttpClient Setup
            var mockResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            mockResponse.Content = new StringContent("<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\n    <s:Body>\n        <NumToWordsResponse xmlns=\"http://tempuri.org/\">\n            <NumToWordsResult>ninety-eight hundred thirty thousand two hundred and twenty-five</NumToWordsResult>\n        </NumToWordsResponse>\n    </s:Body>\n</s:Envelope>");
            _mockMessageHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).ReturnsAsync(mockResponse);

            var _mockClient = new HttpClient(_mockMessageHandler.Object);

            SOAPConsumerHttpTrigger1 funcObj = new(_mockLogger.Object, _mockClient);

            // Act
            var response = await funcObj.Run(request);

            // Assert
            var result = Assert.IsType<OkObjectResult>(response);
            Assert.Equal("<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\n    <s:Body>\n        <NumToWordsResponse xmlns=\"http://tempuri.org/\">\n            <NumToWordsResult>ninety-eight hundred thirty thousand two hundred and twenty-five</NumToWordsResult>\n        </NumToWordsResponse>\n    </s:Body>\n</s:Envelope>", result.Value);
        }
    }
}