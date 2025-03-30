using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.APIGatewayEvents;

namespace AspireAWSExample.ToUpperLambdaFunction.Tests;

public class FunctionTest
{
    // [Fact]
    // public void TestToUpperFunction()
    // {

    //     // Invoke the lambda function and confirm the string was upper cased.
    //     var function = new Function();
    //     var context = new TestLambdaContext();
    //     var upperCase = function.FunctionHandler("hello world", context);

    //     Assert.Equal("HELLO WORLD", upperCase);
    // }

    [Fact]
    public void TestToUpperFunction()
    {

        // Invoke the lambda function and confirm the string was upper cased.
        var function = new Function();
        var context = new TestLambdaContext();
        var request = new APIGatewayHttpApiV2ProxyRequest
        {
            PathParameters = new Dictionary<string, string> { { "x", "hello lambda!" } }
        };
        var response = function.FunctionHandler(request, context);

        Assert.Equal("HELLO LAMBDA!", response.Body);
    }
}
