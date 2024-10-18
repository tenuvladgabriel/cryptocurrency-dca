using System.Net;
using CryptoDCA.Application.Contracts;
using CryptoDCA.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CryptoDCA.API.Endpoints;

public static class InvestmentEndpoints
{
    private const string EndpointBasePath = "api/investments";

    public static void RegisterInvestmentEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet($"{EndpointBasePath}",
                async ([FromServices] IInvestmentService investmentService) =>
                {
                    try
                    {
                        var result = await investmentService.GetInvestmentsByMonthAsync();
                        return result.Count is 0
                            ? Results.NotFound()
                            : Results.Ok(result);
                    }
                    catch (Exception)
                    {
                        return Results.BadRequest();
                    }
                })
            .Produces((int)HttpStatusCode.OK)
            .Produces((int)HttpStatusCode.NotFound)
            .Produces((int)HttpStatusCode.BadRequest)
            .WithOpenApi();

        endpoints.MapPost($"{EndpointBasePath}",
                async ([FromServices] IInvestmentService investmentService,
                    [FromBody] InvestmentRequestViewModel request) =>
                {
                    try
                    {
                        await investmentService.SaveInvestmentAsync(request);
                        return Results.Ok();
                    }
                    catch (Exception)
                    {
                        return Results.BadRequest();
                    }
                })
            .Produces((int)HttpStatusCode.OK)
            .Produces((int)HttpStatusCode.BadRequest)
            .WithOpenApi();
    }
}