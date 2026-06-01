using MediatR;
using MetalERP.Application.Features.Setores.CreateSetor;
using MetalERP.Application.Features.Setores.GetSetor;
using MetalERP.Application.Features.Setores.GetSetores;

namespace MetalERP.Api.Endpoints;

public static class SetorEndpoints
{
    public static void MapSetorEndpoints(
        this IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/api/setores",
            async (
                CreateSetorCommand command,
                ISender sender) =>
            {
                var result = await sender.Send(command);

                return Results.Created(
                    $"/api/setores/{result.Id}",
                    result);
            });
        
        app.MapGet(
        "/api/setores",
        async (ISender sender) =>
        {
            var result =
                await sender.Send(
                    new GetSetoresQuery());

            return Results.Ok(result);
        });

        app.MapGet(
            "/api/setores/{id:int}",
            async (ISender sender, int id) =>
            {
                var result =
                    await sender.Send(
                        new GetSetorQuery(id));

                return result is null
                    ? Results.NotFound()
                    : Results.Ok(result);
            });
    }
}