using MediatR;
using MetalERP.Application.Features.Setores.CreateSetor;
using MetalERP.Application.Features.Setores.GetSetor;
using MetalERP.Application.Features.Setores.GetSetores;
using MetalERP.Application.Features.Setores.UpdateSetor;
using MetalERP.Application.Features.Setores.DeactivateSetor;
using MetalERP.Application.Features.Setores.ActivateSetor;

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

        app.MapPut(
            "/api/setores/{id:int}",
            async (
                int id,
                UpdateSetorCommand command,
                ISender sender) =>
            {
                var updateCommand =
                    command with { Id = id };

                var result = await sender.Send(updateCommand);

                return result is null
                    ? Results.NotFound()
                    : Results.Ok(result);
            });

        app.MapPatch(
            "/api/setores/{id:int}/desativar",
            async (
                int id,
                ISender sender) =>
            {
                var result =
                    await sender.Send(
                        new DeactivateSetorCommand(id));

                return result is null
                    ? Results.NotFound()
                    : Results.Ok(result);
            });

        app.MapPatch(
            "/api/setores/{id:int}/ativar",
            async (
                int id,
                ISender sender) =>
            {
                var result =
                    await sender.Send(
                        new ActivateSetorCommand(id));

                return result is null
                    ? Results.NotFound()
                    : Results.Ok(result);
            });
    }
}