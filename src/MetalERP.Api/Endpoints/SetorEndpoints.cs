using MediatR;
using MetalERP.Application.Features.Setores.CreateSetor;

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
    }
}