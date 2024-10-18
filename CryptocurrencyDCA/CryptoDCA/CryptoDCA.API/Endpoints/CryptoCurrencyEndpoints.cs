using System.Net;
using CryptoDCA.Application.Contracts;
using CryptoDCA.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CryptoDCA.API.Endpoints;

public static class CryptoCurrencyEndpoints
{
    private const string EndpointBasePath = "api/cryptocurrencies";

    public static void RegisterCryptocurrenciesEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet($"{EndpointBasePath}", async ([FromServices] ICryptocurrencyService cryptoCurrencyService) =>
            {
                try
                {
                    var result = await cryptoCurrencyService.GetAll();
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
                async ([FromServices] ICryptocurrencyService cryptoCurrencyService,
                    [FromBody] CryptocurrencyCreateViewModel request) =>
                {
                    try
                    {
                        await cryptoCurrencyService.Create(request);
                        return Results.Created();
                    }
                    catch (Exception)
                    {
                        return Results.BadRequest();
                    }
                })
            .Produces((int)HttpStatusCode.Created)
            .Produces((int)HttpStatusCode.BadRequest)
            .WithOpenApi();
    }
}