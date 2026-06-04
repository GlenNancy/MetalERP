using MediatR;
using MetalERP.Application.Features.Usuarios.CreateUsuario;
using MetalERP.Application.Features.Usuarios.GetUsuario;
using MetalERP.Application.Features.Usuarios.GetUsuarios;
using MetalERP.Application.Features.Usuarios.UpdateUsuario;
using MetalERP.Application.Features.Usuarios.DeactivateUsuario;
using MetalERP.Application.Features.Usuarios.ActiveUsuario;
using MetalERP.Application.Features.Usuarios.GetUsuarioRead;

namespace MetalERP.Api.Endpoints;

public static class UsuarioEndpoints
{
    public static void MapUsuarioEndpoints(
        this IEndpointRouteBuilder app)
    {
        app.MapPost(
            "/api/usuarios",
            async (
                CreateUsuarioCommand command,
                ISender sender) =>
            {
                var result = await sender.Send(command);

                return Results.Created(
                    $"/api/usuarios/{result.Id}",
                    result);
            });
        
        app.MapGet(
        "/api/usuarios",
        async (ISender sender) =>
        {
            var result =
                await sender.Send(
                    new GetUsuariosQuery());

            return Results.Ok(result);
        });

        app.MapGet(
            "/api/usuarios/{id:int}",
            async (ISender sender, int id) =>
            {
                var result =
                    await sender.Send(
                        new GetUsuarioReadQuery(id));

                return result is null
                    ? Results.NotFound()
                    : Results.Ok(result);
            });

        app.MapPut(
            "/api/usuarios/{id:int}",
            async (
                int id,
                UpdateUsuarioCommand command,
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
            "/api/usuarios/{id:int}/desativar",
            async (
                int id,
                ISender sender) =>
            {
                var result =
                    await sender.Send(
                        new DeactivateUsuarioCommand(id));

                return result is null
                    ? Results.NotFound()
                    : Results.Ok(result);
            });

        app.MapPatch(
            "/api/usuarios/{id:int}/ativar",
            async (
                int id,
                ISender sender) =>
            {
                var result =
                    await sender.Send(
                        new ActiveUsuarioCommand(id));

                return result is null
                    ? Results.NotFound()
                    : Results.Ok(result);
            });
    }
}