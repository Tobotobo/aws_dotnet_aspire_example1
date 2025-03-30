using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.APIGatewayEvents;
using System.Text.RegularExpressions;

namespace AspireAWSExample.WebDefaultRouteLambdaFunction.Tests;

public class FunctionTest
{
    [Fact]
    public void TestFunction()
    {
        var function = new Function();
        var context = new TestLambdaContext();
        var request = new APIGatewayHttpApiV2ProxyRequest();
        var response = function.FunctionHandler(request, context);

        // 正規表現パターンで、<p>0 から 9 のランダムな値: 数字</p> をチェックします。
        var pattern = @"<p>0 から 9 のランダムな値: [0-9]</p>";
        var regex = new Regex(pattern);
        Assert.Matches(regex, response.Body);
    }
}
