using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AspireAWSExample.WebDefaultRouteLambdaFunction;

public class Function
{
    public APIGatewayHttpApiV2ProxyResponse FunctionHandler(APIGatewayHttpApiV2ProxyRequest request, ILambdaContext context)
    {
        // 0 から 9 のランダムな値を生成
        Random random = new Random();
        int random0to9 = random.Next(0, 10);
        context.Logger.LogInformation($"random0to9 = {random0to9}");

        // HTMLのレスポンスボディを作成
        string body = $@"<!DOCTYPE html>
<html lang=""ja"">
<head>
    <meta charset=""utf-8"" />
    <title>Hello .NET Aspire!</title>
</head>
<body>
    <h1>Hello .NET Aspire!</h1>
    <p>0 から 9 のランダムな値: {random0to9}</p>
    <input type=""text"" id=""inputText"">
    <button onclick=""convertToUpper()"">大文字変換</button>
    <p>結果: <span id=""result""></span></p>

  <script>
    async function convertToUpper() {{
      const input = document.getElementById('inputText').value;
      const response = await fetch(`/upper/${{encodeURIComponent(input)}}`);

      if (response.ok) {{
        const text = await response.text();
        document.getElementById('result').textContent = text;
      }} else {{
        document.getElementById('result').textContent = 'エラーが発生しました';
      }}
    }}
  </script>
</body>
</html>";

        var response = new APIGatewayHttpApiV2ProxyResponse
        {
            StatusCode = 200,
            Headers = new Dictionary<string, string>
            {
                {"Content-Type", "text/html" }
            },
            Body = body,
        };
        return response;
    }
}
