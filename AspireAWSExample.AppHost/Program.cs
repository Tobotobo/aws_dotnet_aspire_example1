#pragma warning disable CA2252 // This API requires opting into preview features

// using Amazon.CDK.AWS.APIGateway;
// using Amazon.CDK.AWS.Events.Targets;
// using Aspire.Hosting.AWS.CDK;
using Aspire.Hosting.AWS.Lambda;
using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var defaultRouteLambda = builder.AddAWSLambdaFunction<AspireAWSExample_WebDefaultRouteLambdaFunction>(
    name: "LambdaDefaultRoute",
    lambdaHandler: "AspireAWSExample.WebDefaultRouteLambdaFunction::AspireAWSExample.WebDefaultRouteLambdaFunction.Function::FunctionHandler");

var toUpperLambdaFunction = builder.AddAWSLambdaFunction<AspireAWSExample_ToUpperLambdaFunction>(
    name: "ToUpperLambdaFunction",
    lambdaHandler: "AspireAWSExample.ToUpperLambdaFunction::AspireAWSExample.ToUpperLambdaFunction.Function::FunctionHandler");

// Configure API Gateway emulator
builder.AddAWSAPIGatewayEmulator(name: "APIGatewayEmulator", apiGatewayType: APIGatewayType.HttpV2)
    .WithReference(defaultRouteLambda, Method.Get, "/")
    .WithReference(toUpperLambdaFunction, Method.Get, "/upper/{x}");

builder.Build().Run();
