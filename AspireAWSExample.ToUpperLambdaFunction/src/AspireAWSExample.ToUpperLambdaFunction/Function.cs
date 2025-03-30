using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AspireAWSExample.ToUpperLambdaFunction;

public class Function
{

    // /// <summary>
    // /// A simple function that takes a string and does a ToUpper
    // /// </summary>
    // /// <param name="input">The event for the Lambda function handler to process.</param>
    // /// <param name="context">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
    // /// <returns></returns>
    // public string FunctionHandler(string input, ILambdaContext context)
    // {
    //     return input.ToUpper();
    // }
    public APIGatewayHttpApiV2ProxyResponse FunctionHandler(APIGatewayHttpApiV2ProxyRequest request, ILambdaContext context)
    {
        var x = request.PathParameters["x"];
        var result = x.ToUpper();
        context.Logger.LogInformation($"x = {x}, result = {result}");

        var response = new APIGatewayHttpApiV2ProxyResponse
        {
            StatusCode = 200,
            Headers = new Dictionary<string, string>
            {
                {"Content-Type", "application/json" }
            },
            Body = result.ToString()
        };
        return response;
    }
}
